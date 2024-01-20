import { Component, OnInit } from '@angular/core';
import { catchError, forkJoin, of, switchMap } from 'rxjs';
import { PupilPersonalInfo } from 'src/app/models/MyProfile/pupilPersonalInfo';
import { TrainerPersonalInfo } from 'src/app/models/MyProfile/trainerPersonalInfo';
import { UserPersonalInfo } from 'src/app/models/MyProfile/userPersonalInfo';
import { PupilProfile } from 'src/app/models/pupilProfile';
import { FileService } from 'src/app/services/file.service';
import { GymService } from 'src/app/services/gym.service';
import { UserService } from 'src/app/services/user.service';


@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.css']
})
export class MyProfileComponent implements OnInit {


constructor(private userService: UserService, private gymService: GymService, private fileService: FileService) {}

  user: UserPersonalInfo|undefined;
  role:string = "";
  id:string = "";
  imageUrl:string="";


  ngOnInit(): void {
    //Po dodaniu uwierzytelnienia trzeba będzie pobrać dane zalogowanego użytkownika z jwt Tokena
    this.role = "Dietician-Trainer"
    this.id = "3";

    if (this.role == "Pupil") {
      this.userService.GetPupilPersonalInfoById(this.id).subscribe(
        {
          next: (pupilInfo) => {
            if (!pupilInfo) {
              console.log('Wystąpił błąd podczas pobierania danych ucznia.');
              return;
            }
            this.user = pupilInfo;
            if (this.user.imageUri) {
              this.fileService.getImage(this.user.imageUri).subscribe(
                blob => {
                  if (blob) {
                    const objectUrl = URL.createObjectURL(blob);
                    this.imageUrl = objectUrl;
                  }
                },
                error => {
                  this.imageUrl = "assets/images/user.png";
                }
              );
            } else {
              this.imageUrl = "assets/images/user.png";
            }
          },
          error: (response) => {
            console.log('Wystąpił błąd podczas pobierania danych ucznia.', response);
          }
        }
      );
      
    }
    else if (this.role == "Dietician") {
      this.userService.GetDieticianPersonalInfoById(this.id).subscribe({
        next: (dieticianInfo) => {
          if (!dieticianInfo) {
            console.log('Wystąpił błąd podczas pobierania danych ucznia.');
            return;
          }
          this.user = dieticianInfo;
          if (this.user.imageUri) {
            this.fileService.getImage(this.user.imageUri).subscribe(
              blob => {
                if (blob) {
                  const objectUrl = URL.createObjectURL(blob);
                  this.imageUrl = objectUrl;
                }
              },
              error => {
                this.imageUrl = "assets/images/user.png";
              }
            );
          } else {
            this.imageUrl = "assets/images/user.png";
          }
        },
        error: (response) => {
          console.log('Wystąpił błąd podczas pobierania danych ucznia.', response);
        }
      });
    }
    else if (this.role == "Trainer") {
      forkJoin({
        trainerInfo: this.userService.GetTrainerPersonalInfoById(this.id),
        gyms: this.gymService.GetAllActiveMentorGyms(this.id),
      }).pipe(
        switchMap(({ trainerInfo, gyms }) => {
          if (!trainerInfo) {
            throw new Error('Wystąpił błąd podczas pobierania danych.');
          }
          this.user = trainerInfo;
          this.user.trainerGyms = gyms;
          if (this.user && this.user.imageUri) {
            return this.fileService.getImage(this.user.imageUri).pipe(
              catchError(error => {
                this.imageUrl="assets/images/user.png";
                return of(null); 
              })
            );
          } else {
            console.log("tutaj");
            this.imageUrl="assets/images/user.png";
            return of(null);
          }
        }),
      ).subscribe({
        next: (blob) => {
          if (blob) {
            const objectUrl = URL.createObjectURL(blob);
            this.imageUrl = objectUrl;
          }
        },
        error: (response) => {
          console.log('Wystąpił błąd podczas pobierania danych.', response);
        }
      });
    }
    else if (this.role == "Dietician-Trainer") {
      forkJoin({
        dieticianTrainerInfo: this.userService.GetDieticianTrainerPersonalInfoById(this.id),
        gyms: this.gymService.GetAllActiveMentorGyms(this.id),
      }).pipe(
        switchMap(({ dieticianTrainerInfo, gyms }) => {
          if (!dieticianTrainerInfo) {
            throw new Error('Wystąpił błąd podczas pobierania danych.');
          }
          this.user = dieticianTrainerInfo;
          this.user.trainerGyms = gyms;
          if (this.user && this.user.imageUri) {
            return this.fileService.getImage(this.user.imageUri).pipe(
              catchError(error => {
                this.imageUrl="assets/images/user.png";
                return of(null); 
              })
            );
          } else {
            this.imageUrl="assets/images/user.png";
            return of(null);
          }
        }),
      ).subscribe({
        next: (blob) => {
          if (blob) {
            const objectUrl = URL.createObjectURL(blob);
            this.imageUrl = objectUrl;
          }
        },
        error: (response) => {
          console.log('Wystąpił błąd podczas pobierania danych.', response);
        }
      });
}
  }



  formatDate(date: string|undefined): string {
    if (date == undefined) {
      return "";
    }
    return date.split('T')[0];
  }


  

}
