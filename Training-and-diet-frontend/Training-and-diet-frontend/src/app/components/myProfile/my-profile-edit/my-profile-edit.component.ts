import { Component, OnInit, ViewChild } from '@angular/core';
import { PupilPersonalInfo } from 'src/app/models/MyProfile/pupilPersonalInfo';
import { UserService } from 'src/app/services/user.service';
import { NgForm } from '@angular/forms';
import { UserPersonalInfo } from 'src/app/models/MyProfile/userPersonalInfo';
import { TrainerPersonalInfo } from 'src/app/models/MyProfile/trainerPersonalInfo';
import { GymService } from 'src/app/services/gym.service';
import { forkJoin } from 'rxjs';


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
  this.id = "5";

  if (this.role == "Pupil") {
    this.userSerive.GetPupilPersonalInfoById(this.id).subscribe(
      {
        next:(pupilInfo)=>{
          this.user=pupilInfo;
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
      gyms: this.gymService.GetAllMentorGyms(this.id)
    }).subscribe({
      next: ({ trainerInfo, gyms }) => {
        this.user = trainerInfo;
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
    if (this.user.role == "Trainer") {
      let trainerInfo: TrainerPersonalInfo = this.mapUserToTrainer(this.user);
      this.userSerive.UpdateTrainerPersonalInfo(this.user, this.id).subscribe({
        next: (response) => {
          this.successFlag = "success";
          this.showSuccessPopup(this.successFlag);
        },
        error: (error) => {
          this.successFlag = "error";
          this.showSuccessPopup(this.successFlag);
        }
      });
    }else if (this.user.role == "Pupil") {
    this.user.dateOfBirth = new Date(this.formattedDate);
    let pupilInfo: PupilPersonalInfo = this.mapUserToPupil(this.user);
    this.userSerive.UpdatePupilPersonalInfo(this.user, this.id).subscribe({
      next: (response) => {
        this.successFlag = "success";
        this.showSuccessPopup(this.successFlag);
      },
      error: (error) => {
        this.successFlag = "error";
        this.showSuccessPopup(this.successFlag);
      }
    });
  }
  }
  document.documentElement.scrollTop = 0;
}

}

formatDate(date: string|undefined): string {
  if (date == undefined) {
    return "";
  }
  return date.split('T')[0];
}

showSuccessPopup(status: string) {
  if (status == "success") {
    setTimeout(() => this.successFlag="", 3000); 
  }
  if(status == "error"){
    setTimeout(() => this.successFlag="", 3000); 
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

validateTrainingPlanPrices() {
  if (this.user) {
    const from = this.user.trainingPlanPriceFrom;
    const to = this.user.trainingPlanPriceTo;
    if ((from === null || from === undefined || from.toString() === '') && (to === null || to === undefined || to.toString() === '')) {
      return false;
    }
    if ((from !== null && from !== undefined && from.toString() !== '') && (to !== null && to !== undefined && to.toString() !== '')) {
      return false;
    }
    return true;
  }
  return false;
}


}
