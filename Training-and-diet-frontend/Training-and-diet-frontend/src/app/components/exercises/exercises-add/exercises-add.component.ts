import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Exercise } from 'src/app/models/exercise';
import { ExercisesService } from 'src/app/services/exercises.service';
import { Location } from '@angular/common';
import { PreviousUrlService } from 'src/app/services/previous-url.service';

@Component({
  selector: 'app-exercises-add',
  templateUrl: './exercises-add.component.html',
  styleUrls: ['./exercises-add.component.css']
})
export class ExercisesAddComponent implements OnInit{

  previousUrl:string='';

  addTrainerExerciseRequest: Exercise={
    name:'',
    details:'',
    exerciseSteps:'',
    idTrainer:1,
    image:''
  }

  
 
  constructor(private exerciseService: ExercisesService, private router:Router, private location:Location,private previousUrlService: PreviousUrlService) {
    
  }
  ngOnInit(): void {
    this.previousUrl=this.previousUrlService.getPreviousUrl()
  }

  addTrainerExercise(){
    this.exerciseService.addTrainerExercise(this.addTrainerExerciseRequest).subscribe({
      next:(exercise)=>{
        this.location.back();
      },
      error: (response)=>{
        console.log(response);
      }
    });
  }

  back(){
    this.router.navigateByUrl(this.previousUrl);
  }

}
