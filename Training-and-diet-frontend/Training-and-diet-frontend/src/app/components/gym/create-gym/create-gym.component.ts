import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CreateGym } from 'src/app/models/gym/createGym';
import { GymsAddedByUser } from 'src/app/models/gym/gymsAddedByUser';
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
    postalCode: "",
    addedBy: 3
  }
  fieldErrors: { [key: string]: string[] } = {};
  successFlag: string = "";

  constructor(private gymService: GymService) { }

  
  ngOnInit(): void {
    //Po dodaniu uwierzytelnienia trzeba będzie pobrać dane zalogowanego użytkownika z jwt Tokena
    this.gymService.GetGymsAddedByUser("3").subscribe({
      next: (gyms) => {
        this.GymsAddedByUser = gyms;
      },
      error: (response) => {
        console.log(response);
      }
    })
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
            status: "Pending"
          };
          this.GymsAddedByUser?.push(gym);
          this.GymToCreate = { city: "", name: "", postalCode: "", street: "", addedBy: 3};
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