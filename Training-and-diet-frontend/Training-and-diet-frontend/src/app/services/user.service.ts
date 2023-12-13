
import { EventEmitter } from '@angular/core';
import { Mentor } from '../models/mentor';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { TrainerProfile } from '../models/trainerProfile';


@Injectable({
  providedIn: 'root'
})
export class UserService{
    
  constructor(private http: HttpClient) { }
  
      GetAllTrainers():Observable<Mentor[]>{
        return this.http.get<Mentor[]>('https://localhost:7259/api/User/Trainer');
      }

      GetTrainerWithOpinionsById(id:string):Observable<TrainerProfile>{
        return this.http.get<TrainerProfile>('https://localhost:7259/api/User/Trainer/'+id)
      }

      GetAllDieteticians():Observable<Mentor[]>{
        return this.http.get<Mentor[]>('https://localhost:7259/api/User/Dietician');
      }
}