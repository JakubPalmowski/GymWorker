import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MealFull } from '../models/meal-full';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MealsService {

  constructor(private http: HttpClient) {}

  getDieteticianMeals():Observable<MealFull[]>{
    return this.http.get<MealFull[]>('https://localhost:7259/dietician');
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
}
