import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ExerciseGetById } from 'src/app/models/exercise/exercise-get-by-id.model';
import { ExerciseShort } from 'src/app/models/exercise/exercise-short.model';
import { NewTrainingExercise } from 'src/app/models/training-plan/new-training-exercise.model';
import { ExercisesService } from 'src/app/services/exercises.service';
import { FormGroup, FormControl, FormArray, FormBuilder } from '@angular/forms'  
import { delay, timestamp } from 'rxjs';

@Component({
  selector: 'app-new-training-exercise',
  templateUrl: './new-training-exercise.component.html',
  styleUrls: ['./new-training-exercise.component.css']
})
export class NewTrainingExerciseComponent implements OnInit{

  id_training:string='';
  id_exercise:string='';

  newTrainingExerciseRequest:NewTrainingExercise={
    seriesNumber:0,
    repetitionsNumber:'',
    comments:'',
    dayOfWeek:1,
    idExercise:0,
    idTrainingPlan:0
  }

  

  exercise:ExerciseGetById={
    idExercise:0,
    name:''
  };
   
  repetitions:number[]=[];

  submitted=false;
  fieldErrors: { [key: string]: string[] } = {};
  errorFlag: string = "";

  
  constructor(private exerciseServise:ExercisesService, private route:ActivatedRoute,private router:Router){
 
  }
  

     

  ngOnInit(): void {
    this.id_training=this.route.snapshot.queryParams['trainingId'];
    this.id_exercise=this.route.snapshot.queryParams['exerciseId'];

    this.exerciseServise.getExerciseById(this.id_exercise).subscribe({
      next:(exercise)=>{
        this.exercise=exercise;
        console.log(this.exercise.name);
      },
      error: (response)=>{

        console.log(response);
      }
    })
    
  }

  OnChangeSeriesNumber(seriesNumber:number){
    console.log(seriesNumber.toString());
    console.log(this.newTrainingExerciseRequest.seriesNumber);
    
    this.repetitions.length=this.newTrainingExerciseRequest.seriesNumber;
  
    console.log(this.repetitions);
    
    
  }

  refresh()
  {

  }

  onSubmit(valid:any){
    this.submitted=true;
    if(valid){
      console.log(this.newTrainingExerciseRequest);
      
      this.addTrainingExercise();
    }
  }
  
  assignValue(){
    this.newTrainingExerciseRequest.dayOfWeek=parseInt(this.newTrainingExerciseRequest.dayOfWeek.toString());
  }

  addTrainingExercise(){
    this.newTrainingExerciseRequest.idExercise=parseInt(this.id_exercise);
    this.newTrainingExerciseRequest.idTrainingPlan=parseInt(this.id_training);
    this.newTrainingExerciseRequest.repetitionsNumber=this.repetitions.toString();
    
    this.fieldErrors = {};

    this.exerciseServise.addTrainingExercise(this.newTrainingExerciseRequest).subscribe({
      next:(newTrainingExercise)=>{
        this.router.navigate(['/training-plans/edit/'+this.id_training]);
      },error:(error)=>{
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
    })
  }
  showErrorPopup(status: string) {
    if(status == "error"){
      setTimeout(() => this.errorFlag="", 3000); 
    }
  
  }
}
