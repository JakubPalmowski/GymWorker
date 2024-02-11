import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GymAdminInfo } from '../models/admin/gym-admin-info.model';
import { GymDetailsAdmin } from '../models/admin/gym-details-admin.model';
import { GymUpdate } from '../models/admin/gym-update.model';
import { ExerciseShort } from '../models/exercise/exercise-short.model';
import { NewTrainingExercise } from '../models/training-plan/new-training-exercise.model';
import { Exercise } from '../models/exercise/exercise.model';
import { CertificatedUsersList } from '../models/admin/certificated-users-list.model';
import { UserInfoForVerification } from '../models/admin/user-info-for-verification.model';
import { CertificateListVerification } from '../models/admin/certificate-list-verification.model';
import { CertificateInfoForVeryfication } from '../models/admin/certificate-info-for-veryfication.model';
import { UserVerifyPatch } from '../models/admin/user-verify-patch.model';
import { ExerciseFull } from '../models/exercise/exercise-full.model';
import { UpdateExercise } from '../models/admin/exercise-update.model';
import { ExerciseCreateAdmin } from '../models/admin/exercise-create-admin';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private http: HttpClient) { }

  getAllGymsAdmin(status: string):Observable<GymAdminInfo[]>{
    return this.http.get<GymAdminInfo[]>(environment.apiUrl+'Admin/AllGyms/'+status);
  }

  deleteGym(gymId: number):Observable<any>{
    return this.http.delete<any>(environment.apiUrl+'Admin/Gym/'+gymId);
  }

  getGymById(gymId: string):Observable<GymDetailsAdmin>{
    return this.http.get<GymDetailsAdmin>(environment.apiUrl+'Admin/Gym/'+gymId);
  }

  updateGym(gymId: string, gym: GymUpdate):Observable<any>{
    return this.http.put<any>(environment.apiUrl+'Admin/Gym/'+gymId, gym);
  }

  verifyGym(gymId: string, gym: GymUpdate):Observable<any>{
    return this.http.put<any>(environment.apiUrl+'Admin/Gym/Verify/'+gymId, gym);
  }

  getAdminExercises():Observable<ExerciseShort[]>{
    return this.http.get<ExerciseShort[]>(environment.apiUrl+'Admin/Exercises');
  }

  createExercise(exercise: ExerciseCreateAdmin):Observable<ExerciseCreateAdmin>{
    return this.http.post<ExerciseCreateAdmin>(environment.apiUrl+'Admin/Exercises', exercise);
  }

  getAllUsersWithAcceptedCertificates():Observable<CertificatedUsersList[]>{
    return this.http.get<CertificatedUsersList[]>(environment.apiUrl+'Admin/Users/AcceptedCertificates');
  }

  getAllUsersWithPendingCertificates():Observable<CertificatedUsersList[]>{
    return this.http.get<CertificatedUsersList[]>(environment.apiUrl+'Admin/Users/PendingCertificates');
  }

  getUserInfoForVeryfication(userId: string):Observable<UserInfoForVerification>{
    return this.http.get<UserInfoForVerification>(environment.apiUrl+'Admin/Users/'+userId);
  }

  getUserCertificates(userId: string):Observable<CertificateListVerification[]>{
    return this.http.get<CertificateListVerification[]>(environment.apiUrl+'Admin/Users/Certificates/'+userId);
  }

  getCertificateInfoForVeryfication(certificateId: string):Observable<CertificateInfoForVeryfication>{
    return this.http.get<CertificateInfoForVeryfication>(environment.apiUrl+'Admin/Certificates/'+certificateId);
  }

  acceptCertificate(certificateId: string):Observable<any>{
    return this.http.patch<any>(environment.apiUrl+'Admin/Certificates/Verification/'+certificateId,null);
  }

  deleteCertificate(certificateId: string):Observable<any>{
    return this.http.delete<any>(environment.apiUrl+'Admin/Certificates/'+certificateId);
  }

  verifyUser(userId: string, userVerifyPatch: UserVerifyPatch):Observable<any>{
    return this.http.patch<any>(environment.apiUrl+'Admin/Users/Verification/'+userId,userVerifyPatch);
  }

  getAdminExerciseById(exerciseId: string):Observable<ExerciseFull>{
    return this.http.get<ExerciseFull>(environment.apiUrl+'Admin/Exercises/'+exerciseId);
  }

  updateExercise(exerciseId: string, exercise: UpdateExercise):Observable<any>{
    return this.http.put<any>(environment.apiUrl+'Admin/Exercises/'+exerciseId, exercise);
  }

  deleteAdminExercise(exerciseId: string):Observable<any>{
    return this.http.delete<any>(environment.apiUrl+'Admin/Exercises/'+exerciseId);
  }


}
