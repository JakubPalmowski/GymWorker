import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MealFull } from '../models/meal-full';
import { ExerciseFull } from '../models/exercise-full';

@Injectable({
  providedIn: 'root'
})
export class MealsService {

  constructor(private http: HttpClient) {}

  getDieteticianMeals():Observable<MealFull[]>{
    return this.http.get<MealFull[]>('https://localhost:7259/api/Meal/1/meals');
  }

  getMealById(idMeal:string):Observable<MealFull>{
    return this.http.get<MealFull>('https://localhost:7259/api/Meal/'+idMeal);
  }

  addDieteticanMeal(addDieteticianMealRequest:MealFull):Observable<MealFull>{
    return this.http.post<MealFull>('https://localhost:7259/api/Meal',addDieteticianMealRequest);
  }

  editDieteticianMeal(editDieteticianMealRequest:MealFull, idMeal:string):Observable<MealFull>{
    return this.http.put<MealFull>('',editDieteticianMealRequest);
  }
}
