import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MealsService } from 'src/app/services/meals.service';
import { Location } from '@angular/common';
import { MealFull } from 'src/app/models/meal-full';

@Component({
  selector: 'app-meals-list',
  templateUrl: './meals-list.component.html',
  styleUrls: ['./meals-list.component.css']
})
export class MealsListComponent implements OnInit{

  DieteticianMeals:MealFull[]=[];
  DieteticianMealsFiltered:MealFull[]=[];

  id_diet:string='';

  constructor(private mealServise:MealsService, private route:ActivatedRoute, private location:Location) {}


  ngOnInit(): void {
 
     this.id_diet=this.route.snapshot.queryParams['id'];
     console.log(this.id_diet);
    
     this.mealServise.getDieteticianMeals().subscribe({
      next:(meals)=>{
        this.DieteticianMeals=meals;
        this.DieteticianMealsFiltered=this.DieteticianMeals;

      },
      error:(response)=>{
        console.log(response);
      }
     })
    
   }

   filterResults(text: string){
    if (!text) {
      this.DieteticianMealsFiltered = this.DieteticianMeals;
    }
  
    this.DieteticianMealsFiltered = this.DieteticianMeals.filter(
      DieteticianMeals => DieteticianMeals?.name.toLowerCase().includes(text.toLowerCase())
    );
  }


  back(): void{
    this.location.back();
  }
}