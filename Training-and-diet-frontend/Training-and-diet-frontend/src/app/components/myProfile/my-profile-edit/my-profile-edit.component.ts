import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { PupilPersonalInfo } from 'src/app/models/MyProfile/pupilPersonalInfo';
import { UserService } from 'src/app/services/user.service';
import { NgForm, NgModel } from '@angular/forms';
import { UserPersonalInfo } from 'src/app/models/MyProfile/userPersonalInfo';
import { TrainerPersonalInfo } from 'src/app/models/MyProfile/trainerPersonalInfo';
import { GymService } from 'src/app/services/gym.service';
import { forkJoin } from 'rxjs';
import { ActiveGym } from 'src/app/models/activeGym';


@Component({
  selector: 'app-my-profile-edit',
  templateUrl: './my-profile-edit.component.html',
  styleUrls: ['./my-profile-edit.component.css']
})
export class MyProfileEditComponent implements OnInit {


constructor(private userSerive: UserService, private gymService: GymService) {}

user: UserPersonalInfo|undefined;
role: string = "";
id: string = "";
formattedDate: string = "";
@ViewChild('profileForm') profileForm: NgForm | undefined;
successFlag: string = "";
fieldErrors: { [key: string]: string[] } = {};
@ViewChild('dateOfBirth') dateOfBirth: NgModel | undefined;
@ViewChild('trainingPlanPriceTo') trainingPlanPriceTo: NgModel | undefined;
@ViewChild('personalTrainingPriceTo') personalTrainingPriceTo: NgModel | undefined;
allActiveGyms: ActiveGym[] = []; 
selectedGym: ActiveGym | null = null;
inputGymsError: string = "";
@ViewChild('autocompleteGyms') autocompleteGyms: ElementRef|undefined;




trainingPlanPriceError: boolean = false;

imageUrl: string | ArrayBuffer | null = null;

onFileSelected(event:any) {
  const file = event.target.files[0];
  if (file) {
    const reader = new FileReader();
    reader.onload = e => this.imageUrl = reader.result;
    reader.readAsDataURL(file);
  }
}


ngOnInit(): void {
  //Po dodaniu uwierzytelnienia trzeba będzie pobrać dane zalogowanego użytkownika z jwt Tokena
  this.role = "Trainer"
  this.id = "2";

  if (this.role == "Pupil") {
    this.userSerive.GetPupilPersonalInfoById(this.id).subscribe(
      {
        next:(pupilInfo)=>{
          this.user=pupilInfo;
          if(this.user.sex==null){
            this.user.sex="";
          }
          this.formattedDate = this.formatDate(this.user.dateOfBirth?.toString());
        },
        error: (response)=>{
          console.log(response);
        }
      }
    )
  }
  else if (this.role == "Trainer") {
    forkJoin({
      trainerInfo: this.userSerive.GetTrainerPersonalInfoById(this.id),
      gyms: this.gymService.GetAllActiveMentorGyms(this.id),
      allGyms: this.gymService.GetAllActiveGyms()
    }).subscribe({
      next: ({ trainerInfo, gyms, allGyms }) => {
        this.user = trainerInfo;
        this.allActiveGyms = allGyms;
        if (this.user) {
          this.user.trainerGyms = gyms;
        }
      },
      error: (response) => {
        console.log(response);
      }
    });
  }else if (this.role == "Dietician") {
    //Pobranie danych mentora
    //Pobranie danych osobowych mentora
  }
  else if (this.role == "Dietician-Trainer") {
    //Pobranie danych mentora
    //Pobranie danych osobowych mentora
  }

}

onSubmit() {
  if (this.profileForm?.valid) {
  if (this.user) {
    if (this.role == "Trainer") {
      let trainerInfo: TrainerPersonalInfo = this.mapUserToTrainer(this.user);
      this.userSerive.UpdateTrainerPersonalInfo(this.user, this.id).subscribe({
        next: (response) => {
          this.successFlag = "success";
          this.showSuccessPopup(this.successFlag);
          document.documentElement.scrollTop = 0;
        },
        error: (error) => {
          if (error.status === 400) {
            const { errors } = error.error; 
  
            this.fieldErrors = {}; 
        
            for (const key in errors) {
                if (errors.hasOwnProperty(key)) {
                    this.fieldErrors[key] = errors[key]; 
                }
            }
            console.log(error.error);
  
          }else {
          this.successFlag = "error";
          this.showSuccessPopup(this.successFlag);
          document.documentElement.scrollTop = 0;
        }
        }
      });
    }else if (this.role == "Pupil") {
    this.user.dateOfBirth = new Date(this.formattedDate);
    let pupilInfo: PupilPersonalInfo = this.mapUserToPupil(this.user);
    this.userSerive.UpdatePupilPersonalInfo(this.user, this.id).subscribe({
      next: (response) => {
        this.successFlag = "success";
        this.showSuccessPopup(this.successFlag);
        document.documentElement.scrollTop = 0;
      },
      error: (error) => {
        if (error.status === 400) {
          const { errors } = error.error;

          this.fieldErrors = {}; 
      
          for (const key in errors) {
              if (errors.hasOwnProperty(key)) {
                  this.fieldErrors[key] = errors[key]; 
              }
          }

        }else {
        this.successFlag = "error";
        this.showSuccessPopup(this.successFlag);
        document.documentElement.scrollTop = 0;
      }
      }
    });
  }
  }
  
}

}


formatDate(date: string | undefined): string {
  if (date === undefined) {
      return "";
  }
  return date.split('T')[0];
}

onDateChange() {
  const currentDate = new Date();
  const selectedDate = new Date(this.formattedDate);

  if (selectedDate > currentDate) {
      this.dateOfBirth?.control.setErrors({ 'max': true });
  } else {
      this.dateOfBirth?.control.setErrors(null);
  }
}

validatePriceRange(): void {
  if(this.user){
    let planPricesConsistent = true;
    let trainingPricesConsistent = true;

    const trainingBothOrNone = (this.user.personalTrainingPriceFrom === null && this.user.personalTrainingPriceTo === null) ||
                       (this.user.personalTrainingPriceFrom !== null && this.user.personalTrainingPriceTo !== null);

    const planBothOrNone = (this.user.trainingPlanPriceFrom === null && this.user.trainingPlanPriceTo === null) ||
                       (this.user.trainingPlanPriceFrom !== null && this.user.trainingPlanPriceTo !== null);


    if(this.user.personalTrainingPriceFrom != null && this.user.personalTrainingPriceTo != null){
      trainingPricesConsistent = trainingBothOrNone && 
                         (this.user.personalTrainingPriceFrom === null || this.user.personalTrainingPriceTo >= this.user.personalTrainingPriceFrom);
    }
                       
    if(this.user.trainingPlanPriceFrom != null && this.user.trainingPlanPriceTo != null){
      planPricesConsistent = planBothOrNone && 
                         (this.user.trainingPlanPriceFrom === null || this.user.trainingPlanPriceTo >= this.user.trainingPlanPriceFrom);
    }

    const updateErrors = (control: NgModel, errorKey: string, errorValue: boolean | null) => {
      const errors = control.errors || {}; 
      if (errorValue === false) {
        delete errors[errorKey]; 
      } else {
        errors[errorKey] = errorValue; 
      }
      control.control.setErrors(Object.keys(errors).length > 0 ? errors : null); 
    };
    if(!trainingBothOrNone){
      if(this.personalTrainingPriceTo){
        updateErrors(this.personalTrainingPriceTo, 'bothOrNone', true);
      }
    }
    if(!trainingPricesConsistent){
      if(this.personalTrainingPriceTo){
        updateErrors(this.personalTrainingPriceTo, 'pricesConsistent', true);
      }
    }
    if(trainingBothOrNone){
      if(this.personalTrainingPriceTo){
        updateErrors(this.personalTrainingPriceTo, 'bothOrNone', false);
      }
    }
    if(trainingPricesConsistent){
      if(this.personalTrainingPriceTo){
        updateErrors(this.personalTrainingPriceTo, 'pricesConsistent', false);
      }
    }

    if (!planBothOrNone) {
      if (this.trainingPlanPriceTo) {
        updateErrors(this.trainingPlanPriceTo, 'bothOrNone', true);
      }
    } 
     if (!planPricesConsistent) {
      if (this.trainingPlanPriceTo) {
        updateErrors(this.trainingPlanPriceTo, 'pricesConsistent', true);
      }
    } 
    if (planBothOrNone) {
      if (this.trainingPlanPriceTo) {
        updateErrors(this.trainingPlanPriceTo, 'bothOrNone', false);
      }
    }
    if (planPricesConsistent) {
      if (this.trainingPlanPriceTo) {
        updateErrors(this.trainingPlanPriceTo, 'pricesConsistent', false);
      }
    }
  }
}





showSuccessPopup(status: string) {
  if (status == "success") {
    setTimeout(() => this.successFlag="", 3000); 
  }
  if(status == "error"){
    setTimeout(() => this.successFlag="", 3000); 
  }

}


onSelect(selectedGym: any): void {
  this.selectedGym = selectedGym;
}

addGymToUser(): void {
  if (this.selectedGym) {
    const gymExists = this.user?.trainerGyms?.some(gym => gym.idGym === this.selectedGym?.idGym);
    if (!gymExists) {
      this.user?.trainerGyms?.push(this.selectedGym);
      this.selectedGym = null;
      this.inputGymsError = ''; 
      if (this.autocompleteGyms) {
        this.autocompleteGyms.nativeElement.value = '';  
      }
    } else {
      this.inputGymsError = 'Siłownia jest już dodana do twojego profilu.';
    }
  } else {
    this.inputGymsError = 'Musisz wybrać siłownię z listy.';
  }
}

removeGymFromUser(gymToRemove: ActiveGym): void {
  if (this.user && this.user.trainerGyms) {
    this.user.trainerGyms = this.user.trainerGyms.filter(gym => gym.idGym !== gymToRemove.idGym);
  }
}





mapUserToPupil(user: UserPersonalInfo): PupilPersonalInfo {
  return {
    name: user.name,
    lastName: user.lastName,
    role: user.role,
    email: user.email,
    emailValidated: user.emailValidated,
    phoneNumber: user.phoneNumber,
    weight: user.weight,
    height: user.height,
    dateOfBirth: user.dateOfBirth,
    sex: user.sex,
    bio: user.bio
  };
}

mapUserToTrainer(user: UserPersonalInfo): TrainerPersonalInfo {
  return {
    name: user.name,
    lastName: user.lastName,
    role: user.role,
    email: user.email,
    emailValidated: user.emailValidated,
    phoneNumber: user.phoneNumber,
    bio: user.bio,
    trainingPlanPriceFrom: user.trainingPlanPriceFrom,
    trainingPlanPriceTo: user.trainingPlanPriceTo,
    personalTrainingPriceFrom: user.personalTrainingPriceFrom,
    personalTrainingPriceTo: user.personalTrainingPriceTo,
    trainerGyms: user.trainerGyms
  };
}




}
