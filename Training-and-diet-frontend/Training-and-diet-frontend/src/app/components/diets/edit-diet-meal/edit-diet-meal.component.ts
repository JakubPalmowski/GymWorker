import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EditDietMeal } from 'src/app/models/diet/edit-diet-meal.model';
import { MealShort } from 'src/app/models/meal/meal-short.model';
import { NewMealDiet } from 'src/app/models/diet/new-meal-diet.model';
import { MealsService } from 'src/app/services/meals.service';
import { PreviousUrlService } from 'src/app/services/previous-url.service';

@Component({
  selector: 'app-edit-diet-meal',
  templateUrl: './edit-diet-meal.component.html',
  styleUrls: ['./edit-diet-meal.component.css']
})
export class EditDietMealComponent implements OnInit{

  idDietMeal:string='';
  idDiet:string='';
  idMeal:string='';


  newMealDietRequest:EditDietMeal={
    idMeal: 0,
    idDiet: 0,
    comments: '',
    dayOfWeek: 1,
    hourOfMeal: '',
    idMealDiet: 0,
    name: ''
  }

  

  
   

  submitted=false;
  
  previousUrl:string='';

  constructor(private mealServise:MealsService, private route:ActivatedRoute,private router:Router,private previousUrlService: PreviousUrlService){
 
  }
     

  ngOnInit(): void {

    this.route.paramMap.subscribe({
      next:(params)=>{
        const id=params.get('id');
    this.previousUrl=this.previousUrlService.getPreviousUrl();

    this.idDiet=this.route.snapshot.queryParams['dietId'];
    this.idMeal=this.route.snapshot.queryParams['mealId'];
    console.log("diet: "+this.idDiet);
    console.log("meal: "+this.idMeal);
    if(id){
      this.idDietMeal=id;
    this.mealServise.getDietMealById(this.idMeal).subscribe({
      next:(meal)=>{
        this.newMealDietRequest=meal;
        console.log(this.newMealDietRequest.name);
      },
      error: (response)=>{

        console.log(response);
      }
    })
  }
  }})
  }

  

  onSubmit(valid:any){
    this.submitted=true;
    if(valid){
      console.log(this.newMealDietRequest);
      
      this.editDietMeal();
    }
  }
  
  assignValue(){
    this.newMealDietRequest.dayOfWeek=parseInt(this.newMealDietRequest.dayOfWeek.toString());
  }

  editDietMeal(){
    this.newMealDietRequest.idMeal=parseInt(this.idMeal);
    this.newMealDietRequest.idDiet=parseInt(this.idDiet);
    const responseDiv = document.getElementById("edit-resp");
    
    this.mealServise.addDietMeal(this.newMealDietRequest).subscribe({
      next:(newTrainingExercise)=>{
        this.router.navigate(['/diet/edit/'+this.idDiet]);
      },error:(response)=>{
        console.log(response);
        if(responseDiv){
          responseDiv.innerHTML="Podczas edycji wystąpił błąd";
          
        }
      }
    })
    

  }

  back(){
    this.router.navigate(['/diet/edit/'+this.idDiet],{queryParams:{id:this.idDiet}});
  }
}
