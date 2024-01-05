import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TrainingPlan } from '../models/trainingPlan.model';
import { NewLineKind } from 'typescript';
import { NewTrainingPlan } from '../models/new-training-plan.model';
import { TrainingPlanExercise } from '../models/trainingPlanExercise.model';
import { EditTrainingPlan } from '../models/edit-training-plan.model';

@Injectable({
  providedIn: 'root'
})
export class TrainingPlanService {

  constructor(private http: HttpClient) { }

  getTrainerPlans():Observable<TrainingPlan[]>{
   return this.http.get<TrainingPlan[]>('https://localhost:7259/api/User/1/trainingPlans');
  }

  getTrainingPlanById(idPlan:string):Observable<EditTrainingPlan>{
    return this.http.get<EditTrainingPlan>('https://localhost:7259/api/TrainingPlan/'+idPlan);
   }

  addTrainingPlan(addTrainingPlanRequest: NewTrainingPlan):Observable<NewTrainingPlan>{
    return this.http.post<NewTrainingPlan>('https://localhost:7259/api/TrainingPlan',addTrainingPlanRequest);
  }

  getExercisesByPlanId(planId:string):Observable<TrainingPlanExercise[]>{
    return this.http.get<TrainingPlanExercise[]>( 'https://localhost:7259/api/Exercise/trainingPlans/'+planId+'/exercises');
   }
}
