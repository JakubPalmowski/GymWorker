import { Component,OnInit } from '@angular/core';
import { Form } from '@angular/forms';
import { Router } from '@angular/router';

import { FullTrainingPlan } from 'src/app/models/diet/full-training-plan.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { TrainingPlanService } from 'src/app/services/training-plan.service';


@Component({
  selector: 'app-add-training-plan',
  templateUrl: './add-training-plan.component.html',
  styleUrls: ['./add-training-plan.component.css']
})
export class AddTrainingPlanComponent implements OnInit{
  

  submitted=false;
  fieldErrors: { [key: string]: string[] } = {};
  errorFlag: string = "";

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

  constructor(private trainingPlanService:TrainingPlanService, private router:Router, private authenticationService:AuthenticationService){}
  ngOnInit(): void {
    this.dateToday=new Date().toISOString().split("T")[0];


  }

  addTrainingPlan(){


   this.fieldErrors = {};

    this.trainingPlanService.addTrainingPlan(this.addTrainingPlanRequest).subscribe({
      next:(newTrainingPlan)=>{

        this.router.navigate(['/training-plans']);
      },
      error: (error)=>{
       if(error.status===400){
        const {errors} = error.error;
        for(const key in errors){
          if(errors.hasOwnProperty(key)){
            this.fieldErrors[key] = errors[key]; 
          }
        }
       }else{
            this.errorFlag = "error";
            this.showErrorPopup(this.errorFlag);
            document.documentElement.scrollTop = 0;
       }
      }
    });
  }

  showErrorPopup(status: string) {
    if(status == "error"){
      setTimeout(() => this.errorFlag="", 3000); 
    }
  
  }


  onSubmit(valid:any){
    this.submitted=true;
    if(valid){
      
      this.addTrainingPlan();
      
    }
    
  }

}
