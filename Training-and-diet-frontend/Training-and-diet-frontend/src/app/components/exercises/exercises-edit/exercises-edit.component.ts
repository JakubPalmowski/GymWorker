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
  fieldErrors: { [key: string]: string[] } = {};
  errorFlag: string = "";
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
    this.fieldErrors = {};

    this.exercisesService.editExercise(this.exerciseEdit,this.idExercise).subscribe({
      next:(exercise)=>{
        this.router.navigateByUrl(this.previousUrl);
      },
      error: (error)=>{
        console.log(error);
       if(error.status===400){
        const {errors} = error.error;
        for(const key in errors){
          if(errors.hasOwnProperty(key)){
            this.fieldErrors[key] = errors[key]; 
          }
        }
       }else{
            this.errorFlag = "error";
            this.showErrorPopup(this.errorFlag);
            document.documentElement.scrollTop = 0;
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

  showErrorPopup(status: string) {
    if(status == "error"){
      setTimeout(() => this.errorFlag="", 3000); 
    }
  
  }

  back(): void{
    this.router.navigateByUrl(this.previousUrl);
  }

}
