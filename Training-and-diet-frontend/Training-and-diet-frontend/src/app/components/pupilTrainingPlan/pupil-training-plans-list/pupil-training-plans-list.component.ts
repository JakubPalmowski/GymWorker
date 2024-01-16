import { Component } from '@angular/core';
import { TrainingPlan } from 'src/app/models/trainingPlan.model';
import { TrainingPlanService } from 'src/app/services/training-plan.service';

@Component({
  selector: 'app-pupil-training-plans-list',
  templateUrl: './pupil-training-plans-list.component.html',
  styleUrls: ['./pupil-training-plans-list.component.css']
})
export class PupilTrainingPlansListComponent {
  
  
  trainingPlans:TrainingPlan[]=[];
  filteredTrainingPlans:TrainingPlan[]=[];

  constructor(private trainingPlanService:TrainingPlanService){}

  ngOnInit(): void {
    this.trainingPlanService.getTrainerPlans().subscribe({
      next:(trainingPlans)=>{
        this.trainingPlans=trainingPlans;
        this.filteredTrainingPlans=this.trainingPlans;
      },
      error: (response)=>{
        console.log(response);
      }
    })
  }

  
}
