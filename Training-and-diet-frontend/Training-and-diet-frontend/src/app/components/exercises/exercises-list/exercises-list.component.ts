import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { response } from 'express';
import { ExerciseShort } from 'src/app/models/exercise-short.model';
import { TrainingPlanExercise } from 'src/app/models/trainingPlanExercise.model';
import { ExercisesService } from 'src/app/services/exercises.service';

@Component({
  selector: 'app-exercises-list',
  templateUrl: './exercises-list.component.html',
  styleUrls: ['./exercises-list.component.css']
})
export class ExercisesListComponent implements OnInit{
 
  trainingPlanExercises:ExerciseShort[]=[];
  filteredPlanExercises:ExerciseShort[]=[];


  id_training:string='';

  constructor(private exerciseServise:ExercisesService, private route:ActivatedRoute){}

  ngOnInit(): void {
   

    this.id_training=this.route.snapshot.queryParams['id'];
   
    console.log(this.id_training);
    

      //TODO: 2 oddzielne listy: trenera i wszystkie 
    this.exerciseServise.getTrainerExercises().subscribe({
      next:(trainingPlanExercises)=>{
        this.trainingPlanExercises=trainingPlanExercises;
        this.filteredPlanExercises=this.trainingPlanExercises;
      },
      error: (response)=>{
        console.log(response);
      }
    })
  }

  filterResults(text: string){
    if (!text) {
      this.filteredPlanExercises = this.trainingPlanExercises;
    }
  
    this.filteredPlanExercises = this.trainingPlanExercises.filter(
      trainingPlanExercises => trainingPlanExercises?.name.toLowerCase().includes(text.toLowerCase())
    );
  }
  

  MyExercises(){
    console.log("my");
    this.id_training=this.route.snapshot.queryParams['id'];


   
  this.exerciseServise.getTrainerExercises().subscribe({
    next:(trainingPlanExercises)=>{
      this.filteredPlanExercises=trainingPlanExercises;

      const allExercisesElement = document.getElementById("all-exercises");
      const myExercisesElement = document.getElementById("my-exercises");
      
      myExercisesElement?.classList.add("selected-all-my");
      allExercisesElement?.classList.remove("selected-all-my");
    },
    error: (response)=>{
      console.log(response);
    }
  })
  }
  

  AllExercises(){
    console.log("all");
    this.id_training=this.route.snapshot.queryParams['id'];


   
  this.exerciseServise.getAllExercises().subscribe({
    next:(trainingPlanExercises)=>{
      this.filteredPlanExercises=trainingPlanExercises;

      const allExercisesElement = document.getElementById("all-exercises");
      const myExercisesElement = document.getElementById("my-exercises");
  
      allExercisesElement?.classList.add("selected-all-my");
      myExercisesElement?.classList.remove("selected-all-my");
    },
    error: (response)=>{
      console.log(response);
    }
  })
  }
}
