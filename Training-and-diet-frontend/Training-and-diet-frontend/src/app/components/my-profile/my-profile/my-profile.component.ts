import { Component, OnInit } from '@angular/core';
import { catchError, forkJoin, map, of, switchMap } from 'rxjs';
import { PupilPersonalInfo } from 'src/app/models/my-profile/pupil-personal-info.model';
import { TrainerPersonalInfo } from 'src/app/models/my-profile/trainer-personal-info.model';
import { UserPersonalInfo } from 'src/app/models/my-profile/user-personal-info.model';
import { PupilProfile } from 'src/app/models/mentor-pupil/pupil-profile.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { CertificateService } from 'src/app/services/certificate.service';
import { FileService } from 'src/app/services/file.service';
import { GymService } from 'src/app/services/gym.service';
import { UserService } from 'src/app/services/user.service';


@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.css']
})
export class MyProfileComponent implements OnInit {


constructor(private userService: UserService, private gymService: GymService, private fileService: FileService, private certificateService: CertificateService, private authenticationService: AuthenticationService) {}

  user: UserPersonalInfo|undefined;
  role:string|undefined;
  id:string|undefined;
  imageUrl:string="";


  ngOnInit(): void {

    const role = this.authenticationService.getRole();
    switch(role){
      case "2":
        this.role = "Pupil";
        break;
      case "3":
        this.role = "Trainer";
        break;
      case "4":
        this.role = "Dietician";
        break;
      case "5":
        this.role = "Dietician-Trainer";
        break;
    }
    this.id = this.authenticationService.getUserId();

    if(this.id){
    if (this.role == "Pupil") {
      this.userService.GetPupilPersonalInfo().subscribe(
        {
          next: (pupilInfo) => {
            this.user = pupilInfo;
            if (this.user.imageUri) {
              this.fileService.getFile(this.user.imageUri).subscribe({
                next: (blob) => {
                  if (blob) {
                    const objectUrl = URL.createObjectURL(blob);
                    this.imageUrl = objectUrl;
                  }
                },
                error: () => {
                  this.imageUrl = "assets/images/user.png";
                }
              }
              );
            } else {
              this.imageUrl = "assets/images/user.png";
            }
          }
        }
      );
      
    }
    else if (this.role == "Dietician") {
      forkJoin({
        dieticianInfo: this.userService.GetDieticianPersonalInfo(),
        certificates: this.certificateService.GetUserCertificates()
      }).pipe(
        switchMap(({ dieticianInfo, certificates }) => {

          this.user = dieticianInfo;
          this.user.certificates = certificates; 
      
          const fileRequests = certificates.map(certificate => 
            this.fileService.getFile(certificate.pdfUri).pipe(
              catchError(error => {
                return of(null);
              })
            )
          );
      
          if (this.user && this.user.imageUri) {
            fileRequests.push(this.fileService.getFile(this.user.imageUri).pipe(
              catchError(error => {
                this.imageUrl = "assets/images/user.png";
                return of(null); 
              })
            ));
          } else {
            this.imageUrl = "assets/images/user.png";
          }
      
          return forkJoin(fileRequests);
        }),
      ).subscribe({
        next: (responses) => {
          if(this.user && responses) {
            const blobs = this.user.imageUri ? responses.slice(0, -1) : responses;
            blobs.forEach((blob, index) => {
              if (blob && this.user) {
                const objectUrl = URL.createObjectURL(blob);
                this.user.certificates[index].pdfUrl = objectUrl; 
              }
            });
      
            if (this.user.imageUri) {
              const imageBlob = responses[responses.length - 1];
              if (imageBlob) {
                const objectUrl = URL.createObjectURL(imageBlob);
                this.imageUrl = objectUrl;
              }
            }
          }
        }
      });
      
    }
    else if (this.role == "Trainer") {
      forkJoin({
        trainerInfo: this.userService.GetTrainerPersonalInfo(),
        gyms: this.gymService.GetAllActiveMentorGyms(this.id),
        certificates: this.certificateService.GetUserCertificates() 
      }).pipe(
        switchMap(({ trainerInfo, gyms, certificates }) => {
          this.user = trainerInfo;
          this.user.trainerGyms = gyms;
          this.user.certificates = certificates; 
      
          const fileRequests = certificates.map(certificate => 
            this.fileService.getFile(certificate.pdfUri).pipe(
              catchError(error => {
                return of(null);
              })
            )
          );
      
          if (this.user && this.user.imageUri) {
            fileRequests.push(this.fileService.getFile(this.user.imageUri).pipe(
              catchError(error => {
                this.imageUrl = "assets/images/user.png";
                return of(null); 
              })
            ));
          } else {
            this.imageUrl = "assets/images/user.png";
          }
      
          return forkJoin(fileRequests);
        }),
      ).subscribe({
        next: (responses) => {
          if(this.user && responses) {
            const blobs = this.user.imageUri ? responses.slice(0, -1) : responses; 
            blobs.forEach((blob, index) => {
              if (blob && this.user) {
                const objectUrl = URL.createObjectURL(blob);
                this.user.certificates[index].pdfUrl = objectUrl; 
              }
            });
      
            if (this.user.imageUri) {
              const imageBlob = responses[responses.length - 1]; 
              if (imageBlob) {
                const objectUrl = URL.createObjectURL(imageBlob);
                this.imageUrl = objectUrl;
              }
            }
          }
        }
      });      
    }
    else if (this.role == "Dietician-Trainer") {
      forkJoin({
        dieticianTrainerInfo: this.userService.GetDieticianTrainerPersonalInfo(),
        gyms: this.gymService.GetAllActiveMentorGyms(this.id),
        certificates: this.certificateService.GetUserCertificates()
      }).pipe(
        switchMap(({ dieticianTrainerInfo, gyms, certificates }) => {
          this.user = dieticianTrainerInfo;
          this.user.trainerGyms = gyms;
          this.user.certificates = certificates;
      
          const fileRequests = certificates.map(certificate => 
            this.fileService.getFile(certificate.pdfUri).pipe(
              catchError(error => {
                return of(null); 
              })
            )
          );
      
          if (this.user && this.user.imageUri) {
            fileRequests.push(this.fileService.getFile(this.user.imageUri).pipe(
              catchError(error => {
                this.imageUrl = "assets/images/user.png";
                return of(null); 
              })
            ));
          } else {
            this.imageUrl = "assets/images/user.png";
          }
      
          return forkJoin(fileRequests);
        }),
      ).subscribe({
        next: (responses) => {
          if(this.user && responses) {
            const blobs = this.user.imageUri ? responses.slice(0, -1) : responses; 
            blobs.forEach((blob, index) => {
              if (blob && this.user) {
                const objectUrl = URL.createObjectURL(blob);
                this.user.certificates[index].pdfUrl = objectUrl; 
              }
            });
      
            if (this.user.imageUri) {
              const imageBlob = responses[responses.length - 1];
              if (imageBlob) {
                const objectUrl = URL.createObjectURL(imageBlob);
                this.imageUrl = objectUrl;
              }
            }
          }
        }
      });
      
    }   
  }   
  }

 





  

}
