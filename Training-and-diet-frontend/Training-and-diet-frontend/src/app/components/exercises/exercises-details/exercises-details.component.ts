import { Component } from '@angular/core';
import { ExercisesService } from 'src/app/services/exercises.service';
import { Location } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { ExerciseFull } from 'src/app/models/exercise/exercise-full.model';
import { PreviousUrlService } from 'src/app/services/previous-url.service';


@Component({
  selector: 'app-exercises-details',
  templateUrl: './exercises-details.component.html',
  styleUrls: ['./exercises-details.component.css']
})
export class ExercisesDetailsComponent {


  
  previousUrl:string='';

  exerciseData:ExerciseFull={
    idExercise:0,
    name:'',
    details:'',
    exerciseSteps:'',
    idTrainer:1
  }

  idExercise:string='';

  constructor(private route:ActivatedRoute, private exercisesService:ExercisesService,private location:Location, 
    private previousUrlService: PreviousUrlService,private router:Router) {}

  ngOnInit(): void {
    this.previousUrl=this.previousUrlService.getPreviousUrl()
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
    this.router.navigateByUrl(this.previousUrl);
  }

}