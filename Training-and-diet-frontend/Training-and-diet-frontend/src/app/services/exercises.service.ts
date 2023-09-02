import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TrainingPlanExercise } from '../models/trainingPlanExercise.model';

@Injectable({
  providedIn: 'root'
})
export class ExercisesService {

  constructor(private http: HttpClient) { }

  getTrainerExercises():Observable<TrainingPlanExercise[]>{
    return this.http.get<TrainingPlanExercise[]>('https://localhost:7259/api/User/1/trainingPlans');
   }

   getAllExercises():Observable<TrainingPlanExercise[]>{
    return this.http.get<TrainingPlanExercise[]>('https://localhost:7259/api/User/1/trainingPlans');
   }
}
