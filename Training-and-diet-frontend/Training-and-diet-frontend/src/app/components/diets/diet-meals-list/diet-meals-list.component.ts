import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MealsService } from 'src/app/services/meals.service';
import { Location } from '@angular/common';
import { MealFull } from 'src/app/models/meal-full';

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


  constructor(private mealServise:MealsService, private route:ActivatedRoute, private location:Location, private router:Router) {}


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

  openDeleteDialog(){
    console.log("open");
    this.deleteErrorFlag=false;
    if(this.deleteDialogFlag!=true){
     this.deleteDialogFlag=true;
    
   }
   }
 
   deleteMeal(idMeal:number) {
     console.log("delete");
     this.mealServise.deleteMeal(idMeal.toString()).subscribe({
       next:(response)=>{
         console.log(response);
         this.deleteDialogFlag=false;
         window.location.reload();
       },
       error:(response)=>{
         console.log(response);
         this.deleteErrorFlag=true;
       }});
 
     }
 
   cancelDelete(){
     console.log("cancel");
     this.deleteDialogFlag=false;
   }


  back(): void{
    this.router.navigateByUrl('/diet/edit/'+this.id_diet);
  }

}
