import { Component, OnInit } from '@angular/core';
import { MealsService } from 'src/app/services/meals.service';
import { Location } from '@angular/common';
import { MealFull } from 'src/app/models/meal-full';
import { ActivatedRoute, Router } from '@angular/router';
import { PreviousUrlService } from 'src/app/services/previous-url.service';
import { MealKcal } from 'src/app/models/meal-kcal';
import { Form } from '@angular/forms';


@Component({
  selector: 'app-meals-edit',
  templateUrl: './meals-edit.component.html',
  styleUrls: ['./meals-edit.component.css']
})
export class MealsEditComponent implements OnInit{

  previousUrl:string='';
  submitted=false;


  editDieteticianMealRequest:MealFull={
    idMeal:0,
    idDietician:2,
    name:'',
    ingredients:'',
    prepareSteps:'',
    kcal:'',
    image:''
  }


  mealKcal:MealKcal={
    kcal:'',
    proteins:'',
    fats:'',
    carbs:''
  }


  id_meal:string='';

  constructor(private mealService: MealsService, private route:ActivatedRoute, private location:Location, private router:Router, private previousUrlService: PreviousUrlService) {}


  ngOnInit(): void {
    this.previousUrl=this.previousUrlService.getPreviousUrl();

    this.route.paramMap.subscribe({
      next:(params)=>{
        const id=params.get('id');


        if(id){
          console.log(id);
          this.id_meal=id;

          this.mealService.getMealById(this.id_meal).subscribe({
            next:(meal)=>{
              this.editDieteticianMealRequest=meal;
              var kpfc=this.editDieteticianMealRequest.kcal.split(',');
              this.mealKcal.kcal=kpfc[0];
              this.mealKcal.proteins=kpfc[1];
              this.mealKcal.fats=kpfc[2];
              this.mealKcal.carbs=kpfc[3];
              console.log(kpfc);
              console.log(this.editDieteticianMealRequest.kcal);
            },
            error:(response)=>{
              console.log(response);
            }
          })
        }
      }
    })
  }

  edit(){
    this.editDieteticianMealRequest.kcal=this.mealKcal.kcal+","+this.mealKcal.proteins+","+this.mealKcal.fats+","+this.mealKcal.carbs;
    console.log(this.editDieteticianMealRequest);
    
    this.mealService.editDieteticianMeal(this.editDieteticianMealRequest,this.id_meal).subscribe({
      next:(meal)=>{
        this.location.back();
      },
      error: (response)=>{
        console.log(response);
      }
    });
  }

  onSubmit(valid:any,form:Form){
    this.submitted=true;
    if(valid){
     // this.editDieteticanMeal();
      console.log(this.editDieteticianMealRequest);
      console.log("ok");
    }
   // console.log(this.editDieteticianMealRequest);
   console.log(form);
    
    
  }

  back(): void{
    this.router.navigateByUrl(this.previousUrl);
  }

}