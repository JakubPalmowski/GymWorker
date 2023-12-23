import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Exercise } from 'src/app/models/exercise';
import { ExercisesService } from 'src/app/services/exercises.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-exercises-add',
  templateUrl: './exercises-add.component.html',
  styleUrls: ['./exercises-add.component.css']
})
export class ExercisesAddComponent implements OnInit{

 

  addTrainerExerciseRequest: Exercise={
    name:'',
    details:'',
    exercise_steps:'',
    id_Trainer:1,
    image:''
  }

  
 
  constructor(private exerciseService: ExercisesService, private router:Router, private location:Location) {}
  ngOnInit(): void {
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

}
