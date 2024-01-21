import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FullTrainingPlanGet } from 'src/app/models/full-training-plan-get';
import { FullTrainingPlan } from 'src/app/models/full-training-plan.model';
import { TrainingExerciseFull } from 'src/app/models/training-exercise-full';
import { TrainingPlan } from 'src/app/models/trainingPlan.model';
import { TrainingPlanExercise } from 'src/app/models/trainingPlanExercise.model';
import { ExercisesService } from 'src/app/services/exercises.service';
import { TrainingPlanService } from 'src/app/services/training-plan.service';

@Component({
  selector: 'app-edit-training-plan',
  templateUrl: './edit-training-plan.component.html',
  styleUrls: ['./edit-training-plan.component.css']
})
export class EditTrainingPlanComponent implements OnInit{

  submitted=false;

  trainingPlanExercisesTEMP:TrainingPlanExercise[]=[
   
  ];

  filteredTrainingPlanExercises:TrainingExerciseFull[]=[];

  trainingPlanExercises:TrainingExerciseFull[]=[];
 
  trainingPlan:FullTrainingPlanGet={
    idTrainingPlan:0,
    name:'',
    customName:'',
    type:'',
    startDate:new Date(),
    numberOfWeeks:0,
    idTrainer:0,
    idPupil:0

  }

  formStartDate:string='';
  formEndDate:string='';

  dateToday:string='';


  idTraining:string='';
  deleteDialogFlag: boolean=false;
  deleteErrorFlag: boolean=false;



  constructor(private route:ActivatedRoute, private trainingPlanService:TrainingPlanService, private exerciseService:ExercisesService, private router:Router){}

  ngOnInit(): void {
    this.dateToday=new Date().toISOString().split("T")[0];
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
              console.log("get plan by id"+plan.toString());
              this.trainingPlan=plan;
             
              this.formStartDate=this.trainingPlan.startDate.toString().split('T')[0];
            
              
          
            },
            error: (response)=>{
             console.log(response);
            }
          })
          this.getTrainingPlanExercises(id);
        }
        else{
          console.log("no");
        }
      }
    })
    
  }

  getTrainingPlanExercises(id:string){
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

  editTrainingPlan(){
    console.log("edit");
    console.log(this.trainingPlan);
    console.log(this.idTraining);
    const responseDiv = document.getElementById("edit-resp");


    this.trainingPlanService.editTrainingPlan(this.trainingPlan,this.idTraining).subscribe({
      next:(plan)=>{
        console.log(plan);
        if(responseDiv){
        responseDiv.innerHTML="Edycja planu powiodła się";
        }
      },
      error:(response)=>{
        console.log(response);
        if(responseDiv){
          responseDiv.innerHTML="Podczas edycji wystąpił błąd";
          
        }}
    });
  }

  onSubmit(valid:any)
  {
    this.submitted=true;
    if(valid){
      console.log(valid)
      this.trainingPlan.startDate=new Date(this.formStartDate);
      this.editTrainingPlan();
      
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


  openDeleteDialog(name:string){
    console.log("open");
    this.deleteErrorFlag=false;
    if(this.deleteDialogFlag!=true){
     this.deleteDialogFlag=true;
    
   }
   }
 
   deleteExercise(idExercise:number) {
     console.log("delete");
     this.exerciseService.deleteTraineeExercise(idExercise.toString()).subscribe({
       next:(response)=>{
         console.log(response);
         this.deleteDialogFlag=false;
        window.location.reload(); 
         
      
       },
       error:(response)=>{
         console.log(response);
         this.deleteErrorFlag=true;
       }});
 
     }
 
   cancelDelete(){
     console.log("cancel");
     this.deleteDialogFlag=false;
   }
}
