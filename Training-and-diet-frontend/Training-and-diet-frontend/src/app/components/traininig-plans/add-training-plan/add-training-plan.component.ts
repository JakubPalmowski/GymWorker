import { Component,OnInit } from '@angular/core';
import { Form } from '@angular/forms';
import { Router } from '@angular/router';

import { FullTrainingPlan } from 'src/app/models/full-training-plan.model';
import { TrainingPlanService } from 'src/app/services/training-plan.service';


@Component({
  selector: 'app-add-training-plan',
  templateUrl: './add-training-plan.component.html',
  styleUrls: ['./add-training-plan.component.css']
})
export class AddTrainingPlanComponent implements OnInit{
  

  submitted=false;

  addTrainingPlanRequest: FullTrainingPlan={
    idTrainingPlan:0,
    idTrainer:3,
    name:'',
    customName:'',
    type:'',
    startDate:new Date(),
    numberOfWeeks:0
  }
  dateToday:string='';

  constructor(private trainingPlanService:TrainingPlanService, private router:Router){}
  ngOnInit(): void {
    this.dateToday=new Date().toISOString().split("T")[0];
    console.log(document.getElementById("start_date"));


  }

  addTrainingPlan(){
    console.log(this.addTrainingPlanRequest);
    this.trainingPlanService.addTrainingPlan(this.addTrainingPlanRequest).subscribe({
      next:(newTrainingPlan)=>{
        console.log(newTrainingPlan);
        this.router.navigate(['/training-plans']);
      },
      error: (response)=>{
        console.log(response);
      }
    });
  }



  onSubmit(valid:any){
    this.submitted=true;
    if(valid){
      console.log(this.addTrainingPlanRequest);
      
      this.addTrainingPlan();
      
    }
    
  }

}
