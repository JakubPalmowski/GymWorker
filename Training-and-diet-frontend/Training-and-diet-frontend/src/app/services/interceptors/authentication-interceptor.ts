import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Observable, catchError, from, switchMap, throwError } from 'rxjs';
import { AuthenticationService } from '../authentication.service';
import { data, error } from 'jquery';
import { JwtAuth } from '../../models/authentication/jwt-auth.model';

@Injectable()
export class AuthenticationInterceptor implements HttpInterceptor {

    constructor(private authenticationService:AuthenticationService) {}


    

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        
        if(localStorage.getItem('accessToken')){

            request=this.addTokenHeader(request);
        
        return next.handle(request).pipe(catchError(errorData=>{
            if(errorData.status==401 ){
                return this.handleRefreshToken(request,next);
            }

            return throwError(errorData);
        }));
        }
        else{
            return next.handle(request);
        }

    }

    handleRefreshToken(request: HttpRequest<any>, next: HttpHandler) {
    return from(this.authenticationService.refreshToken().pipe(
        switchMap((data:JwtAuth)=>{
            this.authenticationService.setSession(data);
            return next.handle(this.addTokenHeader(request));
        }),
        catchError((errorData)=>{
            return throwError(errorData);
        })));
    

    }

    addTokenHeader(request: HttpRequest<any>) {
        return request.clone({
            setHeaders: {
                Authorization: `Bearer ${localStorage.getItem('accessToken')}`
            }
        });
    }


}
