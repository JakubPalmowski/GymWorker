
import { EventEmitter } from '@angular/core';
import { Mentor } from '../models/mentor';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { MentorProfile } from '../models/mentorProfile';
import { MentorList } from '../models/mentorList';
import { PupilProfile } from '../models/pupilProfile';


@Injectable({
  providedIn: 'root'
})
export class UserService{
    
  constructor(private http: HttpClient) { }
  
  GetAllTrainers(pageNumber: number, searchPhrase: string, sortBy: string, sortDirection: string, gymCityPhrase: string, gymNamePhrase: string): Observable<MentorList> {
    const params = new HttpParams()
                      .set('PageNumber', pageNumber.toString())
                      .set('SearchPhrase', searchPhrase)
                      .set('SortBy', sortBy)
                      .set('SortDirection', sortDirection)
                      .set('GymCityPhrase', gymCityPhrase)
                      .set('GymNamePhrase', gymNamePhrase);
  
    const options = { params: params };
  
    return this.http.get<MentorList>('https://localhost:7259/api/User/Trainer', options);
  }
  
  GetTrainerWithOpinionsById(id:string):Observable<MentorProfile>{
    return this.http.get<MentorProfile>('https://localhost:7259/api/User/Trainer/'+id)
  }

      GetAllDieteticians(pageNumber: number, searchPhrase: string, sortBy: string, sortDirection: string):Observable<MentorList>{
        const params = new HttpParams()
                            .set('PageNumber', pageNumber.toString())
                            .set('SearchPhrase', searchPhrase)
                            .set('SortBy', sortBy)
                            .set('SortDirection', sortDirection);

        const options = { params: params };
        return this.http.get<MentorList>('https://localhost:7259/api/User/Dietician', options);
      }

      GetDieticianWithOpinionsById(id:string):Observable<MentorProfile>{
        return this.http.get<MentorProfile>('https://localhost:7259/api/User/Dietician/'+id)
      }

      GetPupilById(id: string):Observable<PupilProfile>{
        return this.http.get<PupilProfile>('https://localhost:7259/api/User/Pupil/'+id)
      }

    

     
}