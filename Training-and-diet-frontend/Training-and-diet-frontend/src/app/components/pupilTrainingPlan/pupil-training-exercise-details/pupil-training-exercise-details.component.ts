import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PupilTraineeExerciseGet } from 'src/app/models/pupilTraineeExerciseGet.model';
import { ExercisesService } from 'src/app/services/exercises.service';
import { PreviousUrlService } from 'src/app/services/previous-url.service';

@Component({
  selector: 'app-pupil-training-exercise-details',
  templateUrl: './pupil-training-exercise-details.component.html',
  styleUrls: ['./pupil-training-exercise-details.component.css']
})
export class PupilTrainingExerciseDetailsComponent implements OnInit {

  previousUrl:string='';

  traineeExercise:PupilTraineeExerciseGet={
    idTraineeExercise: 0,
    seriesNumber: 0,
    repetitionsNumber: 0,
    comments: '',
    idExercise: 0,
    idTrainingPlan: 0,
    exerciseName: '',
    details: '',
    exerciseSteps: ''
  }

  idTraineeExercise:string='';

  constructor(private route:ActivatedRoute, private router:Router,private exerciseService:ExercisesService, private previousUrlService:PreviousUrlService) { }

  ngOnInit(): void {

    this.previousUrl=this.previousUrlService.getPreviousUrl();
    this.route.paramMap.subscribe({
      next:(params)=>{
        const id=params.get('id');
        if(id){
        this.idTraineeExercise=id;
        console.log(id);  
        }

      }});

      this.exerciseService.getTrainingExerciseByIdForPupil(this.idTraineeExercise).subscribe({
        next:(response)=>{
          this.traineeExercise=response;
          console.log(response);
        },
        error:(response)=>{
          console.log(response);
        }
      })
  }


  back(){
    this.router.navigateByUrl(this.previousUrl);
  }
}
