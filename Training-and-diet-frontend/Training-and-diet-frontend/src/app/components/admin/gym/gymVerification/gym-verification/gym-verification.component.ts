import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { GymUpdate } from 'src/app/models/admin/gymUpdate';
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

  constructor(private route: ActivatedRoute, private adminService: AdminService, private router: Router){

  
  }

  
  ngOnInit(): void {
    this.gymId = this.route.snapshot.params['id'];
    this.adminService.getGymById(this.gymId).subscribe({
      next: gym => {
        if(gym.status === "Active"){
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

  deleteGym(gymId: string) {

    if (this.gym) {
      const confirmDelete = confirm(`Czy na pewno chcesz usunąć siłownię:\nNazwa: ${this.gym.name}\nMiasto: ${this.gym.city}\nUlica: ${this.gym.street}`);
      
      if (confirmDelete) {
        this.adminService.deleteGym(parseFloat(gymId)).subscribe({
          next: () => {
            alert('Siłownia została usunięta.');
            this.router.navigate(['/adminGymList/Pending']); 
          },
          error: err => {
            alert('Wystąpił błąd podczas usuwania. Siłownia nie została usunięta.');
          }
        });
      }
    }
  }
  

  onSubmit() {
    if (this.profileForm?.valid) {
      if(this.gym){
      this.adminService.verifyGym(this.gymId,this.gym).subscribe({
        next: (response) => {
          this.successFlag = "success";
          this.showSuccessPopup(this.successFlag);
          this.fieldErrors = {}; 
          alert('Siłownia została zweryfikowana.');
          this.router.navigate(['/adminGymList/Pending']);
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
