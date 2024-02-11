import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MealsService } from 'src/app/services/meals.service';
import { Location } from '@angular/common';
import { MealFull } from 'src/app/models/meal/meal-full.model';

@Component({
  selector: 'app-diet-meals-list',
  templateUrl: './diet-meals-list.component.html',
  styleUrls: ['./diet-meals-list.component.css']
})
export class DietMealsListComponent implements OnInit{

  DieteticianMeals:MealFull[]=[];
  DieteticianMealsFiltered:MealFull[]=[];

  id_diet:string='';
  deleteDialogFlag: boolean=false;
  deleteErrorFlag: boolean=false;
  searchTerm: string = '';


  constructor(private mealServise:MealsService, private route:ActivatedRoute, private location:Location, private router:Router) {}


  ngOnInit(): void {
 
     this.id_diet=this.route.snapshot.queryParams['id'];
    
     this.mealServise.getDieteticianMeals().subscribe({
      next:(meals)=>{
        this.DieteticianMeals=meals;
        this.DieteticianMealsFiltered=this.DieteticianMeals;

      },
      error:(response)=>{
      }
     })
    
   }

   filterResults() {
    if (!this.searchTerm) {
      this.DieteticianMealsFiltered = this.DieteticianMeals; 
    } else {
      this.DieteticianMealsFiltered = this.DieteticianMeals?.filter(meal =>
        meal.name.toLowerCase().includes(this.searchTerm.toLowerCase())
      );
    }
  }

  openDeleteDialog(){
    this.deleteErrorFlag=false;
    if(this.deleteDialogFlag!=true){
     this.deleteDialogFlag=true;
    
   }
   }
 
   deleteMeal(idMeal:number) {
     this.mealServise.deleteMeal(idMeal.toString()).subscribe({
       next:(response)=>{
         this.deleteDialogFlag=false;
         window.location.reload();
       },
       error:(response)=>{
         this.deleteErrorFlag=true;
       }});
 
     }
 
   cancelDelete(){
     this.deleteDialogFlag=false;
   }


  back(): void{
    this.router.navigateByUrl('/diet/edit/'+this.id_diet);
  }

}
