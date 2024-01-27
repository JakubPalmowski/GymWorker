import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ExerciseFull } from 'src/app/models/exercise/exercise-full.model';
import { ExercisesService } from 'src/app/services/exercises.service';
import { Location } from '@angular/common';

import { PreviousUrlService } from 'src/app/services/previous-url.service';

@Component({
  selector: 'app-exercises-edit',
  templateUrl: './exercises-edit.component.html',
  styleUrls: ['./exercises-edit.component.css']
})
export class ExercisesEditComponent implements OnInit{
  

  submitted=false;
  previousUrl:string='';

  exerciseEdit:ExerciseFull={
    idExercise:0,
    name:'',
    details:'',
    exerciseSteps:'',
    idTrainer:3
  }
  
  idExercise:string='';
  
 
  constructor(private route:ActivatedRoute, private exercisesService:ExercisesService,private location:Location,private router:Router ,private previousUrlService: PreviousUrlService
    ) {}
  
  ngOnInit(): void {
   
   this.previousUrl=this.previousUrlService.getPreviousUrl();
   
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
    const responseDiv = document.getElementById("edit-resp");
    this.exercisesService.editExercise(this.exerciseEdit,this.idExercise).subscribe({
      next:(exercise)=>{
        this.router.navigateByUrl(this.previousUrl);
      },
      error: (response)=>{
        console.log(response);
        if(responseDiv){
          responseDiv.innerHTML="Podczas edycji wystąpił błąd";
          
        }
      }
    });
  }

  onSubmit(valid:any){
    this.submitted=true;
    if(valid){
      this.edit();
      console.log(this.exerciseEdit);
    }
    
  }

  back(): void{
    this.router.navigateByUrl(this.previousUrl);
  }

}
