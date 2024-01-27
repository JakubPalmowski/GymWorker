
import { EventEmitter } from '@angular/core';
import { Mentor } from '../models/mentor-pupil/mentor.model';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { Injectable } from '@angular/core';
import { MentorProfile } from '../models/mentor-pupil/mentor-profile.model';
import { MentorList } from '../models/mentor-pupil/mentor-list.model';
import { PupilProfile } from '../models/mentor-pupil/pupil-profile.model';
import { PupilPersonalInfo } from '../models/my-profile/pupil-personal-info.model';
import { TrainerPersonalInfo } from '../models/my-profile/trainer-personal-info.model';
import { UserPersonalInfo } from '../models/my-profile/user-personal-info.model';
import { DieticianPersonalInfo } from '../models/my-profile/dietician-personal-info.model';
import { DieticianTrainerPersonalInfo } from '../models/my-profile/dietician-trainer-personal-info.model';
import { PupilShort } from '../models/mentor-pupil/pupil-short.model';
import { environment } from 'src/environments/environment';
import { Invitation } from '../models/mentor-pupil/invitation.model';


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

      GetPupilPersonalInfo():Observable<UserPersonalInfo>{
        return this.http.get<UserPersonalInfo>('https://localhost:7259/api/User/Pupil/PersonalInfo')
      }

      UpdatePupilPersonalInfo(pupilPersonalInfo: PupilPersonalInfo):Observable<any>{
        return this.http.put('https://localhost:7259/api/User/Pupil', pupilPersonalInfo);
      }

      GetTrainerPersonalInfo():Observable<UserPersonalInfo>{
        return this.http.get<UserPersonalInfo>('https://localhost:7259/api/User/Trainer/PersonalInfo')
      }


      GetDieticianPersonalInfo():Observable<UserPersonalInfo>{
        return this.http.get<UserPersonalInfo>('https://localhost:7259/api/User/Dietician/PersonalInfo')
      }

      UpdateDieticianPersonalInfo(dieticianPersonalInfo: DieticianPersonalInfo):Observable<any>{
        return this.http.put('https://localhost:7259/api/User/Dietician', dieticianPersonalInfo);
      }

      GetDieticianTrainerPersonalInfo():Observable<UserPersonalInfo>{
        return this.http.get<UserPersonalInfo>('https://localhost:7259/api/User/DieticianTrainer/PersonalInfo')
      }
      UpdateDieticianTrainerPersonalInfo(dieticianTrainerPersonalInfo: DieticianTrainerPersonalInfo):Observable<any>{
        return this.http.put('https://localhost:7259/api/User/DieticianTrainer', dieticianTrainerPersonalInfo);
      }

      UpdateTrainerPersonalInfo(trainerPersonalInfo: TrainerPersonalInfo):Observable<any>{
        return this.http.put('https://localhost:7259/api/User/Trainer', trainerPersonalInfo);
      }
      
      GetMentorPupils():Observable<PupilShort[]>{
        return this.http.get<PupilShort[]>(environment.apiUrl+'MentorPupil/MentorPupils');
      }

      sendInvitation(mentorId: string):Observable<any>{
        return this.http.post(environment.apiUrl+'User/Pupil/Invitation/'+mentorId, null);
      }

      deleteInvitation(userId: string):Observable<any>{
        return this.http.delete(environment.apiUrl+'User/Invitation/'+userId);
      }

      getUserImage():Observable<any>{
        return this.http.get<any>(environment.apiUrl+'User/Image');
      }

      getMentorInvitations():Observable<Invitation[]>{
        return this.http.get<Invitation[]>(environment.apiUrl+'User/Invitations');
      }

      acceptInvitation(userId: string):Observable<any>{
        return this.http.put(environment.apiUrl+'User/Invitations/'+userId, null);
      }

      getMentorPupils():Observable<Invitation[]>{
        return this.http.get<Invitation[]>(environment.apiUrl+'MentorPupil/MentorPupils');
      }



      private userImageChangedSubject = new Subject<boolean>();


      public userImageChangedObservable = this.userImageChangedSubject.asObservable();

      notifyUserImageChanged(): void {
      this.userImageChangedSubject.next(true);
    }
    

     
}