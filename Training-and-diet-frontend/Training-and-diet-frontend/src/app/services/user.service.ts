
import { EventEmitter } from '@angular/core';
import { Mentor } from '../models/mentor';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { MentorProfile } from '../models/mentorProfile';
import { MentorList } from '../models/mentorList';


@Injectable({
  providedIn: 'root'
})
export class UserService{
    
  constructor(private http: HttpClient) { }
  
      GetAllTrainers(pageNumber: number, searchPhrase: string):Observable<MentorList>{
    const params = new HttpParams()
                      .set('PageNumber', pageNumber.toString())
                      .set('SearchPhrase', searchPhrase);
                

        const options = { params: params };

        return this.http.get<MentorList>('https://localhost:7259/api/User/Trainer', options);
      }

      GetTrainerWithOpinionsById(id:string):Observable<MentorProfile>{
        return this.http.get<MentorProfile>('https://localhost:7259/api/User/Trainer/'+id)
      }

      //Do ogarnięcia
      GetAllDieteticians(pageNumber: number):Observable<MentorList>{
        const params = new HttpParams().set('PageNumber', pageNumber.toString());

        const options = { params: params };
        return this.http.get<MentorList>('https://localhost:7259/api/User/Dietician', options);
      }

      GetDieticianWithOpinionsById(id:string):Observable<MentorProfile>{
        return this.http.get<MentorProfile>('https://localhost:7259/api/User/Dietician/'+id)
      }

     
}