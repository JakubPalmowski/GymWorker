import { Component, OnInit } from '@angular/core';
import { MealsService } from 'src/app/services/meals.service';
import { Location } from '@angular/common';
import { MealFull } from 'src/app/models/meal-full';
import { ActivatedRoute, Router } from '@angular/router';
import { PreviousUrlService } from 'src/app/services/previous-url.service';


@Component({
  selector: 'app-meals-add',
  templateUrl: './meals-add.component.html',
  styleUrls: ['./meals-add.component.css']
})
export class MealsAddComponent implements OnInit{
 
  previousUrl:string='';

  addDieteticianMealRequest:MealFull={
    idMeal:0,
    idDietician:1,
    name:'',
    ingredients:'',
    prepareSteps:'',
    kcal:'',
    image:''
  }

  kcal:string='';
  proteins:string='';
  fats:string='';
  carbs:string='';


constructor(private mealService: MealsService, private router:Router, private location:Location, private previousUrlService: PreviousUrlService) {}
  
ngOnInit(): void {
  this.previousUrl=this.previousUrlService.getPreviousUrl();
  }

  addDieteticanMeal(){

    this.addDieteticianMealRequest.kcal+=this.kcal+","+this.proteins+","+this.fats+","+this.carbs;
    
    this.mealService.addDieteticanMeal(this.addDieteticianMealRequest).subscribe({
      next:(meal)=>{
        this.location.back();
      },
      error: (response)=>{
        console.log(response);
      }
    });
    
  }

  back(){
    this.router.navigateByUrl(this.previousUrl);
  }

  test(){
    console.log("test");
  }

}