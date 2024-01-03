import { Component,OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { NewTrainingPlan } from 'src/app/models/new-training-plan.model';
import { TrainingPlanService } from 'src/app/services/training-plan.service';


@Component({
  selector: 'app-add-training-plan',
  templateUrl: './add-training-plan.component.html',
  styleUrls: ['./add-training-plan.component.css']
})
export class AddTrainingPlanComponent implements OnInit{
  
  addTrainingPlanRequest: NewTrainingPlan={
    idTrainingPlan:0,
    idTrainer:1,
    name:'',
    type:'',
    startDate:new Date(),
    endDate:new Date(),

  }
  constructor(private trainingPlanService:TrainingPlanService, private router:Router){}
  ngOnInit(): void {
    
  }

  addTrainingPlan(){
    console.log(this.addTrainingPlanRequest);
    this.trainingPlanService.addTrainingPlan(this.addTrainingPlanRequest).subscribe({
      next:(newTrainingPlan)=>{
        console.log(newTrainingPlan);
        this.router.navigate(['/training-plans/edit/'+newTrainingPlan]);
      },
      error: (response)=>{
        console.log(response);
      }
    });
  }

}
