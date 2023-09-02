import { Component, OnInit } from '@angular/core';
import { TrainingPlan } from 'src/app/models/trainingPlan.model';
import { TrainingPlanService } from 'src/app/services/training-plan.service';

@Component({
  selector: 'app-training-plans-list',
  templateUrl: './training-plans-list.component.html',
  styleUrls: ['./training-plans-list.component.css']
})
export class TrainingPlansListComponent implements OnInit{
  
  trainingPlans:TrainingPlan[]=[];
  constructor(private trainingPlanService:TrainingPlanService){}

  ngOnInit(): void {
    this.trainingPlanService.getTrainerPlans().subscribe({
      next:(trainingPlans)=>{
        this.trainingPlans=trainingPlans;
      },
      error: (response)=>{
        console.log(response);
      }
    })
    
  }
}
