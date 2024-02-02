import { Component, OnInit } from '@angular/core';
import { MealsService } from 'src/app/services/meals.service';
import { Location } from '@angular/common';
import { MealFull } from 'src/app/models/meal/meal-full.model';
import { ActivatedRoute, Router } from '@angular/router';
import { PreviousUrlService } from 'src/app/services/previous-url.service';
import { MealKcal } from 'src/app/models/meal/meal-kcal.model';


@Component({
  selector: 'app-meals-add',
  templateUrl: './meals-add.component.html',
  styleUrls: ['./meals-add.component.css']
})
export class MealsAddComponent implements OnInit{
 
  previousUrl:string='';
  submitted=false;
  fieldErrors: { [key: string]: string[] } = {};
  errorFlag: string = "";

  addDieteticianMealRequest:MealFull={
    idMeal:0,
    idDietician:21,
    name:'',
    ingredients:'',
    prepareSteps:'',
    kcal:'',
  }

  mealKcal:MealKcal={
    kcal:'',
    proteins:'',
    fats:'',
    carbs:''
  }



constructor(private mealService: MealsService, private router:Router, private location:Location, private previousUrlService: PreviousUrlService) {}
  
ngOnInit(): void {
  this.previousUrl=this.previousUrlService.getPreviousUrl();
  }

  addDieteticanMeal(){

     this.addDieteticianMealRequest.kcal+=this.mealKcal.kcal+","+this.mealKcal.proteins+","+this.mealKcal.fats+","+this.mealKcal.carbs; 
     if(this.mealKcal.kcal=='' || this.mealKcal.proteins=='' || this.mealKcal.fats=='' || this.mealKcal.carbs==''){
      this.addDieteticianMealRequest.kcal='';
     }

     console.log("tst: "+this.addDieteticianMealRequest.kcal)
     this.fieldErrors = {};
    this.mealService.addDieteticanMeal(this.addDieteticianMealRequest).subscribe({
      next:(meal)=>{
        this.location.back();
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
      this.addDieteticanMeal();
      console.log(this.addDieteticianMealRequest);
    }
    
  }

  back(){
    this.router.navigateByUrl(this.previousUrl);
  }

  showErrorPopup(status: string) {
    if(status == "error"){
      setTimeout(() => this.errorFlag="", 3000); 
    }
  
  }



}