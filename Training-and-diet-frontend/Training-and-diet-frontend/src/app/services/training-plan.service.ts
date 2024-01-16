import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TrainingPlan } from '../models/trainingPlan.model';
import { NewLineKind } from 'typescript';
import { FullTrainingPlan } from '../models/full-training-plan.model';
import { TrainingPlanExercise } from '../models/trainingPlanExercise.model';
import { TrainingExerciseFull } from '../models/training-exercise-full';
import { FullTrainingPlanGet } from '../models/full-training-plan-get';

@Injectable({
  providedIn: 'root'
})
export class TrainingPlanService {

  constructor(private http: HttpClient) { }

  getTrainerPlans():Observable<TrainingPlan[]>{
   return this.http.get<TrainingPlan[]>('https://localhost:7259/api/TrainingPlan/3/trainingPlans');
  }

  getPupilPlans():Observable<TrainingPlan[]>{
    return this.http.get<TrainingPlan[]>('https://localhost:7259/api/TrainingPlan/3/trainingPlans');
   }

  getTrainingPlanById(idPlan:string):Observable<FullTrainingPlanGet>{
    return this.http.get<FullTrainingPlanGet>('https://localhost:7259/api/TrainingPlan/'+idPlan);
   }

  addTrainingPlan(addTrainingPlanRequest: FullTrainingPlan):Observable<FullTrainingPlan>{
    return this.http.post<FullTrainingPlan>('https://localhost:7259/api/TrainingPlan',addTrainingPlanRequest);
  }

  editTrainingPlan(addTrainingPlanRequest: FullTrainingPlan,idTrainingPlan:string):Observable<FullTrainingPlan>{
    return this.http.put<FullTrainingPlan>('https://localhost:7259/api/TrainingPlan/'+idTrainingPlan,addTrainingPlanRequest);
  }

  getExercisesByPlanId(planId:string):Observable<TrainingExerciseFull[]>{
    return this.http.get<TrainingExerciseFull[]>( 'https://localhost:7259/api/TraineeExercises/trainingPlan/'+planId);
   }
}
