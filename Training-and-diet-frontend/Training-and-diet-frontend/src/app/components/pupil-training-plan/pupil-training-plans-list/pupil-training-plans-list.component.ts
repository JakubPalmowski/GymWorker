import { Component } from '@angular/core';
import { TrainingPlanPupilList } from 'src/app/models/training-plan/training-plan-pupil-list.model';
import { TrainingPlan } from 'src/app/models/training-plan/training-plan.model';
import { TrainingPlanService } from 'src/app/services/training-plan.service';

@Component({
  selector: 'app-pupil-training-plans-list',
  templateUrl: './pupil-training-plans-list.component.html',
  styleUrls: ['./pupil-training-plans-list.component.css']
})
export class PupilTrainingPlansListComponent {
  
  
  trainingPlans:TrainingPlanPupilList[]=[];
  filteredTrainingPlans:TrainingPlanPupilList[]=[];

  constructor(private trainingPlanService:TrainingPlanService){}

  ngOnInit(): void {
    this.trainingPlanService.getPupilPlans().subscribe({
      next:(trainingPlans)=>{
        this.trainingPlans=trainingPlans;
        this.filteredTrainingPlans=this.trainingPlans;
        
      },
      error: (response)=>{
      }
    })
  }

  getEndDate(date:Date){
    return new Date(date).toISOString().split("T")[0];
  }
}
