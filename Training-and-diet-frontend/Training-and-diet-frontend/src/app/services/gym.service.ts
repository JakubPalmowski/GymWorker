import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ActiveGym } from '../models/activeGym';

@Injectable({
  providedIn: 'root'
})
export class GymService {

  constructor(private http: HttpClient) { }
  

  GetAllActiveGyms():Observable<ActiveGym[]>{
    return this.http.get<ActiveGym[]>('https://localhost:7259/api/Gym')
  }
  GetAllActiveMentorGyms(id:string):Observable<ActiveGym[]>{ 
    return this.http.get<ActiveGym[]>('https://localhost:7259/api/Gym/Mentor/'+id)
  }
}
