import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CreateOpinion } from '../models/opinion/create-opinion.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OpinionService {

  constructor(private http: HttpClient) { }

  createOpinion(opinion: CreateOpinion):Observable<any>{
    return this.http.post<any>(environment.apiUrl+'Opinion', opinion);
  }

  updateOpinion(opinion: CreateOpinion):Observable<any>{
    return this.http.put<any>(environment.apiUrl+'Opinion', opinion);
  }

  getOpinion(id: number):Observable<CreateOpinion>{
    return this.http.get<CreateOpinion>(environment.apiUrl+'Opinion/'+id);
  }
  deleteOpinion(id: number):Observable<any>{
    return this.http.delete<any>(environment.apiUrl+'Opinion/Mentor/'+id);
  }
}
