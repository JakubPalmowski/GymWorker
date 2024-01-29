import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ExerciseFull } from 'src/app/models/exercise/exercise-full.model';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-exercise-admin-edit',
  templateUrl: './exercise-admin-edit.component.html',
  styleUrls: ['./exercise-admin-edit.component.css']
})
export class ExerciseAdminEditComponent implements OnInit {

  idExercise: string = '';
  exercise: ExerciseFull | undefined;
  @ViewChild('profileForm') profileForm: NgForm | undefined;
  fieldErrors: { [key: string]: string[] } = {};
  successFlag: string = "";

  constructor(private route: ActivatedRoute, private adminService: AdminService) {

    
  }


  ngOnInit(): void {
    this.idExercise = this.route.snapshot.params['id'];
    this.adminService.getAdminExerciseById(this.idExercise).subscribe({
      next: (response) => {
        this.exercise = response;
      },
      error: (error) => {
        
      }
    });
  }

  onSubmit() {
    if (this.profileForm?.valid) {
      if(this.exercise){
      this.adminService.updateExercise(this.idExercise,this.exercise).subscribe({
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
