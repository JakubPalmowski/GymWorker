import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Gym } from '../models/gym';

@Injectable({
  providedIn: 'root'
})
export class GymService {

  constructor(private http: HttpClient) { }
  

  GetAllGyms():Observable<Gym[]>{
    return this.http.get<Gym[]>('https://localhost:7259/api/Gym')
  }
  GetAllMentorGyms(id:string):Observable<Gym[]>{ 
    return this.http.get<Gym[]>('https://localhost:7259/api/Gym/Mentor/'+id)
  }
}
