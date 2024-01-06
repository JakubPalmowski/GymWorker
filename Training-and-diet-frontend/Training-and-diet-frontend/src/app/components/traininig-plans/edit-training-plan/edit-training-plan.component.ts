import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FullTrainingPlan } from 'src/app/models/full-training-plan.model';
import { TrainingExerciseFull } from 'src/app/models/training-exercise-full';
import { TrainingPlan } from 'src/app/models/trainingPlan.model';
import { TrainingPlanExercise } from 'src/app/models/trainingPlanExercise.model';
import { TrainingPlanService } from 'src/app/services/training-plan.service';

@Component({
  selector: 'app-edit-training-plan',
  templateUrl: './edit-training-plan.component.html',
  styleUrls: ['./edit-training-plan.component.css']
})
export class EditTrainingPlanComponent implements OnInit{
 
  trainingPlanExercisesTEMP:TrainingPlanExercise[]=[
   
  ];

  filteredTrainingPlanExercises:TrainingExerciseFull[]=[];

  trainingPlanExercises:TrainingExerciseFull[]=[
    {
      IdTraineeExercise:1,
      name:'test1',
      seriesNumber: 3,
      repetitionsNumber: '4,6,8',
      comments: 'obciążenie 10kg na każdą ręke',
      dayOfWeek: 0,
      idExercise: 1,
      idTrainingPlan:1
    },
    {
      IdTraineeExercise: 59,
      name: 'test10',
      seriesNumber: 5,
      repetitionsNumber: '4,6,8',
      comments: 'obciążenie 10kg na każdą ręke',
      dayOfWeek: 4,
      idExercise: 25,
      idTrainingPlan: 89
      },
      {
      IdTraineeExercise: 50,
      name: 'test7',
      seriesNumber: 2,
      repetitionsNumber: '4,6,8',
      comments: 'obciążenie 10kg na każdą ręke',
      dayOfWeek: 5,
      idExercise: 51,
      idTrainingPlan: 25
      },
      {
      IdTraineeExercise: 47,
      name: 'test8',
      seriesNumber: 10,
      repetitionsNumber: '4,6,8',
      comments: 'obciążenie 10kg na każdą ręke',
      dayOfWeek: 3,
      idExercise: 65,
      idTrainingPlan: 91
      },
      {
      IdTraineeExercise: 71,
      name: 'test2',
      seriesNumber: 6,
      repetitionsNumber: '4,6,8',
      comments: 'obciążenie 10kg na każdą ręke',
      dayOfWeek: 0,
      idExercise: 7,
      idTrainingPlan: 31
      },
      {
      IdTraineeExercise: 14,
      name: 'test7',
      seriesNumber: 6,
      repetitionsNumber: '4,6,8',
      comments: 'obciążenie 10kg na każdą ręke',
      dayOfWeek: 0,
      idExercise: 76,
      idTrainingPlan: 45
      },
      {
      IdTraineeExercise: 70,
      name: 'test4',
      seriesNumber: 7,
      repetitionsNumber: '4,6,8',
      comments: 'obciążenie 10kg na każdą ręke',
      dayOfWeek: 5,
      idExercise: 91,
      idTrainingPlan: 74
      },
      {
      IdTraineeExercise: 24,
      name: 'test5',
      seriesNumber: 9,
      repetitionsNumber: '4,6,8',
      comments: 'obciążenie 10kg na każdą ręke',
      dayOfWeek: 4,
      idExercise: 28,
      idTrainingPlan: 57
      },
      {
      IdTraineeExercise: 31,
      name: 'test7',
      seriesNumber: 3,
      repetitionsNumber: '4,6,8',
      comments: 'obciążenie 10kg na każdą ręke',
      dayOfWeek: 4,
      idExercise: 26,
      idTrainingPlan: 36
      },
      {
      IdTraineeExercise: 5,
      name: 'test6',
      seriesNumber: 2,
      repetitionsNumber: '4,6,8',
      comments: 'obciążenie 10kg na każdą ręke',
      dayOfWeek: 2,
      idExercise: 32,
      idTrainingPlan: 99
      },
      {
      IdTraineeExercise: 41,
      name: 'test6',
      seriesNumber: 10,
      repetitionsNumber: '4,6,8',
      comments: 'obciążenie 10kg na każdą ręke',
      dayOfWeek: 4,
      idExercise: 74,
      idTrainingPlan: 96
      }

  ];
 
  trainingPlan:FullTrainingPlan={
    idTrainingPlan:0,
    name:'',
    customName:'',
    type:'',
    startDate:new Date(),
    numberOfWeeks:0,
    idTrainer:3

  }

  formStartDate:string='';
  formEndDate:string='';

  idTraining:string='';

  constructor(private route:ActivatedRoute, private trainingPlanService:TrainingPlanService){}

  ngOnInit(): void {
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
             
              this.formStartDate=this.trainingPlan.startDate.toString().split('T')[0];
            
              
          
            },
            error: (response)=>{
             console.log(response);
            }
          })

          /*
          this.trainingPlanService.getExercisesByPlanId(id).subscribe({
            next:(trainingPlanExercises)=>{
              this.trainingPlanExercises=trainingPlanExercises;
           
            },
            error: (response)=>{
              console.log("here"+response);
            }
          })

          */
          
        }
        else{
          console.log("no");
        }
      }
    })
    
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
