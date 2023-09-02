import { Component, OnInit } from '@angular/core';
import { TrainingPlanExercise } from 'src/app/models/trainingPlanExercise.model';

@Component({
  selector: 'app-edit-training-plan',
  templateUrl: './edit-training-plan.component.html',
  styleUrls: ['./edit-training-plan.component.css']
})
export class EditTrainingPlanComponent implements OnInit{
 
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
