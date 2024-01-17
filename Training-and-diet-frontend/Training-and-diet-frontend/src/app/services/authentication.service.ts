import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Login } from '../models/login';
import { Register } from '../models/register';
import { JwtAuth } from '../models/jwtAuth';
import { Environment } from '@angular/compiler-cli/src/ngtsc/typecheck/src/environment';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient) { }

  public register(register: Register): Observable<JwtAuth> {
    return this.http.post<JwtAuth>(environment.apiUrl + 'Auth/register', register);
  }

  public login(login: Login): Observable<JwtAuth> {
    return this.http.post<JwtAuth>(environment.apiUrl + 'Auth/login', login);
  }


}
