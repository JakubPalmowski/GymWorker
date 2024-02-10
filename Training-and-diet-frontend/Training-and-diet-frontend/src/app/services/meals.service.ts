import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MealFull } from '../models/meal/meal-full.model';
import { environment } from 'src/environments/environment';
import { NewMealDiet } from '../models/diet/new-meal-diet.model';
import { EditDietMeal } from '../models/diet/edit-diet-meal.model';
import { DietMealPupilGet } from '../models/diet/diet-meal-pupil-get.model';

@Injectable({
  providedIn: 'root'
})
export class MealsService {

  constructor(private http: HttpClient) {}

  getDieteticianMeals():Observable<MealFull[]>{
    return this.http.get<MealFull[]>(environment.apiUrl+'Meal/dietician');
  }

  getMealById(idMeal:string):Observable<MealFull>{
    return this.http.get<MealFull>(environment.apiUrl+'Meal/'+idMeal);
  }

  addDieteticanMeal(addDieteticianMealRequest:MealFull):Observable<MealFull>{
    return this.http.post<MealFull>(environment.apiUrl+'Meal',addDieteticianMealRequest);
  }

  editDieteticianMeal(editDieteticianMealRequest:MealFull, idMeal:string):Observable<MealFull>{
    return this.http.put<MealFull>(environment.apiUrl+'Meal/'+idMeal,editDieteticianMealRequest);
  }

  deleteMeal(idMeal:string):Observable<string>{
    return this.http.delete<string>(environment.apiUrl+'Meal/'+idMeal);
  }

  addDietMeal(addDietMealRequest:NewMealDiet):Observable<NewMealDiet>{
    return this.http.post<NewMealDiet>(environment.apiUrl+'MealDiet',addDietMealRequest);
  }

  editDietMeal(editDietMealRequest:NewMealDiet, idMeal:string):Observable<NewMealDiet>{
    return this.http.put<NewMealDiet>(environment.apiUrl+'MealDiet/'+idMeal,editDietMealRequest);
  }

  deleteDietMeal(idMeal:string):Observable<string>{
    return this.http.delete<string>(environment.apiUrl+'MealDiet/'+idMeal);
  }

  getDietMealById(idMeal:string):Observable<EditDietMeal>{
    return this.http.get<EditDietMeal>(environment.apiUrl+'MealDiet/Mentor/'+idMeal);
  }

  getPupilDietMealById(idMeal:string):Observable<DietMealPupilGet>{
    return this.http.get<DietMealPupilGet>(environment.apiUrl+'MealDiet/Pupil/'+idMeal);
  }



}
