import { Component, OnInit } from '@angular/core';
import { TrainingPlan } from 'src/app/models/trainingPlan.model';

@Component({
  selector: 'app-training-plans-list',
  templateUrl: './training-plans-list.component.html',
  styleUrls: ['./training-plans-list.component.css']
})
export class TrainingPlansListComponent implements OnInit{
  
  trainingPlans:TrainingPlan[]=[
    {
      id: '1',
      name:' plan tren 1',
      training_duration:'1',
      number_of_exercises:1

      
    },
    {
      id: '2',
      name:' plan tren 2',
      training_duration:'5',
      number_of_exercises:12

      
    },
    {
      id: '3',
      name:' plan tren 3',
      training_duration:'1',
      number_of_exercises:30

      
    },
    {
      id: '4',
      name:' plan tren 4',
      training_duration:'5',
      number_of_exercises:7

      
    }
  ];
  constructor(){}

  ngOnInit(): void {

    
  }
}
