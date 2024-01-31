import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { DietListDietician } from '../models/diet/diet-list-dietician.model';
import { Observable } from 'rxjs';
import { DietAddEdit } from '../models/diet/diet-add-edit.model';
import { DietMentorGet } from '../models/diet/diet-mentor-get.model';
import { DietPupilList } from '../models/diet/diet-pupil-list.model';
import { FullPupilDietGet } from '../models/diet/full-pupil-diet-get.model';
import { MealDietList } from '../models/diet/meal-diet-list.model';


@Injectable({
  providedIn: 'root'
})
export class DietService {

  constructor(private http: HttpClient) { }

  getDieticianDiets():Observable<DietListDietician[]>{
    return this.http.get<DietListDietician[]>(environment.apiUrl+'Diet/Dietician');
   }

   getPupilDiets():Observable<DietPupilList[]>{
    return this.http.get<DietPupilList[]>(environment.apiUrl+'Diet/Pupil');
   }

   getDieticianDietById(idDiet:string):Observable<DietMentorGet>{
    return this.http.get<DietMentorGet>(environment.apiUrl+'Diet/Mentor/'+idDiet);
   }

   getPupilDietById(idDiet:string):Observable<FullPupilDietGet>{
    return this.http.get<FullPupilDietGet>(environment.apiUrl+'Diet/Pupil/'+idDiet);
   }

   addDiet(addDietRequest: DietAddEdit):Observable<DietAddEdit>{
    return this.http.post<DietAddEdit>(environment.apiUrl+'Diet',addDietRequest);
  }

  editDiet(editDietRequest: DietAddEdit,idDiet:string):Observable<DietAddEdit>{
    return this.http.put<DietAddEdit>(environment.apiUrl+'Diet/'+idDiet,editDietRequest);
  }

  getDietMealsByDietId(idDiet:string):Observable<MealDietList[]>{
    return this.http.get<MealDietList[]>(environment.apiUrl+'MealDiet/Meals/'+idDiet);
  }

  assignDiet(dietId:string,pupilId:string){
    return this.http.put(environment.apiUrl+'Diet/assignPupilToDiet/'+dietId,{  "idPupil": pupilId});
 }
}
