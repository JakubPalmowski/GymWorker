import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TrainingPlan } from '../models/trainingPlan.model';
import { NewLineKind } from 'typescript';
import { FullTrainingPlan } from '../models/full-training-plan.model';
import { TrainingPlanExercise } from '../models/trainingPlanExercise.model';
import { TrainingExerciseFull } from '../models/training-exercise-full';
import { FullTrainingPlanGet } from '../models/full-training-plan-get';
import { AuthenticationService } from './authentication.service';
import { environment } from 'src/environments/environment';
import { TrainingPlanPupilList } from '../models/TrainingPlanPupilList.model';
import { FullPupilsTrainingPlanGet } from '../models/FullPupilsTrainingPlanGet';

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
