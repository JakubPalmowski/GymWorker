import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TrainingPlanExercise } from '../models/trainingPlanExercise.model';
import { ExerciseShort } from '../models/exercise-short.model';
import { ExerciseGetById } from '../models/exercise-get-by-id';
import { NewTrainingExercise } from '../models/new-training-exercise.model';
import { Exercise } from '../models/exercise';
import { ExerciseFull } from '../models/exercise-full';
import { environment } from 'src/environments/environment';
import { EditTrainingExercise } from '../models/editTrainingExercise.model';

@Injectable({
  providedIn: 'root'
})
export class ExercisesService {

  constructor(private http: HttpClient) { }

  getTrainerExercises():Observable<ExerciseShort[]>{
    return this.http.get<ExerciseShort[]>(environment.apiUrl+'Exercise/trainer/exercises');
   }

   getExerciseById(idExercise:string):Observable<ExerciseFull>{
    return this.http.get<ExerciseFull>('https://localhost:7259/api/Exercise/'+idExercise);
   }

   editExercise(exerciseEdit:ExerciseFull, idExercise:string):Observable<ExerciseFull>{
    return this.http.put<ExerciseFull>('https://localhost:7259/api/Exercise/'+idExercise,exerciseEdit);
   }

   getAllExercises():Observable<ExerciseShort[]>{
    return this.http.get<ExerciseShort[]>('https://localhost:7259/api/Exercise');
   }

   addTrainingExercise(addTrainingExerciseRequest: NewTrainingExercise):Observable<NewTrainingExercise>{
    return this.http.post<NewTrainingExercise>('https://localhost:7259/api/TraineeExercises',addTrainingExerciseRequest);
  }

  editTrainingExercise(exerciseEdit:NewTrainingExercise, idTrainingExercise:string):Observable<NewTrainingExercise>{
    return this.http.put<NewTrainingExercise>('https://localhost:7259/api/TraineeExercises/'+idTrainingExercise,exerciseEdit);
   }

   getTrainingExerciseById(idExercise:string):Observable<EditTrainingExercise>{
    return this.http.get<EditTrainingExercise>('https://localhost:7259/api/TraineeExercises/trainer/'+idExercise);
   }

  addTrainerExercise(addTrainerExerciceRequest: Exercise):Observable<Exercise>{
    return this.http.post<Exercise>('https://localhost:7259/api/Exercise',addTrainerExerciceRequest);
  }

  deleteExercise(idExercise:string):Observable<string>{
    return this.http.delete<string>(environment.apiUrl+'Exercise/'+idExercise);
  }

  deleteTraineeExercise(idExercise:string):Observable<string>{
    return this.http.delete<string>(environment.apiUrl+'TraineeExercises/'+idExercise);
  }

 
}
