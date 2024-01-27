import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CreateGym } from 'src/app/models/gym/create-gym.model';
import { GymsAddedByUser } from 'src/app/models/gym/gyms-added-by-user.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { GymService } from 'src/app/services/gym.service';

@Component({
  selector: 'app-create-gym',
  templateUrl: './create-gym.component.html',
  styleUrls: ['./create-gym.component.css']
})
export class CreateGymComponent implements OnInit {

  //Komponent dostepny dla Trainer/Dietician/Dietician-Trainer i moze admin
  @ViewChild('profileForm') profileForm: NgForm | undefined;
  GymsAddedByUser: GymsAddedByUser[] | undefined;
  GymToCreate: CreateGym = {
    name: "",
    city: "",
    street: "",
    postalCode: ""
  }
  fieldErrors: { [key: string]: string[] } = {};
  successFlag: string = "";

  constructor(private gymService: GymService, private authenticationService: AuthenticationService) { }

  
  ngOnInit(): void {

    const userId = this.authenticationService.getUserId();
    if(userId){
    this.gymService.GetGymsAddedByUser(userId).subscribe({
      next: (gyms) => {
        this.GymsAddedByUser = gyms;
      },
      error: (response) => {
        console.log(response);
      }
    })
  }
  }
  onSubmit() {
    if (this.profileForm?.valid) {
      if(this.GymToCreate){
      this.gymService.CreateGym(this.GymToCreate).subscribe({
        next: (response) => {
          this.successFlag = "success";
          this.showSuccessPopup(this.successFlag);
          this.fieldErrors = {}; 
          document.documentElement.scrollTop = 0;
          var gym: GymsAddedByUser = {
            ...this.GymToCreate,
            isAccepted: false
          };
          this.GymsAddedByUser?.push(gym);
          this.GymToCreate = { city: "", name: "", postalCode: "", street: ""};
          this.profileForm?.reset();
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
            console.log(error);
          this.successFlag = "error";
          this.showSuccessPopup(this.successFlag);
          document.documentElement.scrollTop = 0;
          this.fieldErrors = {}; 
        }
        }
      })
    }
}else{
  if(this.profileForm){
    Object.keys(this.profileForm.controls).forEach(field => {
      const control = this.profileForm?.controls[field];
      if (control)
      control.markAsTouched({ onlySelf: true });
    });
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


}