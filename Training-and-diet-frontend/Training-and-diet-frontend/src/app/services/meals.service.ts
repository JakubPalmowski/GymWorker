import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MealFull } from '../models/meal/meal-full.model';
import { environment } from 'src/environments/environment';
import { NewMealDiet } from '../models/diet/new-meal-diet.model';
import { EditDietMeal } from '../models/diet/edit-diet-meal.model';

@Injectable({
  providedIn: 'root'
})
export class MealsService {

  constructor(private http: HttpClient) {}

  getDieteticianMeals():Observable<MealFull[]>{
    return this.http.get<MealFull[]>(environment.apiUrl+'Meal/dietician');
  }

  getMealById(idMeal:string):Observable<MealFull>{
    return this.http.get<MealFull>('https://localhost:7259/api/Meal/'+idMeal);
  }

  addDieteticanMeal(addDieteticianMealRequest:MealFull):Observable<MealFull>{
    return this.http.post<MealFull>('https://localhost:7259/api/Meal',addDieteticianMealRequest);
  }

  editDieteticianMeal(editDieteticianMealRequest:MealFull, idMeal:string):Observable<MealFull>{
    return this.http.put<MealFull>('https://localhost:7259/api/Meal/'+idMeal,editDieteticianMealRequest);
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



}
