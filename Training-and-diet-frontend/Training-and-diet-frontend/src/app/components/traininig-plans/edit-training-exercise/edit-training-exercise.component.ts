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
    console.log(this.route.snapshot.queryParams);
    console.log("tr"+this.id_training);
    console.log("cw"+this.id_exercise);


    if(id){
      this.id_training_exercise=id;
    this.exerciseServise.getTrainingExerciseById(this.id_training_exercise).subscribe({
      next:(exercise)=>{
        this.newTrainingExerciseRequest=exercise;
        this.repetitions=this.newTrainingExerciseRequest.repetitionsNumber.split(",");
        console.log(this.newTrainingExerciseRequest);
        //console.log(this.exercise);
      },
      error: (response)=>{
        console.log(response);
      }
    })
  }

  }})
}

  OnChangeSeriesNumber(seriesNumber:number){
    console.log(seriesNumber.toString());
    console.log(this.newTrainingExerciseRequest.seriesNumber);
    
    this.repetitions.length=this.newTrainingExerciseRequest.seriesNumber;
  
    console.log(this.repetitions);
    
  }

  refresh()
  {

  }

  onSubmit(valid:any){
    this.submitted=true;
    if(valid){
      console.log(this.newTrainingExerciseRequest);
      
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
    
    
    this.exerciseServise.editTrainingExercise(this.newTrainingExerciseRequest,this.id_training_exercise).subscribe({
      next:(newTrainingExercise)=>{
        this.router.navigate(['/training-plans/edit/'+this.id_training]);
      },
      error:(response)=>{
        console.log(response);
        if(responseDiv){
          responseDiv.innerHTML="Podczas edycji wystąpił błąd";
          
        }}
    });

    

  }

  back(){
    this.router.navigateByUrl(this.previousUrl);
  }
}