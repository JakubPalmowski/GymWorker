import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CreateOpinion } from '../models/Opinion/createOpinion';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OpinionService {

  constructor(private http: HttpClient) { }

  createOpinion(opinion: CreateOpinion):Observable<any>{
    return this.http.post<any>('https://localhost:7259/api/Opinion', opinion);
  }

  updateOpinion(opinion: CreateOpinion):Observable<any>{
    return this.http.put<any>('https://localhost:7259/api/Opinion', opinion);
  }

  getOpinion(id: number):Observable<CreateOpinion>{
    return this.http.get<CreateOpinion>('https://localhost:7259/api/Opinion/'+id);
  }
  deleteOpinion(id: number):Observable<any>{
    return this.http.delete<any>('https://localhost:7259/api/Opinion/Mentor/'+id);
  }
}
