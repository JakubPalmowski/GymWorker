
import { EventEmitter } from '@angular/core';
import { Mentor } from '../models/mentor';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { MentorProfile } from '../models/mentorProfile';
import { MentorList } from '../models/mentorList';
import { PupilProfile } from '../models/pupilProfile';
import { PupilPersonalInfo } from '../models/MyProfile/pupilPersonalInfo';
import { TrainerPersonalInfo } from '../models/MyProfile/trainerPersonalInfo';
import { UserPersonalInfo } from '../models/MyProfile/userPersonalInfo';
import { DieticianPersonalInfo } from '../models/MyProfile/dieticianPersonalInfo';
import { DieticianTrainerPersonalInfo } from '../models/MyProfile/dieticianTrainerPersonalInfo';


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

      GetPupilPersonalInfoById(id: string):Observable<UserPersonalInfo>{
        return this.http.get<UserPersonalInfo>('https://localhost:7259/api/User/Pupil/PersonalInfo/'+id)
      }

      UpdatePupilPersonalInfo(pupilPersonalInfo: PupilPersonalInfo,id: string):Observable<any>{
        return this.http.put('https://localhost:7259/api/User/Pupil/'+id, pupilPersonalInfo);
      }

      GetTrainerPersonalInfoById(id: string):Observable<UserPersonalInfo>{
        return this.http.get<UserPersonalInfo>('https://localhost:7259/api/User/Trainer/PersonalInfo/'+id)
      }

      UpdateTrainerPersonalInfo(trainerPersonalInfo: TrainerPersonalInfo,id: string):Observable<any>{
        return this.http.put('https://localhost:7259/api/User/Trainer/'+id, trainerPersonalInfo);
      }

      GetDieticianPersonalInfoById(id: string):Observable<UserPersonalInfo>{
        return this.http.get<UserPersonalInfo>('https://localhost:7259/api/User/Dietician/PersonalInfo/'+id)
      }

      UpdateDieticianPersonalInfo(dieticianPersonalInfo: DieticianPersonalInfo,id: string):Observable<any>{
        return this.http.put('https://localhost:7259/api/User/Dietician/'+id, dieticianPersonalInfo);
      }

      GetDieticianTrainerPersonalInfoById(id: string):Observable<UserPersonalInfo>{
        return this.http.get<UserPersonalInfo>('https://localhost:7259/api/User/DieticianTrainer/PersonalInfo/'+id)
      }
      UpdateDieticianTrainerPersonalInfo(dieticianTrainerPersonalInfo: DieticianTrainerPersonalInfo,id: string):Observable<any>{
        return this.http.put('https://localhost:7259/api/User/DieticianTrainer/'+id, dieticianTrainerPersonalInfo);
      }
      

    

     
}