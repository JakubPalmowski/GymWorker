import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EditTrainingPlan } from 'src/app/models/edit-training-plan.model';
import { TrainingPlan } from 'src/app/models/trainingPlan.model';
import { TrainingPlanExercise } from 'src/app/models/trainingPlanExercise.model';
import { TrainingPlanService } from 'src/app/services/training-plan.service';

@Component({
  selector: 'app-edit-training-plan',
  templateUrl: './edit-training-plan.component.html',
  styleUrls: ['./edit-training-plan.component.css']
})
export class EditTrainingPlanComponent implements OnInit{
 
  trainingPlanExercises:TrainingPlanExercise[]=[
   
  ];

  trainingPlan:EditTrainingPlan={
    idTrainingPlan:0,
    name:'',
    type:'',
    startDate:new Date(),
    endDate:new Date()

  }

  formStartDate:string='';
  formEndDate:string='';

  idTraining:string='';

  constructor(private route:ActivatedRoute, private trainingPlanService:TrainingPlanService){}

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next:(params)=>{
        const id=params.get('id');
        
        
        if(id){
          console.log(id);
          this.idTraining=id;
          this.trainingPlanService.getTrainingPlanById(this.idTraining).subscribe({
            next:(plan)=>{
              this.trainingPlan=plan[0];
             
              this.formStartDate=this.trainingPlan.startDate.toString().split('T')[0];
              this.formEndDate=this.trainingPlan.endDate.toString().split('T')[0];
              
          
            },
            error: (response)=>{
             console.log(response);
            }
          })

          this.trainingPlanService.getExercisesByPlanId(id).subscribe({
            next:(trainingPlanExercises)=>{
              this.trainingPlanExercises=trainingPlanExercises;
             // console.log(trainingPlanExercises);
            },
            error: (response)=>{
              console.log("here"+response);
            }
          })

        }
        else{
          console.log("no");
        }
      }
    })
    
  }
}
