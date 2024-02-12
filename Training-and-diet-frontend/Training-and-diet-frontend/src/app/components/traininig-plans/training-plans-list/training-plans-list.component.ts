import { Component, OnInit } from '@angular/core';
import { TrainingPlan } from 'src/app/models/training-plan/training-plan.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { TrainingPlanService } from 'src/app/services/training-plan.service';


@Component({
  selector: 'app-training-plans-list',
  templateUrl: './training-plans-list.component.html',
  styleUrls: ['./training-plans-list.component.css']
})
export class TrainingPlansListComponent implements OnInit{
  
  trainingPlans:TrainingPlan[]=[];
  filteredTrainingPlans:TrainingPlan[]=[];
  searchTerm: string = '';

  constructor(private trainingPlanService:TrainingPlanService, private authenticationService:AuthenticationService){}

  ngOnInit(): void {
    if(this.authenticationService.getUserId()==undefined){
    }
    this.trainingPlanService.getTrainerPlans().subscribe({
      next:(trainingPlans)=>{
        this.trainingPlans=trainingPlans;
        this.filteredTrainingPlans=this.trainingPlans;
      },
      error: (response)=>{
      }
    })
  }

  filterResults() {
    if (!this.searchTerm) {
      this.filteredTrainingPlans = this.trainingPlans; 
    } else {
      this.filteredTrainingPlans = this.trainingPlans?.filter(plan =>
        plan.name.toLowerCase().includes(this.searchTerm.toLowerCase())
      );
    }
  }

  getEndDate(date:Date){
    return new Date(date).toISOString().split("T")[0];
  }
}
