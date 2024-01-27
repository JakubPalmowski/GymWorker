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
    console.log(new Date().toISOString());
    console.log(new Date().toString());
    

    this.route.paramMap.subscribe({
      next:(params)=>{
        const id=params.get('id');

        // do wrzucenie w get cwiczen
        this.changeTrainingDay(1,'pn');
        
        if(id){
          console.log(id);
          this.idTraining=id;
          this.trainingPlanService.getPupilTrainingPlanById(this.idTraining).subscribe({
            next:(plan)=>{
              this.trainingPlan=plan;
            //  this.formStartDate=new Date(this.trainingPlan.startDate).toLocaleDateString();
              this.defaultType();
            },
            error: (response)=>{
             console.log(response);
            }
          })
          this.trainingPlanService.getExercisesByPlanId(id).subscribe({
            next:(trainingPlanExercises)=>{
              this.trainingPlanExercises=trainingPlanExercises;
              this.changeTrainingDay(1,"pn");

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

  changeTrainingDayByCalendar(){
    console.log(this.dateInputString);
    var date=new Date(this.dateInputString);
    var dayOfWeek=date.getDay() == 0? 7 : date.getDay();
    console.log(dayOfWeek);
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

  changeTrainingDay(day:number,val:string){

    const selectedDay=document.getElementById(val);

    const pn=document.getElementById('pn');
    const wt=document.getElementById('wt');
    const sr=document.getElementById('sr');
    const czw=document.getElementById('czw');
    const pt=document.getElementById('pt');
    const sob=document.getElementById('sob');
    const nd=document.getElementById('nd');

    pn?.classList.remove('selected-day');
    wt?.classList.remove('selected-day');
    sr?.classList.remove('selected-day');
    czw?.classList.remove('selected-day');
    pt?.classList.remove('selected-day');
    sob?.classList.remove('selected-day');
    nd?.classList.remove('selected-day');

    this.filterTrainingDay(day);

    selectedDay?.classList.add('selected-day');


  }
}
