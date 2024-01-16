import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { PupilPersonalInfo } from 'src/app/models/MyProfile/pupilPersonalInfo';
import { UserService } from 'src/app/services/user.service';
import { NgForm, NgModel } from '@angular/forms';
import { UserPersonalInfo } from 'src/app/models/MyProfile/userPersonalInfo';
import { TrainerPersonalInfo } from 'src/app/models/MyProfile/trainerPersonalInfo';
import { GymService } from 'src/app/services/gym.service';
import { forkJoin } from 'rxjs';
import { ActiveGym } from 'src/app/models/activeGym';
import { DieticianPersonalInfo } from 'src/app/models/MyProfile/dieticianPersonalInfo';
import { DieticianTrainerPersonalInfo } from 'src/app/models/MyProfile/dieticianTrainerPersonalInfo';


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
@ViewChild('dietPriceTo') dietPriceTo: NgModel | undefined;
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
  this.role = "Dietician-Trainer"
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
    this.userSerive.GetDieticianPersonalInfoById(this.id).subscribe({
      next: (dieticianInfo) => {
        this.user = dieticianInfo;
      },
      error: (response) => {
        console.log(response);
      }
    });
  }
  else if (this.role == "Dietician-Trainer") {
    forkJoin({
      dieticianTrainerInfo: this.userSerive.GetDieticianTrainerPersonalInfoById(this.id),
      gyms: this.gymService.GetAllActiveMentorGyms(this.id),
      allGyms: this.gymService.GetAllActiveGyms()
    }).subscribe({
      next: ({ dieticianTrainerInfo, gyms, allGyms }) => {
        this.user = dieticianTrainerInfo;
        this.allActiveGyms = allGyms;
        if (this.user) {
          this.user.trainerGyms = gyms;
        }
      },
      error: (response) => {
        console.log(response);
      }
    });
  }

}

onSubmit() {
  if (this.profileForm?.valid) {
  if (this.user) {
    if (this.role == "Trainer") {
      const trainerInfo: TrainerPersonalInfo = this.mapUserToTrainer(this.user);
      this.userSerive.UpdateTrainerPersonalInfo(trainerInfo, this.id).subscribe({
        next: (response) => {
          this.successFlag = "success";
          this.fieldErrors = {}; 
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
    const pupilInfo: PupilPersonalInfo = this.mapUserToPupil(this.user);
    this.userSerive.UpdatePupilPersonalInfo(pupilInfo, this.id).subscribe({
      next: (response) => {
        this.successFlag = "success";
        this.showSuccessPopup(this.successFlag);
        this.fieldErrors = {}; 
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
  }else if(this.role=="Dietician"){
    const dieticianInfo: DieticianPersonalInfo = this.mapUserToDietician(this.user);
    this.userSerive.UpdateDieticianPersonalInfo(dieticianInfo, this.id).subscribe({
      next: (response) => {
        this.successFlag = "success";
        this.showSuccessPopup(this.successFlag);
        this.fieldErrors = {}; 
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
  }else if(this.role=="Dietician-Trainer"){
    const dieticianTrainerInfo: DieticianTrainerPersonalInfo = this.mapUserToDieticianTrainer(this.user);
    this.userSerive.UpdateDieticianTrainerPersonalInfo(dieticianTrainerInfo, this.id).subscribe({
      next: (response) => {
        this.successFlag = "success";
        this.showSuccessPopup(this.successFlag);
        this.fieldErrors = {}; 
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
    let dietPricesConsistent = true;

    const dietBothOrNone = (this.user.dietPriceFrom === null && this.user.dietPriceTo === null) ||
                       (this.user.dietPriceFrom !== null && this.user.dietPriceTo !== null);

    const trainingBothOrNone = (this.user.personalTrainingPriceFrom === null && this.user.personalTrainingPriceTo === null) ||
                       (this.user.personalTrainingPriceFrom !== null && this.user.personalTrainingPriceTo !== null);

    const planBothOrNone = (this.user.trainingPlanPriceFrom === null && this.user.trainingPlanPriceTo === null) ||
                       (this.user.trainingPlanPriceFrom !== null && this.user.trainingPlanPriceTo !== null);


    if(this.user.dietPriceFrom != null && this.user.dietPriceTo != null){
      dietPricesConsistent = dietBothOrNone && 
                         (this.user.dietPriceFrom === null || this.user.dietPriceTo >= this.user.dietPriceFrom);
    }

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
    if(!dietBothOrNone){
      if(this.dietPriceTo){
        updateErrors(this.dietPriceTo, 'bothOrNone', true);
      }
    }
    if(!dietPricesConsistent){
      if(this.dietPriceTo){
        updateErrors(this.dietPriceTo, 'pricesConsistent', true);
      }
    }
    if(dietBothOrNone){
      if(this.dietPriceTo){
        updateErrors(this.dietPriceTo, 'bothOrNone', false);
      }
    }
    if(dietPricesConsistent){
      if(this.dietPriceTo){
        updateErrors(this.dietPriceTo, 'pricesConsistent', false);
      }
    }
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
 mapUserToDietician(user: UserPersonalInfo): DieticianPersonalInfo {
  return {
    name: user.name,
    lastName: user.lastName,
    role: user.role,
    email: user.email,
    emailValidated: user.emailValidated,
    phoneNumber: user.phoneNumber,
    bio: user.bio,
    dietPriceFrom: user.dietPriceFrom,
    dietPriceTo: user.dietPriceTo
  };
}

mapUserToDieticianTrainer(user: UserPersonalInfo): DieticianTrainerPersonalInfo {
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
    dietPriceFrom: user.dietPriceFrom,
    dietPriceTo: user.dietPriceTo,
    trainerGyms: user.trainerGyms
  };
}




}
