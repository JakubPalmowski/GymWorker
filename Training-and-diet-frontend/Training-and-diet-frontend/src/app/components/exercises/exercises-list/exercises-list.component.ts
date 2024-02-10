import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { response } from 'express';
import { ExerciseShort } from 'src/app/models/exercise/exercise-short.model';
import { TrainingPlanExercise } from 'src/app/models/training-plan/training-plan-exercise.model';
import { ExercisesService } from 'src/app/services/exercises.service';
import { Location } from '@angular/common';


@Component({
  selector: 'app-exercises-list',
  templateUrl: './exercises-list.component.html',
  styleUrls: ['./exercises-list.component.css']
})
export class ExercisesListComponent implements OnInit{

 
  trainingPlanExercises:ExerciseShort[]=[];
  filteredPlanExercises:ExerciseShort[]=[];


  id_training:string='';
  source:string='';
  my_exercises_flag:boolean=false;
  showDialog: boolean = false;
  deleteErrorFlag: boolean=false;
  tittle: string='Moje ćwiczenia';
  searchTerm: string = '';
  selectedExercise : ExerciseShort | null = null;

  constructor(private exerciseServise:ExercisesService, private route:ActivatedRoute, private location:Location){}

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
    this.tittle='Moje ćwiczenia';
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
        console.log(response);
      }
    })
  }

  openDeleteDialog(id: number){
  
    this.selectedExercise = this.filteredPlanExercises?.find(g => g.idExercise === id) ?? null;
    if (this.selectedExercise) {
      this.showDialog = true;
    } else {
      alert('Ćwiczenie nie zostało znalezione.'); 
    }
   
  }
  


    confirmDelete() {
      if (this.selectedExercise) {
        this.exerciseServise.deleteExercise(this.selectedExercise.idExercise.toString()).subscribe({
          next: () => {
            this.ngOnInit(); 
          },
          error: (error) => {
            this.deleteErrorFlag=true;
          }
        });
        this.showDialog = false; 
      }
    }


    cancelDelete() {
      this.showDialog = false;
    }
}


