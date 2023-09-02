import { Component, OnInit } from '@angular/core';
import { TrainingPlan } from 'src/app/models/trainingPlan.model';

@Component({
  selector: 'app-training-plans-list',
  templateUrl: './training-plans-list.component.html',
  styleUrls: ['./training-plans-list.component.css']
})
export class TrainingPlansListComponent implements OnInit{
  
  trainingPlans:TrainingPlan[]=[];
  constructor(){}

  ngOnInit(): void {

    
  }
}
