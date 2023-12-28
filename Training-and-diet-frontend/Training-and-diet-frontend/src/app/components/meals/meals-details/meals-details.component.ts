import { Component, OnInit } from '@angular/core';
import { MealsService } from 'src/app/services/meals.service';
import { Location } from '@angular/common';
import { MealFull } from 'src/app/models/meal-full';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-meals-details',
  templateUrl: './meals-details.component.html',
  styleUrls: ['./meals-details.component.css']
})

export class MealsDetailsComponent implements OnInit{

  DieteticianMealData:MealFull={
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

  id_meal:string='';

  constructor(private mealService: MealsService, private route:ActivatedRoute, private location:Location) {}

   ngOnInit(): void {
    this.route.paramMap.subscribe({
      next:(params)=>{
        const id=params.get('id');


        if(id){
          console.log(id);
          this.id_meal=id;

          this.mealService.getMealById(this.id_meal).subscribe({
            next:(meal)=>{
              this.DieteticianMealData=meal;
              var kpfc=this.DieteticianMealData.kcal.split(',');
              this.kcal=kpfc[0];
              this.proteins=kpfc[1];
              this.fats=kpfc[2];
              this.carbs=kpfc[3];
            },
            error:(response)=>{
              console.log(response);
            }
          })
        }
      }
    })
  }

  back(): void{
    this.location.back();
  }
}
