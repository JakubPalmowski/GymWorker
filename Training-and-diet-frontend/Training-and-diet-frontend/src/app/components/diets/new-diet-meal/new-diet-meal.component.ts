import { query } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MealShort } from 'src/app/models/meal/meal-short.model';
import { NewMealDiet } from 'src/app/models/diet/new-meal-diet.model';
import { ExerciseGetById } from 'src/app/models/exercise/exercise-get-by-id.model';
import { MealsService } from 'src/app/services/meals.service';

@Component({
  selector: 'app-new-diet-meal',
  templateUrl: './new-diet-meal.component.html',
  styleUrls: ['./new-diet-meal.component.css']
})
export class NewDietMealComponent implements OnInit{

  idDiet:string='';
  idMeal:string='';

  newMealDietRequest:NewMealDiet={
    idMeal: 0,
    idDiet: 0,
    comments: '',
    dayOfWeek: 1,
    hourOfMeal: ''
  }

  

  meal:MealShort={
    idMeal: 0,
    name: ''
  };
   

  submitted=false;
  fieldErrors: { [key: string]: string[] } = {};
  errorFlag: string = "";
  
  
  constructor(private mealServise:MealsService, private route:ActivatedRoute,private router:Router){
 
  }
     

  ngOnInit(): void {
    this.idDiet=this.route.snapshot.queryParams['dietId'];
    this.idMeal=this.route.snapshot.queryParams['mealId'];

    this.mealServise.getMealById(this.idMeal).subscribe({
      next:(meal)=>{
        this.meal=meal;
      },
      error: (response)=>{
      }
    })
    
  }

  

  onSubmit(valid:any){
    this.submitted=true;
    if(valid){
      this.addDietMeal();
    }
  }
  
  assignValue(){
    this.newMealDietRequest.dayOfWeek=parseInt(this.newMealDietRequest.dayOfWeek.toString());
  }

  addDietMeal(){
    this.newMealDietRequest.idMeal=parseInt(this.idMeal);
    this.newMealDietRequest.idDiet=parseInt(this.idDiet);
    
    this.fieldErrors = {};
    this.mealServise.addDietMeal(this.newMealDietRequest).subscribe({
      next:(newTrainingExercise)=>{
        this.router.navigate(['/diet/edit/'+this.idDiet]);
      },error:(error)=>{
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
    })
    

  }

  showErrorPopup(status: string) {
    if(status == "error"){
      setTimeout(() => this.errorFlag="", 3000); 
    }
  
  }

  back(){
    this.router.navigate(['/diet/edit/'+this.idDiet+'/dietMeals'],{queryParams:{id:this.idDiet}});
  }
}
