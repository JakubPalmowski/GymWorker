import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TrainingPlanExercise } from '../models/training-plan/training-plan-exercise.model';
import { ExerciseShort } from '../models/exercise/exercise-short.model';
import { ExerciseGetById } from '../models/exercise/exercise-get-by-id.model';
import { NewTrainingExercise } from '../models/training-plan/new-training-exercise.model';
import { Exercise } from '../models/exercise/exercise.model';
import { ExerciseFull } from '../models/exercise/exercise-full.model';
import { environment } from 'src/environments/environment';
import { EditTrainingExercise } from '../models/training-plan/edit-training-exercise.model';
import { PupilTraineeExerciseGet } from '../models/training-plan/pupil-trainee-exercise-get.model';

@Injectable({
  providedIn: 'root'
})
export class ExercisesService {

  constructor(private http: HttpClient) { }

  getTrainerExercises():Observable<ExerciseShort[]>{
    return this.http.get<ExerciseShort[]>(environment.apiUrl+'Exercise/trainer/exercises');
   }

   getExerciseById(idExercise:string):Observable<ExerciseFull>{
    return this.http.get<ExerciseFull>(environment.apiUrl+'Exercise/'+idExercise);
   }

   editExercise(exerciseEdit:ExerciseFull, idExercise:string):Observable<ExerciseFull>{
    return this.http.put<ExerciseFull>(environment.apiUrl+'Exercise/'+idExercise,exerciseEdit);
   }

   getAllExercises():Observable<ExerciseShort[]>{
    return this.http.get<ExerciseShort[]>(environment.apiUrl+'Exercise');
   }

   addTrainingExercise(addTrainingExerciseRequest: NewTrainingExercise):Observable<NewTrainingExercise>{
    return this.http.post<NewTrainingExercise>(environment.apiUrl+'TraineeExercises',addTrainingExerciseRequest);
  }

  editTrainingExercise(exerciseEdit:NewTrainingExercise, idTrainingExercise:string):Observable<NewTrainingExercise>{
    return this.http.put<NewTrainingExercise>(environment.apiUrl+'TraineeExercises/'+idTrainingExercise,exerciseEdit);
   }

   getTrainingExerciseById(idExercise:string):Observable<EditTrainingExercise>{
    return this.http.get<EditTrainingExercise>(environment.apiUrl+'TraineeExercises/trainer/'+idExercise);
   }

   getTrainingExerciseByIdForPupil(idExercise:string):Observable<PupilTraineeExerciseGet>{
    return this.http.get<PupilTraineeExerciseGet>(environment.apiUrl+'TraineeExercises/pupil/'+idExercise);
   }

  addTrainerExercise(addTrainerExerciceRequest: Exercise):Observable<Exercise>{
    return this.http.post<Exercise>(environment.apiUrl+'Exercise',addTrainerExerciceRequest);
  }

  deleteExercise(idExercise:string):Observable<string>{
    return this.http.delete<string>(environment.apiUrl+'Exercise/'+idExercise);
  }

  deleteTraineeExercise(idExercise:string):Observable<string>{
    return this.http.delete<string>(environment.apiUrl+'TraineeExercises/'+idExercise);
  }

 
}
