import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Exercise } from 'src/app/models/exercise';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-exercise-create-admin',
  templateUrl: './exercise-create-admin.component.html',
  styleUrls: ['./exercise-create-admin.component.css']
})
export class ExerciseCreateAdminComponent {

  exercise: Exercise={
    name:'',
    details:'',
    exerciseSteps:'',
    idTrainer:3,
    image:''
  }
  @ViewChild('profileForm') profileForm: NgForm | undefined;
  fieldErrors: { [key: string]: string[] } = {};
  errorFlag: string = "";
  submitted: boolean = false;

  constructor(private adminService: AdminService, private router: Router) { }


  onSubmit() {
    this.submitted = true;
    if (this.profileForm?.valid) {
      this.adminService.createExercise(this.exercise).subscribe({
        next: (response) => {
        this.router.navigate(['/admin/exercise/list']);
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

          } else {
            this.errorFlag = "error";
            this.showErrorPopup(this.errorFlag);
            document.documentElement.scrollTop = 0;
          }
        }
      });
    }
    }

    showErrorPopup(status: string) {
      if(status == "error"){
        setTimeout(() => this.errorFlag="", 3000); 
      }
    
    }

}
