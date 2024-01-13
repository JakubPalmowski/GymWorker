import { Component, OnInit } from '@angular/core';
import { forkJoin } from 'rxjs';
import { PupilPersonalInfo } from 'src/app/models/MyProfile/pupilPersonalInfo';
import { TrainerPersonalInfo } from 'src/app/models/MyProfile/trainerPersonalInfo';
import { UserPersonalInfo } from 'src/app/models/MyProfile/userPersonalInfo';
import { PupilProfile } from 'src/app/models/pupilProfile';
import { GymService } from 'src/app/services/gym.service';
import { UserService } from 'src/app/services/user.service';


@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.css']
})
export class MyProfileComponent implements OnInit {


constructor(private userSerive: UserService, private gymService: GymService) {}

  user: UserPersonalInfo|undefined;
  role:string = "";
  id:string = "";


  ngOnInit(): void {
    //Po dodaniu uwierzytelnienia trzeba będzie pobrać dane zalogowanego użytkownika z jwt Tokena
    this.role = "Trainer"
    this.id = "5";

    if (this.role == "Pupil") {
      this.userSerive.GetPupilPersonalInfoById(this.id).subscribe(
        {
          next:(pupilInfo)=>{
            this.user=pupilInfo;
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


  formatDate(date: string|undefined): string {
    if (date == undefined) {
      return "";
    }
    return date.split('T')[0];
  }


  

}
