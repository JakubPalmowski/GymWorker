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
 
    
    this.exerciseService.addTrainerExercise(this.addTrainerExerciseRequest).subscribe({
      next:(exercise)=>{
        this.router.navigateByUrl(this.previousUrl);
      },
      error: (response)=>{
        console.log(response);
      }
    });
    
   
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
