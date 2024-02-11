import { Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { Login } from '../models/authentication/login.model';
import { Register } from '../models/authentication/register.model';
import { JwtAuth } from '../models/authentication/jwt-auth.model';
import { jwtDecode } from "jwt-decode";
import { Router } from '@angular/router';
import { get } from 'jquery';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

    
  decodedToken: { [key: string]: string; } | undefined;
  private loggedIn = new BehaviorSubject<boolean>(false);
 

  constructor(private http: HttpClient, private router: Router) {
    const token = localStorage.getItem('accessToken');
    const isExpired = this.isTokenExpired();
    this.loggedIn.next(!!token && !isExpired);
    if (token) {
      this.decodeToken();
    }
  }
  

  public register(register: Register): Observable<JwtAuth> {
    return this.http.post<JwtAuth>(environment.apiUrl + 'Auth/register', register);
  }

  public login(login: Login): Observable<JwtAuth> {
    return this.http.post<JwtAuth>(environment.apiUrl + 'Auth/login', login);
  }

  public refreshToken(): Observable<JwtAuth> {
    const jwtToken:JwtAuth={
      accessToken:localStorage.getItem('accessToken')||'',
      refreshToken:localStorage.getItem('refreshToken')||''
    }
    return this.http.post<JwtAuth>(environment.apiUrl + 'Auth/refresh', jwtToken);
  }
  

  public setSession(JwtAuth: JwtAuth) {
    localStorage.setItem('accessToken', JwtAuth.accessToken);
    localStorage.setItem('refreshToken', JwtAuth.refreshToken);
   // console.log("session acessT: "+JwtAuth.accessToken);
  //  console.log("session refT: "+JwtAuth.refreshToken);
    this.decodeToken();
    this.loggedIn.next(true);
    
    


  }

  decodeToken() {
    const token = localStorage.getItem('accessToken');
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
    localStorage.removeItem('accessToken');
    localStorage.removeItem('refreshToken');
    console.log("logout");
    console.log(this.getRole());
    this.decodedToken=undefined;
    console.log(this.getRole());
    this.loggedIn.next(false);
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

  get isLoggedIn() {
    return this.loggedIn.asObservable();
  }

 


}
