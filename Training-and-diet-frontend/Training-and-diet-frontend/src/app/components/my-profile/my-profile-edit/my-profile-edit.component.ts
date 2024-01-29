import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { PupilPersonalInfo } from 'src/app/models/my-profile/pupil-personal-info.model';
import { UserService } from 'src/app/services/user.service';
import { NgForm, NgModel } from '@angular/forms';
import { UserPersonalInfo } from 'src/app/models/my-profile/user-personal-info.model';
import { TrainerPersonalInfo } from 'src/app/models/my-profile/trainer-personal-info.model';
import { GymService } from 'src/app/services/gym.service';
import { catchError, forkJoin, iif, of, switchMap, tap, throwError } from 'rxjs';
import { ActiveGym } from 'src/app/models/gym/active-gym.model';
import { DieticianPersonalInfo } from 'src/app/models/my-profile/dietician-personal-info.model';
import { DieticianTrainerPersonalInfo } from 'src/app/models/my-profile/dietician-trainer-personal-info.model';
import { FileService } from 'src/app/services/file.service';
import { AuthenticationService } from 'src/app/services/authentication.service';


@Component({
  selector: 'app-my-profile-edit',
  templateUrl: './my-profile-edit.component.html',
  styleUrls: ['./my-profile-edit.component.css']
})
export class MyProfileEditComponent implements OnInit {


constructor(private userService: UserService, private gymService: GymService, private fileService: FileService, private authenticationService: AuthenticationService) {}

user: UserPersonalInfo|undefined;
role: string |undefined;
id: string ="";
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
    this.id = this.authenticationService.getUserId() ?? "";
if(this.id && this.role){
  if (this.role == "Pupil") {
    this.userService.GetPupilPersonalInfo().subscribe(
      {
        next: (pupilInfo) => {
          this.user = pupilInfo;
          if (this.user.sex == null) {
            this.user.sex = "";
          }
          this.formattedDate = this.formatDate(this.user.dateOfBirth?.toString());
          this.handleImage(this.user.imageUri ?? "");
        },
        error: (response) => {
          console.log('Wystąpił błąd podczas pobierania danych ucznia.', response);
        }
      }
    );
    
  }
  else if (this.role == "Trainer") {
    forkJoin({
      trainerInfo: this.userService.GetTrainerPersonalInfo(),
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
        this.handleImage(this.user.imageUri ?? "");
      
        return of(null); 
      }),
    ).subscribe({
      next: () => {
      },
      error: (error) => {
      }
    });

  }else if (this.role == "Dietician") {
    this.userService.GetDieticianPersonalInfo().subscribe({
      next: (dieticianInfo) => {
        if (!dieticianInfo) {
          throw new Error('Wystąpił błąd podczas pobierania danych.');
        }
        this.user = dieticianInfo;
        this.handleImage(this.user.imageUri ?? "");
      },
      error: (response) => {
      }
    });
  }
  else if (this.role == "Dietician-Trainer") {
    forkJoin({
      dieticianTrainerInfo: this.userService.GetDieticianTrainerPersonalInfo(),
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
        this.handleImage(this.user.imageUri ?? "");
        return of(null);
      }
      )
    ).subscribe({
      next: () => {
      },
      error: (response) => {
      }
    });
  }

}
}

handleImage(imageUri: string) {
  if (imageUri) {
    this.fileService.getFile(imageUri).pipe(
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
}


onSubmit() {
  if (this.profileForm?.valid) {
  if (this.user && this.id) {
    if (this.role == "Trainer") {
      const trainerInfo: TrainerPersonalInfo = this.mapUserToTrainer(this.user);
    const handleImage$ = this.handleImageLogic();

handleImage$.pipe(
  switchMap(() => {
    return this.userService.UpdateTrainerPersonalInfo(trainerInfo);
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
    const handleImage$ = this.handleImageLogic();

handleImage$.pipe(
  switchMap(() => {
    return this.userService.UpdatePupilPersonalInfo(pupilInfo);
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
    const handleImage$ = this.handleImageLogic();

handleImage$.pipe(
  switchMap(() => {
    return this.userService.UpdateDieticianPersonalInfo(dieticianInfo);
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
    const handleImage$ = this.handleImageLogic();

handleImage$.pipe(
  switchMap(() => {
    return this.userService.UpdateDieticianTrainerPersonalInfo(dieticianTrainerInfo);
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




handleImageLogic() {
  return iif(
    () => !!this.imageFile || this.imageDeleted,
    iif(
      () => !!this.user?.imageUri && this.imageDeleted && this.imageFile === null,
      this.fileService.deleteImage(this.user?.imageUri as string).pipe(
        tap((success) => {
          if (success && this.user) {
            this.user.imageUri = undefined; 
            this.userService.notifyUserImageChanged();
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
              if(this.user)
              this.user.imageUri = uploadedImageUri.fileUri;
              this.userService.notifyUserImageChanged();
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
