import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GymAdminInfo } from '../models/admin/gymAdminInfo';
import { GymDetailsAdmin } from '../models/admin/gymDetailsAdmin';
import { GymUpdate } from '../models/admin/gymUpdate';
import { ExerciseShort } from '../models/exercise-short.model';
import { NewTrainingExercise } from '../models/new-training-exercise.model';
import { Exercise } from '../models/exercise';
import { CertificatedUsersList } from '../models/admin/certificatedUsersList';
import { UserInfoForVerification } from '../models/admin/userInfoForVerification';
import { CertificateListVerification } from '../models/admin/certificateListVerification';
import { CertificateInfoForVeryfication } from '../models/admin/certificateInfoForVeryfication';
import { UserVerifyPatch } from '../models/admin/userVerifyPatch';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private http: HttpClient) { }

  getAllGymsAdmin(status: string):Observable<GymAdminInfo[]>{
    return this.http.get<GymAdminInfo[]>('https://localhost:7259/api/Admin/AllGyms/'+status);
  }

  deleteGym(gymId: number):Observable<any>{
    return this.http.delete<any>('https://localhost:7259/api/Admin/Gym/'+gymId);
  }

  getGymById(gymId: string):Observable<GymDetailsAdmin>{
    return this.http.get<GymDetailsAdmin>('https://localhost:7259/api/Admin/Gym/'+gymId);
  }

  updateGym(gymId: string, gym: GymUpdate):Observable<any>{
    return this.http.put<any>('https://localhost:7259/api/Admin/Gym/'+gymId, gym);
  }

  verifyGym(gymId: string, gym: GymUpdate):Observable<any>{
    return this.http.put<any>('https://localhost:7259/api/Admin/Gym/Verify/'+gymId, gym);
  }

  getAdminExercises():Observable<ExerciseShort[]>{
    return this.http.get<ExerciseShort[]>('https://localhost:7259/api/Admin/Exercises');
  }

  createExercise(exercise: Exercise):Observable<Exercise>{
    return this.http.post<Exercise>('https://localhost:7259/api/Admin/Exercises', exercise);
  }

  getAllUsersWithAcceptedCertificates():Observable<CertificatedUsersList[]>{
    return this.http.get<CertificatedUsersList[]>('https://localhost:7259/api/Admin/Users/AcceptedCertificates');
  }

  getAllUsersWithPendingCertificates():Observable<CertificatedUsersList[]>{
    return this.http.get<CertificatedUsersList[]>('https://localhost:7259/api/Admin/Users/PendingCertificates');
  }

  getUserInfoForVeryfication(userId: string):Observable<UserInfoForVerification>{
    return this.http.get<UserInfoForVerification>('https://localhost:7259/api/Admin/Users/'+userId);
  }

  getUserCertificates(userId: string):Observable<CertificateListVerification[]>{
    return this.http.get<CertificateListVerification[]>('https://localhost:7259/api/Admin/Users/Certificates/'+userId);
  }

  getCertificateInfoForVeryfication(certificateId: string):Observable<CertificateInfoForVeryfication>{
    return this.http.get<CertificateInfoForVeryfication>('https://localhost:7259/api/Admin/Certificates/'+certificateId);
  }

  acceptCertificate(certificateId: string):Observable<any>{
    return this.http.patch<any>('https://localhost:7259/api/Admin/Certificates/Verification/'+certificateId,null);
  }

  deleteCertificate(certificateId: string):Observable<any>{
    return this.http.delete<any>('https://localhost:7259/api/Admin/Certificates/'+certificateId);
  }

  verifyUser(userId: string, userVerifyPatch: UserVerifyPatch):Observable<any>{
    return this.http.patch<any>('https://localhost:7259/api/Admin/Users/Verification/'+userId,userVerifyPatch);
  }


}
