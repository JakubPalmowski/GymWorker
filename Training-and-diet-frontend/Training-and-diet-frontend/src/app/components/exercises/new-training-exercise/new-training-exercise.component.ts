import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ExerciseGetById } from 'src/app/models/exercise-get-by-id';
import { ExerciseShort } from 'src/app/models/exercise-short.model';
import { NewTrainingExercise } from 'src/app/models/new-training-exercise.model';
import { ExercisesService } from 'src/app/services/exercises.service';

@Component({
  selector: 'app-new-training-exercise',
  templateUrl: './new-training-exercise.component.html',
  styleUrls: ['./new-training-exercise.component.css']
})
export class NewTrainingExerciseComponent implements OnInit{

  id_training:string='';
  id_exercise:string='';

  newTrainingExerciseRequest:NewTrainingExercise={
    series_Number:0,
    repetitions_number:0,
    comments:'',
    date:new Date(),
    id_Exercise:0,
    id_Training_plan:0
  }

  exercise:ExerciseGetById={
    idExercise:0,
    name:''
  };
   

  
  constructor(private exerciseServise:ExercisesService, private route:ActivatedRoute,private router:Router){}
  

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

  addTrainingExercise(){
    this.newTrainingExerciseRequest.id_Exercise=parseInt(this.id_exercise);
    this.newTrainingExerciseRequest.id_Training_plan=parseInt(this.id_training);
    console.log(this.newTrainingExerciseRequest);
    this.exerciseServise.addTrainingExercise(this.newTrainingExerciseRequest).subscribe({
      next:(newTrainingExercise)=>{
        this.router.navigate(['/training-plans/edit/'+this.id_training]);
      }
    })

  }
}
