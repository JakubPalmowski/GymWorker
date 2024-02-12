import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FullTrainingPlanGet } from 'src/app/models/training-plan/full-training-plan-get.model';
import { FullTrainingPlan } from 'src/app/models/diet/full-training-plan.model';
import { TrainingExerciseFull } from 'src/app/models/training-plan/training-exercise-full.model';
import { TrainingPlan } from 'src/app/models/training-plan/training-plan.model';
import { TrainingPlanExercise } from 'src/app/models/training-plan/training-plan-exercise.model';
import { ExercisesService } from 'src/app/services/exercises.service';
import { TrainingPlanService } from 'src/app/services/training-plan.service';

@Component({
  selector: 'app-edit-training-plan',
  templateUrl: './edit-training-plan.component.html',
  styleUrls: ['./edit-training-plan.component.css']
})
export class EditTrainingPlanComponent implements OnInit{

  submitted=false;
  fieldErrors: { [key: string]: string[] } = {};
  errorFlag: string = "";
  successFlag: string = "";

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
    endDate:new Date(),
    numberOfWeeks:0,
    idTrainer:0,
    idPupil:0,
    pupilName:'',
    pupilLastName:'',
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
        
        this.changeTrainingDay(1,'pn');
        
        if(id){
          this.idTraining=id;
          
          this.trainingPlanService.getTrainerTrainingPlanById(this.idTraining).subscribe({
            next:(plan)=>{
              this.trainingPlan=plan;
              this.formStartDate=this.trainingPlan.startDate.toString().split('T')[0];
          
            },
            error: (response)=>{
            }
          })
          this.getTrainingPlanExercises(id);
        }
        else{
        }
      }
    })
    
  }

  getTrainingPlanExercises(id:string){
    this.trainingPlanService.getExercisesByPlanId(id).subscribe({
      next:(trainingPlanExercises)=>{
        this.trainingPlanExercises=trainingPlanExercises;
        this.changeTrainingDay(1,"pn");

      },
      error: (response)=>{
      }
    })
  }

  editTrainingPlan(){
    const responseDiv = document.getElementById("edit-resp");

    this.fieldErrors = {};

    this.trainingPlanService.editTrainingPlan(this.trainingPlan,this.idTraining).subscribe({
      next:(plan)=>{
        this.successFlag = "success";
          this.showSuccessPopup(this.successFlag);
          this.fieldErrors = {}; 
          document.documentElement.scrollTop = 0;
      },
      error:(error)=>{
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

  onSubmit(valid:any)
  {
    this.submitted=true;
    if(valid){
      this.trainingPlan.startDate=new Date(this.formStartDate);
      this.editTrainingPlan();
      
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


  openDeleteDialog(name:string){
    this.deleteErrorFlag=false;
    if(this.deleteDialogFlag!=true){
     this.deleteDialogFlag=true;
    
   }
   }
 
   deleteExercise(idExercise:number) {
     this.exerciseService.deleteTraineeExercise(idExercise.toString()).subscribe({
       next:(response)=>{
         this.deleteDialogFlag=false;
        window.location.reload(); 
         
      
       },
       error:(response)=>{
         this.deleteErrorFlag=true;
       }});
 
     }
 
   cancelDelete(){
     this.deleteDialogFlag=false;
   }

   showSuccessPopup(status: string) {
    if (status == "success") {
      setTimeout(() => this.successFlag="", 3000); 
    }
    if(status == "error"){
      setTimeout(() => this.successFlag="", 3000); 
    }
  
  }
}
