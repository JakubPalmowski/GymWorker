import { Component } from '@angular/core';
import { MealsService } from 'src/app/services/meals.service';
import { Location } from '@angular/common';
import { MealFull } from 'src/app/models/meal-full';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-meals-add',
  templateUrl: './meals-add.component.html',
  styleUrls: ['./meals-add.component.css']
})
export class MealsAddComponent {


  addDieteticianMealRequest:MealFull={
    id_Meal:0,
    id_Dietetician:1,
    name:'',
    ingredients:'',
    prepare_Steps:'',
    kcal:'',
    image:''
  }

  kcal:string='';
  proteins:string='';
  fats:string='';
  carbs:string='';


constructor(private mealService: MealsService, private router:Router, private location:Location) {}

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

test(){
  console.log("test");
}

}
