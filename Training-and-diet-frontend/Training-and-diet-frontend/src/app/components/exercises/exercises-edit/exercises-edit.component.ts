import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ExerciseFull } from 'src/app/models/exercise-full';
import { ExercisesService } from 'src/app/services/exercises.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-exercises-edit',
  templateUrl: './exercises-edit.component.html',
  styleUrls: ['./exercises-edit.component.css']
})
export class ExercisesEditComponent implements OnInit{
  
  exerciseEdit:ExerciseFull={
    idExercise:0,
    name:'',
    details:'',
    exerciseSteps:'',
    image:'',
    idTrainer:1
  }
  
  idExercise:string='';
 
  constructor(private route:ActivatedRoute, private exercisesService:ExercisesService,private location:Location) {}
  
  ngOnInit(): void {
   this.route.paramMap.subscribe({
    next:(params)=>{
      const id=params.get('id');
      

      if(id){
        console.log(id);
        this.idExercise=id;
        this.exercisesService.getExerciseById(this.idExercise).subscribe({
          next:(exercise)=>{
            this.exerciseEdit=exercise;
          },
          error: (response)=>{
            console.log(response);
          }
        })
      }
      else
      {
        console.log("no");
      }
    }
   })
  }

  edit(){
    this.exercisesService.editExercise(this.exerciseEdit,this.idExercise).subscribe({
      next:(exercise)=>{
      this.location.back();
      },
      error: (response)=>{
        console.log(response);
      }
    });
  }

  back(): void{
    this.location.back();
  }

}
