import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Exercise } from 'src/app/models/exercise/exercise.model';
import { ExercisesService } from 'src/app/services/exercises.service';
import { Location } from '@angular/common';
import { PreviousUrlService } from 'src/app/services/previous-url.service';
import {FormGroup,FormControl, FormsModule} from '@angular/forms';
import { from } from 'rxjs';


@Component({
  selector: 'app-exercises-add',
  templateUrl: './exercises-add.component.html',
  styleUrls: ['./exercises-add.component.css']
})
export class ExercisesAddComponent implements OnInit{

  submitted=false;
  fieldErrors: { [key: string]: string[] } = {};
  errorFlag: string = "";
  previousUrl:string='';

  addTrainerExerciseRequest: Exercise={
    name:'',
    details:'',
    exerciseSteps:'',
    idTrainer:3,
  }
  
  
 
  constructor(private exerciseService: ExercisesService, private router:Router, private location:Location,private previousUrlService: PreviousUrlService) {
    
  }
  ngOnInit(): void {
    this.previousUrl=this.previousUrlService.getPreviousUrl()
  }

  addTrainerExercise(){
 
    this.fieldErrors = {};

    this.exerciseService.addTrainerExercise(this.addTrainerExerciseRequest).subscribe({
      next:(exercise)=>{
        this.router.navigateByUrl(this.previousUrl);
      },
      error: (error)=>{
        console.log(error);
        if(error.status===400){
         const {errors} = error.error;
         for(const key in errors){
           if(errors.hasOwnProperty(key)){
             this.fieldErrors[key] = errors[key]; 
           }
         }
        }else{
             this.errorFlag = "error";
             this.showErrorPopup(this.errorFlag);
             document.documentElement.scrollTop = 0;
        }
      }
    });
    
   
  }

  showErrorPopup(status: string) {
    if(status == "error"){
      setTimeout(() => this.errorFlag="", 3000); 
    }
  
  }

  onSubmit(valid:any){
    this.submitted=true;
    if(valid){
      this.addTrainerExercise();
      console.log(this.addTrainerExerciseRequest);
    }
    
  }

  back(){
    this.router.navigateByUrl(this.previousUrl);
  }

}
