import { Component, OnInit } from '@angular/core';
import { TrainingPlanExercise } from 'src/app/models/trainingPlanExercise.model';

@Component({
  selector: 'app-exercises-list',
  templateUrl: './exercises-list.component.html',
  styleUrls: ['./exercises-list.component.css']
})
export class ExercisesListComponent implements OnInit{
 
  trainingPlanExercises:TrainingPlanExercise[]=[
    {
      id:1,
      name:'przysiady'
    }
  ];

  constructor(){}

  ngOnInit(): void {
    
  }
}
