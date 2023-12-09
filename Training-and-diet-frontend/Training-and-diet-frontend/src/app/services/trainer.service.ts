
import { EventEmitter } from '@angular/core';
import { Trainer } from '../models/trainer';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { TrainerProfile } from '../models/trainerProfile';


@Injectable({
  providedIn: 'root'
})
export class TrainerService{
    
  constructor(private http: HttpClient) { }
  
      trainerId:number=0;
      setTrainerId(id: number){
        this.trainerId=id;
      }

      getTrainerId(){
        return this.trainerId;
      }

      GetAllTrainers():Observable<Trainer[]>{
        return this.http.get<Trainer[]>('https://localhost:7259/api/User/trainers');
      }

      GetTrainerWithOpinionsById(id:string):Observable<TrainerProfile>{
        return this.http.get<TrainerProfile>('https://localhost:7259/api/User/trainers/'+id)
      }
}