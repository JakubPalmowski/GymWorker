import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ExerciseGetById } from 'src/app/models/exercise-get-by-id';
import { ExerciseShort } from 'src/app/models/exercise-short.model';
import { NewTrainingExercise } from 'src/app/models/new-training-exercise.model';
import { ExercisesService } from 'src/app/services/exercises.service';

@Component({
  selector: 'app-edit-training-exercise',
  templateUrl: './edit-training-exercise.component.html',
  styleUrls: ['./edit-training-exercise.component.css']
})
export class EditTrainingExerciseComponent implements OnInit{

  id_training:string='';
  id_exercise:string='';

  newTrainingExerciseRequest:NewTrainingExercise={
    seriesNumber:0,
    repetitionsNumber:'',
    comments:'',
    dayOfWeek:0,
    idExercise:0,
    idTrainingPlan:0
  }

  

  exercise:ExerciseGetById={
    idExercise:0,
    name:''
  };
   
  repetitions:number[]=[];

  submitted=false;
  

  
  constructor(private exerciseServise:ExercisesService, private route:ActivatedRoute,private router:Router){
 
  }
  

     

  ngOnInit(): void {
    this.id_training=this.route.snapshot.queryParams['trainingId'];
    this.id_exercise=this.route.snapshot.queryParams['exerciseId'];
    console.log("tr"+this.id_training);
    console.log("cw"+this.id_exercise);

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
    
    
    this.exerciseServise.addTrainingExercise(this.newTrainingExerciseRequest).subscribe({
      next:(newTrainingExercise)=>{
        this.router.navigate(['/training-plans/edit/'+this.id_training]);
      }
    })

    

  }

  back(){
    this.router.navigateByUrl("/training-plans/edit/3");
  }
}