import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { response } from 'express';
import { ExerciseShort } from 'src/app/models/exercise/exercise-short.model';
import { TrainingPlanExercise } from 'src/app/models/training-plan/training-plan-exercise.model';
import { ExercisesService } from 'src/app/services/exercises.service';
import { Location } from '@angular/common';
import {RouterModule} from '@angular/router';

@Component({
  selector: 'app-training-exercise-list',
  templateUrl: './training-exercise-list.component.html',
  styleUrls: ['./training-exercise-list.component.css']
})
export class TrainingExerciseListComponent implements OnInit{
 
  trainingPlanExercises:ExerciseShort[]=[];
  filteredPlanExercises:ExerciseShort[]=[];


  id_training:string='';
  source:string='';
  my_exercises_flag:boolean=false;
  deleteDialogFlag: boolean=false;
  deleteErrorFlag: boolean=false;


  constructor(private exerciseServise:ExercisesService, private route:ActivatedRoute, private location:Location,private router:Router){}

  ngOnInit(): void {
    

   console.log(this.source);

    this.id_training=this.route.snapshot.queryParams['id'];
    this.source=this.route.snapshot.queryParams['source'];
    console.log(this.id_training);
    
    this.exerciseServise.getTrainerExercises().subscribe({
      next:(trainingPlanExercises)=>{
        this.trainingPlanExercises=trainingPlanExercises;
        this.filteredPlanExercises=this.trainingPlanExercises;
        this.my_exercises_flag=true;
        const myExercisesElement = document.getElementById("my-exercises");
        myExercisesElement?.classList.add("selected-all-my");
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
    
    this.exerciseServise.getTrainerExercises().subscribe({
      next:(trainingPlanExercises)=>{
        this.filteredPlanExercises=trainingPlanExercises;
        this.my_exercises_flag=true;

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
      
    this.exerciseServise.getAllExercises().subscribe({
      next:(trainingPlanExercises)=>{
        this.filteredPlanExercises=trainingPlanExercises;
        
        this.my_exercises_flag=false;
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

  openDeleteDialog(name:string){
    console.log("open");
    this.deleteErrorFlag=false;
    if(this.deleteDialogFlag!=true){
     this.deleteDialogFlag=true;
    
   }
   }
 
   deleteExercise(idExercise:number) {
     console.log("delete");
     this.exerciseServise.deleteExercise(idExercise.toString()).subscribe({
       next:(response)=>{
         console.log(response);
         this.deleteDialogFlag=false;
         this.MyExercises();
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
 

  back(): void{
    this.router.navigateByUrl('/training-plans/edit/'+this.id_training);
  }
}
