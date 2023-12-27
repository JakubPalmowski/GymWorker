import { Component } from '@angular/core';
import { ExercisesService } from 'src/app/services/exercises.service';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { ExerciseFull } from 'src/app/models/exercise-full';

@Component({
  selector: 'app-exercises-details',
  templateUrl: './exercises-details.component.html',
  styleUrls: ['./exercises-details.component.css']
})
export class ExercisesDetailsComponent {

  exerciseData:ExerciseFull={
    id_Exercise:0,
    name:'',
    details:'',
    exercise_steps:'',
    image:'',
    id_Trainer:1
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
             this.exerciseData=exercise;
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

  back(): void{
    this.location.back();
  }

}
