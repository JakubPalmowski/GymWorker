import { Component,OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { FullTrainingPlan } from 'src/app/models/full-training-plan.model';
import { TrainingPlanService } from 'src/app/services/training-plan.service';


@Component({
  selector: 'app-add-training-plan',
  templateUrl: './add-training-plan.component.html',
  styleUrls: ['./add-training-plan.component.css']
})
export class AddTrainingPlanComponent implements OnInit{
  
  addTrainingPlanRequest: FullTrainingPlan={
    idTrainingPlan:0,
    idTrainer:3,
    name:'',
    customName:'',
    type:'',
    startDate:new Date(),
    numberOfWeeks:0
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
