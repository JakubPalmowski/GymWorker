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
  tittle: string='Moje ćwiczenia';
  searchTerm: string = '';


  constructor(private exerciseServise:ExercisesService, private route:ActivatedRoute, private location:Location,private router:Router){}

  ngOnInit(): void {
    
    this.id_training=this.route.snapshot.queryParams['id'];
    this.source=this.route.snapshot.queryParams['source'];
    
    this.exerciseServise.getTrainerExercises().subscribe({
      next:(trainingPlanExercises)=>{
        this.trainingPlanExercises=trainingPlanExercises;
        this.filteredPlanExercises=this.trainingPlanExercises;
        this.my_exercises_flag=true;
        const myExercisesElement = document.getElementById("my-exercises");
        myExercisesElement?.classList.add("selected-all-my");
      },
      error: (response)=>{
      }
    })
  }

  filterResults() {
    if (!this.searchTerm) {
      this.filteredPlanExercises = this.trainingPlanExercises; 
    } else {
      this.filteredPlanExercises = this.trainingPlanExercises?.filter(exercise =>
        exercise.name.toLowerCase().includes(this.searchTerm.toLowerCase())
      );
    }
  }
  

  MyExercises(){
    
    this.tittle = 'Moje ćwiczenia';
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
      }
    })
  }
  

  AllExercises(){
    this.tittle = 'Wszystkie ćwiczenia';
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
      }
    })
  }

  openDeleteDialog(name:string){
    this.deleteErrorFlag=false;
    if(this.deleteDialogFlag!=true){
     this.deleteDialogFlag=true;
    
   }
   }
 
   deleteExercise(idExercise:number) {
     this.exerciseServise.deleteExercise(idExercise.toString()).subscribe({
       next:(response)=>{
         this.deleteDialogFlag=false;
         this.MyExercises();
       },
       error:(response)=>{
         this.deleteErrorFlag=true;
       }});
     }
 
   cancelDelete(){
     this.deleteDialogFlag=false;
   }
 

  back(): void{
    this.router.navigateByUrl('/training-plans/edit/'+this.id_training);
  }
}
