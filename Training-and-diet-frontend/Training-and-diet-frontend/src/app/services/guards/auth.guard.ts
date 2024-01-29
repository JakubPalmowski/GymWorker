import { inject } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable, map } from 'rxjs';
import { AuthenticationService } from '../authentication.service';

export const AuthGuard = () => {
 const authenticationService = inject(AuthenticationService);
 const router = inject(Router);

 return authenticationService.isLoggedIn.pipe(
  map((isLoggedIn: any) => {

    
   if (!isLoggedIn) {
    console.log("auth guard");
    router.navigate(['/login']);
    return false;
   }
   return true;
  })
 );

 
 



}

