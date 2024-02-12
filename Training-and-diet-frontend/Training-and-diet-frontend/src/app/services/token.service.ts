import { Injectable } from '@angular/core';
import * as jwt from 'jwt-decode';


@Injectable({
  providedIn: 'root'
})
export class TokenService {

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  decodeToken(): any {
    const token = this.getToken();
    return token ? jwt.jwtDecode(token) : null;
  }
}