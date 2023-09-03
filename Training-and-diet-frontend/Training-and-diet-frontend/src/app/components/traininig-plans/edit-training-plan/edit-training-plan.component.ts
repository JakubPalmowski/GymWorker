import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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

  test:string='1';

  constructor(private route:ActivatedRoute, private trainingPlanService:TrainingPlanService){}

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next:(params)=>{
        const id=params.get('id');
        
        
        if(id){
          console.log(id);
          this.trainingPlanService.getExercisesByPlanId(id).subscribe({
            next:(trainingPlanExercises)=>{
              this.trainingPlanExercises=trainingPlanExercises;
              console.log(trainingPlanExercises);
            },
            error: (response)=>{
              console.log(response);
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
