import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EditTrainingExercise } from 'src/app/models/training-plan/edit-training-exercise.model';
import { ExerciseGetById } from 'src/app/models/exercise/exercise-get-by-id.model';
import { ExerciseShort } from 'src/app/models/exercise/exercise-short.model';
import { NewTrainingExercise } from 'src/app/models/training-plan/new-training-exercise.model';
import { ExercisesService } from 'src/app/services/exercises.service';
import { PreviousUrlService } from 'src/app/services/previous-url.service';

@Component({
  selector: 'app-edit-training-exercise',
  templateUrl: './edit-training-exercise.component.html',
  styleUrls: ['./edit-training-exercise.component.css']
})
export class EditTrainingExerciseComponent implements OnInit{

  id_training_exercise:string='';
  id_training:string='';
  id_exercise:string='';

  newTrainingExerciseRequest:EditTrainingExercise={
    seriesNumber:0,
    repetitionsNumber:'',
    comments:'',
    dayOfWeek:0,
    idExercise:0,
    idTrainingPlan:0,
    idTraineeExercise:0,
    exerciseName:'',
  }


  repetitions:string[]=[];

  submitted=false;
  fieldErrors: { [key: string]: string[] } = {};
  errorFlag: string = "";
  
  previousUrl:string='';
  
  constructor(private exerciseServise:ExercisesService, private route:ActivatedRoute,private router:Router,private previousUrlService: PreviousUrlService){
  }
  

  ngOnInit(): void {

    this.route.paramMap.subscribe({
      next:(params)=>{
        const id=params.get('id');
  
    this.previousUrl=this.previousUrlService.getPreviousUrl();
    this.id_training=this.route.snapshot.queryParams['trainingId'];
    this.id_exercise=this.route.snapshot.queryParams['exerciseId'];


    if(id){
      this.id_training_exercise=id;
    this.exerciseServise.getTrainingExerciseById(this.id_training_exercise).subscribe({
      next:(exercise)=>{
        this.newTrainingExerciseRequest=exercise;
        this.repetitions=this.newTrainingExerciseRequest.repetitionsNumber.split(",");
      },
      error: (response)=>{
      }
    })
  }

  }})
}

  OnChangeSeriesNumber(seriesNumber:number){
    this.repetitions.length=this.newTrainingExerciseRequest.seriesNumber;
  }

  refresh()
  {

  }

  onSubmit(valid:any){
    this.submitted=true;
    if(valid){
      
      this.editTrainingExercise();
    }
  }
  
  assignValue(){
    this.newTrainingExerciseRequest.dayOfWeek=parseInt(this.newTrainingExerciseRequest.dayOfWeek.toString());
  }

  editTrainingExercise(){
    this.newTrainingExerciseRequest.idExercise=parseInt(this.id_exercise);
    this.newTrainingExerciseRequest.idTrainingPlan=parseInt(this.id_training);
    this.newTrainingExerciseRequest.repetitionsNumber=this.repetitions.toString();
    const responseDiv = document.getElementById("edit-resp");
    
    this.fieldErrors = {};

    this.exerciseServise.editTrainingExercise(this.newTrainingExerciseRequest,this.id_training_exercise).subscribe({
      next:(newTrainingExercise)=>{
        this.router.navigate(['/training-plans/edit/'+this.id_training]);
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

  back(){
    this.router.navigateByUrl(this.previousUrl);
  }
}