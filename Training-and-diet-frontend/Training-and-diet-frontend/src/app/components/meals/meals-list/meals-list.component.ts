import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MealsService } from 'src/app/services/meals.service';
import { Location } from '@angular/common';
import { MealFull } from 'src/app/models/meal/meal-full.model';

@Component({
  selector: 'app-meals-list',
  templateUrl: './meals-list.component.html',
  styleUrls: ['./meals-list.component.css']
})
export class MealsListComponent implements OnInit{

  DieteticianMeals:MealFull[]=[];
  DieteticianMealsFiltered:MealFull[]=[];

  id_diet:string='';
  deleteDialogFlag: boolean=false;
  deleteErrorFlag: boolean=false;
  searchTerm: string = '';
  selectedMeal : MealFull | null = null;
  showDialog:boolean = false;


  constructor(private mealServise:MealsService, private route:ActivatedRoute, private location:Location) {}


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



  openDeleteDialog(id: number){
    this.selectedMeal = this.DieteticianMealsFiltered?.find(g => g.idMeal === id) ?? null;
    if (this.selectedMeal) {
      this.showDialog = true;
    } else {
      alert('Posiłek nie został znaleziony.'); 
    }
  }
 


    confirmDelete() {
      if (this.selectedMeal) {
        this.mealServise.deleteMeal(this.selectedMeal.idMeal.toString()).subscribe({
          next: () => {
            this.ngOnInit(); 
          },
          error: (error) => {
            this.deleteErrorFlag=true;
          }
        });
        this.showDialog = false; 
      }
    }
 
    cancelDelete() {
      this.showDialog = false;
    }


}