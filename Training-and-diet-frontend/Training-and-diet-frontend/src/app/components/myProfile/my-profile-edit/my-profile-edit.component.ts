import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { PupilPersonalInfo } from 'src/app/models/MyProfile/pupilPersonalInfo';
import { UserService } from 'src/app/services/user.service';
import { NgForm, NgModel } from '@angular/forms';
import { UserPersonalInfo } from 'src/app/models/MyProfile/userPersonalInfo';
import { TrainerPersonalInfo } from 'src/app/models/MyProfile/trainerPersonalInfo';
import { GymService } from 'src/app/services/gym.service';
import { catchError, forkJoin, iif, of, switchMap, tap, throwError } from 'rxjs';
import { ActiveGym } from 'src/app/models/gym/activeGym';
import { DieticianPersonalInfo } from 'src/app/models/MyProfile/dieticianPersonalInfo';
import { DieticianTrainerPersonalInfo } from 'src/app/models/MyProfile/dieticianTrainerPersonalInfo';
import { FileService } from 'src/app/services/file.service';


@Component({
  selector: 'app-my-profile-edit',
  templateUrl: './my-profile-edit.component.html',
  styleUrls: ['./my-profile-edit.component.css']
})
export class MyProfileEditComponent implements OnInit {


constructor(private userService: UserService, private gymService: GymService, private fileService: FileService) {}

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
newImageUrl: string | ArrayBuffer | null = null;
imageUrl:string="";
imageFile: File | null = null;
imageDeleted: boolean = false;

onFileSelected(event:any) {
  const file = event.target.files[0];
  this.imageDeleted = false;
  this.imageFile = event.target.files[0];
  if (file) {
    const reader = new FileReader();
    reader.onload = e => this.newImageUrl = reader.result;
    reader.readAsDataURL(file);
  }
}

deleteImage(){
  if(this.user?.imageUri){
  this.imageDeleted = true;
  this.newImageUrl = "assets/images/user.png";
  this.imageFile = null;
  }
  if(this.imageFile){
    this.newImageUrl = "assets/images/user.png";
    this.imageFile = null;
  }
}


ngOnInit(): void {
  //Po dodaniu uwierzytelnienia trzeba będzie pobrać dane zalogowanego użytkownika z jwt Tokena
  this.role = "Dietician-Trainer"
  this.id = "1";

  if (this.role == "Pupil") {
    this.userService.GetPupilPersonalInfoById(this.id).subscribe(
      {
        next: (pupilInfo) => {
          this.user = pupilInfo;
          if (this.user.sex == null) {
            this.user.sex = "";
          }
          this.formattedDate = this.formatDate(this.user.dateOfBirth?.toString());
          if (this.user.imageUri) {
            this.fileService.getImage(this.user.imageUri).pipe(
              catchError(error => {
                this.imageUrl = "assets/images/user.png";
                return of(null); 
              })
            ).subscribe(blob => {
              if (blob) {
                const objectUrl = URL.createObjectURL(blob);
                this.imageUrl = objectUrl;
              }
            });
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
  else if (this.role == "Trainer") {
    forkJoin({
      trainerInfo: this.userService.GetTrainerPersonalInfoById(this.id),
      gyms: this.gymService.GetAllActiveMentorGyms(this.id),
      allGyms: this.gymService.GetAllActiveGyms()
    }).pipe(
      switchMap(({ trainerInfo, gyms, allGyms }) => {
        if (!trainerInfo) {
          throw new Error('Wystąpił błąd podczas pobierania danych.');
        }
        this.user = trainerInfo;
        this.user.trainerGyms = gyms;
        this.allActiveGyms = allGyms;
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
  }else if (this.role == "Dietician") {
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
  else if (this.role == "Dietician-Trainer") {
    forkJoin({
      dieticianTrainerInfo: this.userService.GetDieticianTrainerPersonalInfoById(this.id),
      gyms: this.gymService.GetAllActiveMentorGyms(this.id),
      allGyms: this.gymService.GetAllActiveGyms()
    }).pipe(
      switchMap(({ dieticianTrainerInfo, gyms, allGyms }) => {
        if (!dieticianTrainerInfo) {
          throw new Error('Wystąpił błąd podczas pobierania danych.');
        }
        this.user = dieticianTrainerInfo;
        this.user.trainerGyms = gyms;
        this.allActiveGyms = allGyms;
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

onSubmit() {
  if (this.profileForm?.valid) {
  if (this.user) {
    if (this.role == "Trainer") {
      const trainerInfo: TrainerPersonalInfo = this.mapUserToTrainer(this.user);
    const handleImage$ = iif(
      () => !!this.imageFile || this.imageDeleted,
      iif(
        () => !!trainerInfo.imageUri,
        this.fileService.deleteImage(trainerInfo.imageUri as string).pipe(
          tap((success) => {
            if (success) {
              trainerInfo.imageUri = undefined; 
            }
          }),
          catchError(error => {
            return throwError(() => error);
          })
        ),
        of(null) 
      ).pipe(
        switchMap(() => {
          if (this.imageFile) {
            return this.fileService.uploadImage(this.imageFile).pipe(
              tap((uploadedImageUri) => {
                trainerInfo.imageUri = uploadedImageUri.fileUri;
                if(this.user)
                this.user.imageUri = uploadedImageUri.fileUri;
              })
            );
          } else {
            return of(null);
          }
        }),
        catchError(error => {
          return throwError(() => error); 
        })
      ),
      of(null) 
    );

handleImage$.pipe(
  switchMap(() => {
    return this.userService.UpdateTrainerPersonalInfo(trainerInfo, this.id);
  }),
  catchError(error => {
    if (error.status === 400) {
      const { errors } = error.error;
      this.fieldErrors = {}; 

      for (const key in errors) {
        if (errors.hasOwnProperty(key)) {
          this.fieldErrors[key] = errors[key]; 
        }
      }
      console.log(error.error);
    } else {
      this.successFlag = "error";
      this.showSuccessPopup(this.successFlag);
      document.documentElement.scrollTop = 0;
      this.fieldErrors = {}; 
    }
    return throwError(() => error); 
  })
).subscribe({
  next: (response) => {
    this.successFlag = "success";
    this.showSuccessPopup(this.successFlag);
    this.fieldErrors = {}; 
    document.documentElement.scrollTop = 0;
  },
  error: (error) => {
    return throwError(() => error); 
  }
});
 
    }else if (this.role == "Pupil") {
    this.user.dateOfBirth = new Date(this.formattedDate);
    const pupilInfo: PupilPersonalInfo = this.mapUserToPupil(this.user);
    const handleImage$ = iif(
      () => !!this.imageFile || this.imageDeleted,
      iif(
        () => !!pupilInfo.imageUri,
        this.fileService.deleteImage(pupilInfo.imageUri as string).pipe(
          tap((success) => {
            if (success) {
              pupilInfo.imageUri = undefined; 
            }
          }),
          catchError(error => {
            return throwError(() => error);
          })
        ),
        of(null) 
      ).pipe(
        switchMap(() => {
          if (this.imageFile) {
            return this.fileService.uploadImage(this.imageFile).pipe(
              tap((uploadedImageUri) => {
                pupilInfo.imageUri = uploadedImageUri.fileUri;
                if(this.user)
                this.user.imageUri = uploadedImageUri.fileUri;
              })
            );
          } else {
            return of(null);
          }
        }),
        catchError(error => {
          return throwError(() => error); 
        })
      ),
      of(null) 
    );

handleImage$.pipe(
  switchMap(() => {
    return this.userService.UpdatePupilPersonalInfo(pupilInfo, this.id);
  }),
  catchError(error => {
    if (error.status === 400) {
      const { errors } = error.error;
      this.fieldErrors = {}; 

      for (const key in errors) {
        if (errors.hasOwnProperty(key)) {
          this.fieldErrors[key] = errors[key]; 
        }
      }
      console.log(error.error);
    } else {
      this.successFlag = "error";
      this.showSuccessPopup(this.successFlag);
      document.documentElement.scrollTop = 0;
      this.fieldErrors = {}; 
    }
    return throwError(() => error); 
  })
).subscribe({
  next: (response) => {
    this.successFlag = "success";
    this.showSuccessPopup(this.successFlag);
    this.fieldErrors = {}; 
    document.documentElement.scrollTop = 0;
  },
  error: (error) => {
    return throwError(() => error); 
  }
});
  }else if(this.role=="Dietician"){
    const dieticianInfo: DieticianPersonalInfo = this.mapUserToDietician(this.user);
    const handleImage$ = iif(
      () => !!this.imageFile || this.imageDeleted,
      iif(
        () => !!dieticianInfo.imageUri,
        this.fileService.deleteImage(dieticianInfo.imageUri as string).pipe(
          tap((success) => {
            if (success) {
              dieticianInfo.imageUri = undefined; 
            }
          }),
          catchError(error => {
            return throwError(() => error);
          })
        ),
        of(null) 
      ).pipe(
        switchMap(() => {
          if (this.imageFile) {
            return this.fileService.uploadImage(this.imageFile).pipe(
              tap((uploadedImageUri) => {
                dieticianInfo.imageUri = uploadedImageUri.fileUri;
                if(this.user)
                this.user.imageUri = uploadedImageUri.fileUri;
              })
            );
          } else {
            return of(null);
          }
        }),
        catchError(error => {
          return throwError(() => error); 
        })
      ),
      of(null) 
    );

handleImage$.pipe(
  switchMap(() => {
    return this.userService.UpdateDieticianPersonalInfo(dieticianInfo, this.id);
  }),
  catchError(error => {
    if (error.status === 400) {
      const { errors } = error.error;
      this.fieldErrors = {}; 

      for (const key in errors) {
        if (errors.hasOwnProperty(key)) {
          this.fieldErrors[key] = errors[key]; 
        }
      }
      console.log(error.error);
    } else {
      this.successFlag = "error";
      this.showSuccessPopup(this.successFlag);
      document.documentElement.scrollTop = 0;
      this.fieldErrors = {}; 
    }
    return throwError(() => error); 
  })
).subscribe({
  next: (response) => {
    this.successFlag = "success";
    this.showSuccessPopup(this.successFlag);
    this.fieldErrors = {}; 
    document.documentElement.scrollTop = 0;
  },
  error: (error) => {
    return throwError(() => error); 
  }
});
  }else if(this.role=="Dietician-Trainer"){
    const dieticianTrainerInfo: DieticianTrainerPersonalInfo = this.mapUserToDieticianTrainer(this.user);
    const handleImage$ = iif(
      () => !!this.imageFile || this.imageDeleted,
      iif(
        () => !!dieticianTrainerInfo.imageUri,
        this.fileService.deleteImage(dieticianTrainerInfo.imageUri as string).pipe(
          tap((success) => {
            if (success) {
              console.log(dieticianTrainerInfo.imageUri as string)
              dieticianTrainerInfo.imageUri = undefined; 
            }
          }),
          catchError(error => {
            return throwError(() => error);
          })
        ),
        of(null) 
      ).pipe(
        switchMap(() => {
          if (this.imageFile) {
            return this.fileService.uploadImage(this.imageFile).pipe(
              tap((uploadedImageUri) => {
                dieticianTrainerInfo.imageUri = uploadedImageUri.fileUri;
                if(this.user)
                this.user.imageUri = uploadedImageUri.fileUri;
              })
            );
          } else {
            return of(null);
          }
        }),
        catchError(error => {
          console.error('Error during image operations', error);
          return throwError(() => error); 
        })
      ),
      of(null)
    );

handleImage$.pipe(
  switchMap(() => {
    return this.userService.UpdateDieticianTrainerPersonalInfo(dieticianTrainerInfo, this.id);
  }),
  catchError(error => {
    if (error.status === 400) {
      const { errors } = error.error;
      this.fieldErrors = {}; 

      for (const key in errors) {
        if (errors.hasOwnProperty(key)) {
          this.fieldErrors[key] = errors[key]; 
        }
      }
      console.log(error.error);
    } else {
      this.successFlag = "error";
      this.showSuccessPopup(this.successFlag);
      document.documentElement.scrollTop = 0;
      this.fieldErrors = {}; 
    }
    return throwError(() => error);
  })
).subscribe({
  next: (response) => {
    this.successFlag = "success";
    this.showSuccessPopup(this.successFlag);
    this.fieldErrors = {}; 
    document.documentElement.scrollTop = 0;
  },
  error: (error) => {
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
    weight: user.weight,
    height: user.height,
    dateOfBirth: user.dateOfBirth,
    sex: user.sex,
    bio: user.bio,
    imageUri: user.imageUri
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
    trainerGyms: user.trainerGyms,
    imageUri: user.imageUri
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
    dietPriceTo: user.dietPriceTo,
    imageUri: user.imageUri
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
    trainerGyms: user.trainerGyms,
    imageUri: user.imageUri
  };
}




}
