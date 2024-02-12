import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { GymDetailsAdmin } from 'src/app/models/admin/gym-details-admin.model';
import { GymUpdate } from 'src/app/models/admin/gym-update.model';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-gym-edit',
  templateUrl: './gym-edit.component.html',
  styleUrls: ['./gym-edit.component.css']
})
export class GymEditComponent implements OnInit {
  
  gymId: string='';
  gym: GymUpdate | undefined;
  @ViewChild('profileForm') profileForm: NgForm | undefined;
  fieldErrors: { [key: string]: string[] } = {};
  successFlag: string = "";
  error: boolean = false;

constructor(private route: ActivatedRoute, private adminService: AdminService) {

  
}



  ngOnInit(): void {
    this.gymId = this.route.snapshot.params['id'];
    this.adminService.getGymById(this.gymId).subscribe({
      next: gym => {
        if(gym.isAccepted === false){
          this.error = true;
        }else{
        this.gym = gym;
        }
      },
      error: err => {
        this.error = true;
      }
    });
  }


  onSubmit() {
    if (this.profileForm?.valid) {
      if(this.gym){
      this.adminService.updateGym(this.gymId,this.gym).subscribe({
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
