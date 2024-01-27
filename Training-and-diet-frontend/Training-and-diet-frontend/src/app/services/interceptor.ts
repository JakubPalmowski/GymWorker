import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Observable, catchError, from, switchMap, throwError } from 'rxjs';
import { AuthenticationService } from './authentication.service';
import { data, error } from 'jquery';
import { JwtAuth } from '../models/authentication/jwt-auth.model';

@Injectable()
export class AuthenticationInterceptor implements HttpInterceptor {

    constructor(private authenticationService:AuthenticationService) {}


    

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

       
        //console.log("check token before"+localStorage.getItem('acessToken'));
        
        if(localStorage.getItem('accessToken')){

            request=this.addTokenHeader(request);
        
        
        //console.log("interceptor");
        
        
        return next.handle(request).pipe(catchError(errorData=>{
            if(errorData.status==401 ){
                //console.log("401");
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
           // console.log("set serv 1");
            this.authenticationService.setSession(data);
           // console.log("set serv 2");
            return next.handle(this.addTokenHeader(request));
        }),
        catchError((errorData)=>{
          //  console.log("error inside refresh token");
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
