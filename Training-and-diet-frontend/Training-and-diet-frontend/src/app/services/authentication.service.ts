import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Login } from '../models/login';
import { Register } from '../models/register';
import { JwtAuth } from '../models/jwtAuth';
import { environment } from 'src/environments/environment.development';
import { jwtDecode } from "jwt-decode";
import { Router } from '@angular/router';


@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

    
  decodedToken: { [key: string]: string; } | undefined;
 

  constructor(private http: HttpClient, private router:Router) { }

  public register(register: Register): Observable<JwtAuth> {
    return this.http.post<JwtAuth>(environment.apiUrl + 'Auth/register', register);
  }

  public login(login: Login): Observable<JwtAuth> {
    return this.http.post<JwtAuth>(environment.apiUrl + 'Auth/login', login);
  }

  public refreshToken(): Observable<JwtAuth> {
    const jwtToken:JwtAuth={
      accessToken:localStorage.getItem('acessToken')||'',
      refreshToken:localStorage.getItem('refreshToken')||''
    }
    return this.http.post<JwtAuth>(environment.apiUrl + 'Auth/refresh', jwtToken);
  }
  

  public setSession(JwtAuth: JwtAuth) {
    localStorage.setItem('acessToken', JwtAuth.accessToken);
    localStorage.setItem('refreshToken', JwtAuth.refreshToken);
   // console.log("session acessT: "+JwtAuth.accessToken);
  //  console.log("session refT: "+JwtAuth.refreshToken);
    this.decodeToken();
    
    


  }

  decodeToken() {
    const token = localStorage.getItem('acessToken');
    if (token) {
      this.decodedToken = jwtDecode(token);
    }
  }




  isTokenExpired(): boolean {
    const expirationTime:number = parseInt(this.getExpiration() || '0');
    if (expirationTime) {
      return ((1000 * expirationTime) - (new Date()).getTime()) < 5000;
    } else {
      return false;
    }
  }



  public logout() {
    localStorage.removeItem('acessToken');
    localStorage.removeItem('refreshToken');
    this.router.navigateByUrl('/login');

    
  }

  getRole() {
    return this.decodedToken? this.decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] : undefined;
  }

  getUserId() { 
    return this.decodedToken? this.decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'] : undefined;
  }

  getExpiration() {
    return this.decodedToken? this.decodedToken['exp'] : undefined;
  }

}
