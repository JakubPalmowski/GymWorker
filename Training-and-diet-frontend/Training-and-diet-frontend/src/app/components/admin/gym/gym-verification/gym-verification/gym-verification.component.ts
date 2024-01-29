import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { GymUpdate } from 'src/app/models/admin/gym-update.model';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-gym-verification',
  templateUrl: './gym-verification.component.html',
  styleUrls: ['./gym-verification.component.css']
})
export class GymVerificationComponent {

  gymId: string='';
  gym: GymUpdate | undefined;
  @ViewChild('profileForm') profileForm: NgForm | undefined;
  fieldErrors: { [key: string]: string[] } = {};
  successFlag: string = "";
  error: boolean = false;
  showDialog: boolean = false;

  constructor(private route: ActivatedRoute, private adminService: AdminService, private router: Router){

  
  }

  
  ngOnInit(): void {
    this.gymId = this.route.snapshot.params['id'];
    this.adminService.getGymById(this.gymId).subscribe({
      next: gym => {
        if(gym.isAccepted === true){
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

  deleteGym() {
    if (this.gym) {
      this.showDialog = true;
    }
  }
  

  onSubmit() {
    if (this.profileForm?.valid) {
      if(this.gym){
      this.adminService.verifyGym(this.gymId,this.gym).subscribe({
        next: (response) => {
          this.fieldErrors = {}; 
          this.router.navigate(['/admin/gym/list/Pending']);
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
    if(status == "error"){
      setTimeout(() => this.successFlag="", 3000); 
    }
  }

  confirmDelete() {
    if (this.gym) {
      this.adminService.deleteGym(parseInt(this.gymId)).subscribe({
        next: () => {
          this.router.navigate(['/admin/gym/list/Pending']);
        },
        error: (error) => {
          this.successFlag = "error";
          this.showSuccessPopup(this.successFlag);
        }
      });
      this.showDialog = false; 
    }
  }

  cancelDelete() {
    this.showDialog = false; 
  }
}
