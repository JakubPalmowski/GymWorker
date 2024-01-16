import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ExerciseGetById } from 'src/app/models/exercise-get-by-id';
import { FullTrainingPlanGet } from 'src/app/models/full-training-plan-get';
import { NewTrainingExercise } from 'src/app/models/new-training-exercise.model';
import { TrainingExerciseFull } from 'src/app/models/training-exercise-full';
import { TrainingPlanExercise } from 'src/app/models/trainingPlanExercise.model';
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
 
  trainingPlan:FullTrainingPlanGet={
    idTrainingPlan:0,
    name:'',
    customName:'',
    type:'',
    startDate:new Date(),
    numberOfWeeks:0,
    idTrainer:3,
    idPupil:0
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
        this.changeTrainingDay(0,'pn');
        
        if(id){
          console.log(id);
          this.idTraining=id;
          this.trainingPlanService.getTrainingPlanById(this.idTraining).subscribe({
            next:(plan)=>{
              this.trainingPlan=plan;
              this.formStartDate=new Date(this.trainingPlan.startDate).toLocaleDateString();
              this.defaultType();
            },
            error: (response)=>{
             console.log(response);
            }
          })
          this.trainingPlanService.getExercisesByPlanId(id).subscribe({
            next:(trainingPlanExercises)=>{
              this.trainingPlanExercises=trainingPlanExercises;
              this.changeTrainingDay(0,"pn");

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
    var dayOfWeek=date.getDay() == 0 ? 6 : date.getDay()-1;
    
    switch(dayOfWeek){
      case 0:
        this.changeTrainingDay(0,'pn');
        break;
      case 1:
        this.changeTrainingDay(1,'wt');
        break;
      case 2:
        this.changeTrainingDay(2,'sr');
        break;
      case 3:
        this.changeTrainingDay(3,'czw');
        break;
      case 4:
        this.changeTrainingDay(4,'pt');
        break;
      case 5:
        this.changeTrainingDay(5,'sob');
        break;
      case 6:
        this.changeTrainingDay(6,'nd');
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
