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
    id_Training_plan:0,
    id_Trainer:1,
    name:'',
    type:'',
    start_date:new Date(),
    end_date:new Date(),

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
