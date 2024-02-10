import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ActiveGym } from '../models/gym/active-gym.model';
import { CreateGym } from '../models/gym/create-gym.model';
import { GymsAddedByUser } from '../models/gym/gyms-added-by-user.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GymService {

  constructor(private http: HttpClient) { }
  

  GetAllActiveGyms():Observable<ActiveGym[]>{
    return this.http.get<ActiveGym[]>(environment.apiUrl+'Gym')
  }
  GetAllActiveMentorGyms(id:string):Observable<ActiveGym[]>{ 
    return this.http.get<ActiveGym[]>(environment.apiUrl+'Gym/Mentor/'+id)
  }
  CreateGym(gym:CreateGym):Observable<CreateGym>{
    return this.http.post<CreateGym>(environment.apiUrl+'Gym',gym)
  }
  GetGymsAddedByUser(id:string):Observable<GymsAddedByUser[]>{ 
    return this.http.get<GymsAddedByUser[]>(environment.apiUrl+'Gym/User/'+id)
  }
}
