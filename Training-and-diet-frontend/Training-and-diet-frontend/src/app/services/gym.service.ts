import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ActiveGym } from '../models/gym/activeGym';
import { CreateGym } from '../models/gym/createGym';
import { GymsAddedByUser } from '../models/gym/gymsAddedByUser';

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
  CreateGym(gym:CreateGym):Observable<CreateGym>{
    return this.http.post<CreateGym>('https://localhost:7259/api/Gym',gym)
  }
  GetGymsAddedByUser(id:string):Observable<GymsAddedByUser[]>{ 
    return this.http.get<GymsAddedByUser[]>('https://localhost:7259/api/Gym/User/'+id)
  }
}
