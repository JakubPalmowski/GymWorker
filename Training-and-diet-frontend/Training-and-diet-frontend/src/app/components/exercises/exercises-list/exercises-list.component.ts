import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { response } from 'express';
import { ExerciseShort } from 'src/app/models/exercise-short.model';
import { TrainingPlanExercise } from 'src/app/models/trainingPlanExercise.model';
import { ExercisesService } from 'src/app/services/exercises.service';

@Component({
  selector: 'app-exercises-list',
  templateUrl: './exercises-list.component.html',
  styleUrls: ['./exercises-list.component.css']
})
export class ExercisesListComponent implements OnInit{
 
  trainingPlanExercises:ExerciseShort[]=[
   
  ];

  id_training:string='';

  constructor(private exerciseServise:ExercisesService, private route:ActivatedRoute){}

  ngOnInit(): void {
   
    this.id_training=this.route.snapshot.queryParams['id'];
   

      //TODO: 2 oddzielne listy: trenera i wszystkie 
    this.exerciseServise.getTrainerExercises().subscribe({
      next:(trainingPlanExercises)=>{
        this.trainingPlanExercises=trainingPlanExercises;
      },
      error: (response)=>{
        console.log(response);
      }
    })
  }
}
