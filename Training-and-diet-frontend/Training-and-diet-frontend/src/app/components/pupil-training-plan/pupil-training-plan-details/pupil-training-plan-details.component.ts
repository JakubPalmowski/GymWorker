import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FullPupilsTrainingPlanGet } from 'src/app/models/training-plan/full-pupils-training-plan-get.model';
import { ExerciseGetById } from 'src/app/models/exercise/exercise-get-by-id.model';
import { FullTrainingPlanGet } from 'src/app/models/training-plan/full-training-plan-get.model';
import { NewTrainingExercise } from 'src/app/models/training-plan/new-training-exercise.model';
import { TrainingExerciseFull } from 'src/app/models/training-plan/training-exercise-full.model';
import { TrainingPlanExercise } from 'src/app/models/training-plan/training-plan-exercise.model';
import { ExercisesService } from 'src/app/services/exercises.service';
import { PreviousUrlService } from 'src/app/services/previous-url.service';
import { TrainingPlanService } from 'src/app/services/training-plan.service';

@Component({
  selector: 'app-pupil-training-plan-details',
  templateUrl: './pupil-training-plan-details.component.html',
  styleUrls: ['./pupil-training-plan-details.component.css']
})
export class PupilTrainingPlanDetailsComponent {

  filteredTrainingPlanExercises:TrainingExerciseFull[]=[];

  trainingPlanExercises:TrainingExerciseFull[]=[];
 
  trainingPlan:FullPupilsTrainingPlanGet={
    idTrainingPlan:0,
    name:'',
    type:'',
    endDate:new Date(),
    idTrainer:3,
    trainerName:'',
    trainerLastName:'',
  }
  

  formStartDate:string='';
  formEndDate:string='';

  dateInput:Date=new Date();
  dateInputString:string='';
  idTraining:string='';

  constructor(private route:ActivatedRoute, private trainingPlanService:TrainingPlanService){}

  ngOnInit(): void {
    this.dateInputString=new Date().toISOString().split("T")[0];
    

    this.route.paramMap.subscribe({
      next:(params)=>{
        const id=params.get('id');

        this.changeTrainingDay(1,'pn');
        
        if(id){
          this.idTraining=id;
          this.trainingPlanService.getPupilTrainingPlanById(this.idTraining).subscribe({
            next:(plan)=>{
              this.trainingPlan=plan;
              this.defaultType();
            },
            error: (response)=>{
            }
          })
          this.trainingPlanService.getExercisesByPlanId(id).subscribe({
            next:(trainingPlanExercises)=>{
              this.trainingPlanExercises=trainingPlanExercises;
              this.changeTrainingDayByCalendar();

            },
            error: (response)=>{
              this.changeTrainingDayByCalendar();
            }
          })
        }
        else{
        }
      }
    })
    
  }

  changeTrainingDayByCalendar(){
    var date=new Date(this.dateInputString);
    var dayOfWeek=date.getDay() == 0? 7 : date.getDay();
    switch(dayOfWeek){
      case 1:
        this.changeTrainingDay(1,'pn');
        break;
      case 2:
        this.changeTrainingDay(2,'wt');
        break;
      case 3:
        this.changeTrainingDay(3,'sr');
        break;
      case 4:
        this.changeTrainingDay(4,'czw');
        break;
      case 5:
        this.changeTrainingDay(5,'pt');
        break;
      case 6:
        this.changeTrainingDay(6,'sob');
        break;
      case 7:
        this.changeTrainingDay(7,'nd');
        break;  
        }
        
  }

  getEndDate(date:Date){
    return new Date(date).toISOString().split("T")[0];
  }

  defaultType(){
    if(this.trainingPlan.type==""){
    this.trainingPlan.type="brak typu";
    }
  }

  filterTrainingDay(day:number){
    this.filteredTrainingPlanExercises=this.trainingPlanExercises.filter(
      trainingPlanExercises => trainingPlanExercises?.dayOfWeek==day
    )
  }

  changeTrainingDay(day: number, val: string) {
    const dayIds = ['pn', 'wt', 'sr', 'czw', 'pt', 'sob', 'nd'];
    dayIds.forEach(dayId => {
        document.getElementById(dayId)?.classList.remove('selected-day');
        document.getElementById(dayId + '-sm')?.classList.remove('selected-day');
    });


    let smVal, fullVal;
    if (val.includes('-sm')) {
        smVal = val;
        fullVal = val.replace('-sm', ''); 
    } else {
        smVal = val + '-sm'; 
        fullVal = val;
    }
    document.getElementById(fullVal)?.classList.add('selected-day');
    document.getElementById(smVal)?.classList.add('selected-day');

    this.filterTrainingDay(day);
}

}
