import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TrainingPlanExercise } from '../models/trainingPlanExercise.model';
import { ExerciseShort } from '../models/exercise-short.model';
import { ExerciseGetById } from '../models/exercise-get-by-id';
import { NewTrainingExercise } from '../models/new-training-exercise.model';

@Injectable({
  providedIn: 'root'
})
export class ExercisesService {

  constructor(private http: HttpClient) { }

  getTrainerExercises():Observable<ExerciseShort[]>{
    return this.http.get<ExerciseShort[]>('https://localhost:7259/api/User/1/exercises');
   }

   getExerciseById(idExercise:string):Observable<ExerciseGetById>{
    return this.http.get<ExerciseGetById>('https://localhost:7259/api/Exercise/'+idExercise);
   }

   getAllExercises():Observable<ExerciseShort[]>{
    return this.http.get<ExerciseShort[]>('');
   }

   addTrainingExercise(addTrainingExerciseRequest: NewTrainingExercise):Observable<NewTrainingExercise>{
    return this.http.post<NewTrainingExercise>('https://localhost:7259/api/TraineeExercises',addTrainingExerciseRequest);
  }

 
}
