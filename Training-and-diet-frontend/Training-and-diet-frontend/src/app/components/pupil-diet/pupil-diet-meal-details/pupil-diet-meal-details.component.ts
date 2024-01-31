import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DietMealPupilGet } from 'src/app/models/diet/diet-meal-pupil-get.model';
import { MealsService } from 'src/app/services/meals.service';
import { PreviousUrlService } from 'src/app/services/previous-url.service';

@Component({
  selector: 'app-pupil-diet-meal-details',
  templateUrl: './pupil-diet-meal-details.component.html',
  styleUrls: ['./pupil-diet-meal-details.component.css']
})
export class PupilDietMealDetailsComponent implements OnInit {

  previousUrl:string='';

  dietMeal:DietMealPupilGet={
    idMealDiet: 0,
    idMeal: 0,
    idDiet: 0,
    comments: '',
    dayOfWeek: '',
    hourOfMeal: '',
    mealName: '',
    ingredients: '',
    prepareSteps: '',
    kcal: ''
  }

  kcal:string='';
  proteins:string='';
  fats:string='';
  carbs:string='';

  idDietMeal:string='';

  constructor(private route:ActivatedRoute, private router:Router,private mealService:MealsService, private previousUrlService:PreviousUrlService) { }

  ngOnInit(): void {

    this.previousUrl=this.previousUrlService.getPreviousUrl();
    this.route.paramMap.subscribe({
      next:(params)=>{
        const id=params.get('id');
        if(id){
        this.idDietMeal=id;
        console.log(id);  
        }

      }});

      this.mealService.getPupilDietMealById(this.idDietMeal).subscribe({
        next:(response)=>{
          this.dietMeal=response;
          console.log(response);
          var kpfc=this.dietMeal.kcal.split(',');
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


  back(){
    this.router.navigateByUrl(this.previousUrl);
  }
}
