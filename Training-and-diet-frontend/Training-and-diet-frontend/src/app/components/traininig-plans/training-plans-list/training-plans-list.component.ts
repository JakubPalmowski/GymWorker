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

  constructor(private trainingPlanService:TrainingPlanService, private authenticationService:AuthenticationService){}

  ngOnInit(): void {
    if(this.authenticationService.getUserId()==undefined){
     // TODO return this.authenticationService.logout();
    }
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

  filterResults(text: string) {
    if (!text) {
      this.filteredTrainingPlans = this.trainingPlans;
    }
  
    this.filteredTrainingPlans = this.trainingPlans.filter(
      trainingPlan => trainingPlan?.name.toLowerCase().includes(text.toLowerCase())
    );
  }
}
