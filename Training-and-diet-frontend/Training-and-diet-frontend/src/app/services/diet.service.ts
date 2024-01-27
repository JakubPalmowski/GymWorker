import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { DietListDietician } from '../models/diet/diet-list-dietician.model';
import { Observable } from 'rxjs';
import { DietAddEdit } from '../models/diet/diet-add-edit.model';
import { DietMentorGet } from '../models/diet/diet-mentor-get.model';
import { MealDietMentorList } from '../models/diet/meal-diet-mentor-list.model';


@Injectable({
  providedIn: 'root'
})
export class DietService {

  constructor(private http: HttpClient) { }

  getDieticianDiets():Observable<DietListDietician[]>{
    return this.http.get<DietListDietician[]>(environment.apiUrl+'unimplemented');
   }

   getDieticianDietById(idDiet:string):Observable<DietMentorGet>{
    return this.http.get<DietMentorGet>(environment.apiUrl+'unimplemented/'+idDiet);
   }

   addDiet(addDietRequest: DietAddEdit):Observable<DietAddEdit>{
    return this.http.post<DietAddEdit>(environment.apiUrl+'unimplemented',addDietRequest);
  }

  editDiet(editDietRequest: DietAddEdit,idTrainingPlan:string):Observable<DietAddEdit>{
    return this.http.put<DietAddEdit>(environment.apiUrl+'unimplemented'+idTrainingPlan,editDietRequest);
  }

  getDietMealsByDietId(idDiet:string):Observable<MealDietMentorList[]>{
    return this.http.get<MealDietMentorList[]>(environment.apiUrl+'unimplemented/'+idDiet);
  }
}
