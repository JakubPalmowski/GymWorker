import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MealFull } from '../models/meal-full';
import { environment } from 'src/environments/environment';
import { NewMealDiet } from '../models/diet/NewMealDiet.model';
import { EditDietMeal } from '../models/diet/EditDietMeal.model';

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
    return this.http.post<NewMealDiet>(environment.apiUrl+'unimplemented',addDietMealRequest);
  }

  editDietMeal(editDietMealRequest:NewMealDiet, idMeal:string):Observable<NewMealDiet>{
    return this.http.put<NewMealDiet>(environment.apiUrl+'unimplemented'+idMeal,editDietMealRequest);
  }

  deleteDietMeal(idMeal:string):Observable<string>{
    return this.http.delete<string>(environment.apiUrl+'unimplemented/'+idMeal);
  }

  getDietMealById(idMeal:string):Observable<EditDietMeal>{
    return this.http.get<EditDietMeal>(environment.apiUrl+'unimplemented/'+idMeal);
  }



}
