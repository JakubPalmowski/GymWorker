import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TrainingPlan } from '../models/trainingPlan.model';
import { NewLineKind } from 'typescript';
import { NewTrainingPlan } from '../models/new-training-plan.model';

@Injectable({
  providedIn: 'root'
})
export class TrainingPlanService {

  constructor(private http: HttpClient) { }

  getTrainerPlans():Observable<TrainingPlan[]>{
   return this.http.get<TrainingPlan[]>('https://localhost:7259/api/User/1/trainingPlans');
  }

  addTrainingPlan(addTrainingPlanRequest: NewTrainingPlan):Observable<NewTrainingPlan>{
    return this.http.post<NewTrainingPlan>('https://localhost:7259/api/TrainingPlan',addTrainingPlanRequest);
  }
}
