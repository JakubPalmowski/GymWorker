import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TrainingPlan } from '../models/trainingPlan.model';

@Injectable({
  providedIn: 'root'
})
export class TrainingPlanService {

  constructor(private http: HttpClient) { }

  getTrainerPlans():Observable<TrainingPlan[]>{
   return this.http.get<TrainingPlan[]>("https://localhost:7259/api/User/1/trainingPlans");
  }
}
