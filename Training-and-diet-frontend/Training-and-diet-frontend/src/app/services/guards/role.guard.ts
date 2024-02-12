import { inject } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthenticationService } from '../authentication.service';

export function RoleGuard(...roles: string[]): CanActivateFn {
  return (ars: ActivatedRouteSnapshot, rss: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> => {
    

    
    const router = inject(Router);
    const role = inject(AuthenticationService).getRole();

    

    if(role!=undefined){
    if(roles.includes(role)){
    return true;
    }
  }
    router.navigate(['']);
    return false;


  }
}