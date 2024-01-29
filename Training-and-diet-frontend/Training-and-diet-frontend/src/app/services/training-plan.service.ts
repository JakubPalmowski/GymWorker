import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TrainingPlan } from '../models/training-plan/training-plan.model';
import { NewLineKind } from 'typescript';
import { FullTrainingPlan } from '../models/diet/full-training-plan.model';
import { TrainingPlanExercise } from '../models/training-plan/training-plan-exercise.model';
import { TrainingExerciseFull } from '../models/training-plan/training-exercise-full.model';
import { FullTrainingPlanGet } from '../models/training-plan/full-training-plan-get.model';
import { AuthenticationService } from './authentication.service';
import { environment } from 'src/environments/environment';
import { TrainingPlanPupilList } from '../models/training-plan/training-plan-pupil-list.model';
import { FullPupilsTrainingPlanGet } from '../models/training-plan/full-pupils-training-plan-get.model';

@Injectable({
  providedIn: 'root'
})
export class TrainingPlanService {

  constructor(private http: HttpClient,private authenticationService:AuthenticationService) { }

  getTrainerPlans():Observable<TrainingPlan[]>{
   return this.http.get<TrainingPlan[]>(environment.apiUrl+'TrainingPlan/trainerPlans');
  }

  getPupilPlans():Observable<TrainingPlanPupilList[]>{
    return this.http.get<TrainingPlanPupilList[]>(environment.apiUrl+'TrainingPlan/pupilPlans');
   }

  getTrainerTrainingPlanById(idPlan:string):Observable<FullTrainingPlanGet>{
    return this.http.get<FullTrainingPlanGet>(environment.apiUrl+'TrainingPlan/trainer/'+idPlan);
   }

   getPupilTrainingPlanById(idPlan:string):Observable<FullPupilsTrainingPlanGet>{
    return this.http.get<FullPupilsTrainingPlanGet>(environment.apiUrl+'TrainingPlan/pupil/'+idPlan);
   }

  addTrainingPlan(addTrainingPlanRequest: FullTrainingPlan):Observable<FullTrainingPlan>{
    return this.http.post<FullTrainingPlan>(environment.apiUrl+'TrainingPlan',addTrainingPlanRequest);
  }

  editTrainingPlan(addTrainingPlanRequest: FullTrainingPlan,idTrainingPlan:string):Observable<FullTrainingPlan>{
    return this.http.put<FullTrainingPlan>(environment.apiUrl+'TrainingPlan/'+idTrainingPlan,addTrainingPlanRequest);
  }

  getExercisesByPlanId(planId:string):Observable<TrainingExerciseFull[]>{
    return this.http.get<TrainingExerciseFull[]>( environment.apiUrl+'TraineeExercises/trainingPlanInternal/'+planId);
   }

   assignPlanToPupil(planId:string,pupilId:string){
      return this.http.put(environment.apiUrl+'TrainingPlan/assignPupilToTrainingPlan/'+planId,{  "idPupil": pupilId});
   }

   
}
