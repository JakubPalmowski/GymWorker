import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { DietListDietician } from '../models/diet/DietListDietician.model';
import { Observable } from 'rxjs';
import { DietAddEdit } from '../models/diet/DietAddEdit.model';


@Injectable({
  providedIn: 'root'
})
export class DietService {

  constructor(private http: HttpClient) { }

  getDieticianDiets():Observable<DietListDietician[]>{
    return this.http.get<DietListDietician[]>(environment.apiUrl+'unimplemented');
   }

   addDiet(addDietRequest: DietAddEdit):Observable<DietAddEdit>{
    return this.http.post<DietAddEdit>(environment.apiUrl+'unimplemented',addDietRequest);
  }

  editDiet(editDietRequest: DietAddEdit,idTrainingPlan:string):Observable<DietAddEdit>{
    return this.http.put<DietAddEdit>(environment.apiUrl+'unimplemented'+idTrainingPlan,editDietRequest);
  }
}
