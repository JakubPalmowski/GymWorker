import { Component, OnInit } from '@angular/core';
import { MealsService } from 'src/app/services/meals.service';
import { Location } from '@angular/common';
import { MealFull } from 'src/app/models/meal-full';
import { ActivatedRoute, Router } from '@angular/router';
import { PreviousUrlService } from 'src/app/services/previous-url.service';


@Component({
  selector: 'app-meals-edit',
  templateUrl: './meals-edit.component.html',
  styleUrls: ['./meals-edit.component.css']
})
export class MealsEditComponent implements OnInit{

  previousUrl:string='';

  editDieteticianMealRequest:MealFull={
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

  edit(){

  }

  back(): void{
    this.router.navigateByUrl(this.previousUrl);
  }

}