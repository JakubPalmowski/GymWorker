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
  fieldErrors: { [key: string]: string[] } = {};
  errorFlag: string = "";
  
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
    
    if(id){
      this.idDietMeal=id;
    this.mealServise.getDietMealById(this.idDietMeal).subscribe({
      next:(meal)=>{
        this.newMealDietRequest=meal;
      },
      error: (response)=>{
      }
    })
  }
  }})
  }

  

  onSubmit(valid:any){
    this.submitted=true;
    if(valid){
      
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
    this.fieldErrors = {};
    this.mealServise.editDietMeal(this.newMealDietRequest,this.idDietMeal).subscribe({
      next:(newTrainingExercise)=>{
        this.router.navigate(['/diet/edit/'+this.idDiet]);
      },error:(error)=>{
        if(error.status===400){
         const {errors} = error.error;
         for(const key in errors){
           if(errors.hasOwnProperty(key)){
             this.fieldErrors[key] = errors[key]; 
           }
         }
        }else{
             this.errorFlag = "error";
             this.showErrorPopup(this.errorFlag);
             document.documentElement.scrollTop = 0;
        }
      }
    })
    

  }

  showErrorPopup(status: string) {
    if(status == "error"){
      setTimeout(() => this.errorFlag="", 3000); 
    }
  
  }

  back(){
    this.router.navigate(['/diet/edit/'+this.idDiet],{queryParams:{id:this.idDiet}});
  }
}
