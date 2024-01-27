import { Injectable } from '@angular/core';
import { Router, NavigationEnd, UrlTree, UrlSegmentGroup, UrlSegment, ActivatedRoute } from '@angular/router';
import { ListQueryParams } from '../models/others/list-query-params.model';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PreviousUrlService {

  private previousUrl: string = '';
  private currentUrl: string = '';
  private firstSegment: string = '';
  private adminUsersBackUrl: string = '/admin/certificatedUsers/list/Accepted';
  private firstSegmentSubject = new BehaviorSubject<string>(this.firstSegment);

  constructor(private router: Router) {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this.previousUrl = this.currentUrl;
        this.currentUrl = event.url;
        this.updateFirstSegment();
        if (this.previousUrl=="/admin/certificatedUsers/list/Accepted") {
          this.adminUsersBackUrl = this.previousUrl;
        }else if(this.previousUrl=="/admin/certificatedUsers/list/Pending"){
          this.adminUsersBackUrl = this.previousUrl;
      }
    }
    });
  }

  private updateFirstSegment(): void {
    if (this.currentUrl) {
        const urlTree: UrlTree = this.router.parseUrl(this.currentUrl);
        const segments = urlTree.root.children['primary'] ? urlTree.root.children['primary'].segments : [];
        const newFirstSegment = segments.length > 0 ? segments[0].toString() : '';
        if (newFirstSegment !== this.firstSegment) {
            this.firstSegment = newFirstSegment;
            this.firstSegmentSubject.next(this.firstSegment);
        }
       
    }
}


  public getFirstSegmentObservable() {
    return this.firstSegmentSubject.asObservable();
  }

 
  public getPreviousUrlParamsMentorList(){
    if (this.previousUrl) {
      const previousUrlTree: UrlTree = this.router.parseUrl(this.previousUrl);
      const params: ListQueryParams = {
        pageNumber: +previousUrlTree.queryParams['PageNumber'] || 1,
        searchPhrase: previousUrlTree.queryParams['SearchPhrase'] || '',
        sortBy: previousUrlTree.queryParams['SortBy'] || '',
        gymCityPhrase: previousUrlTree.queryParams['GymCityPhrase'] || '',
        gymNamePhrase: previousUrlTree.queryParams['GymNamePhrase'] || '',
        sortDirection: previousUrlTree.queryParams['SortDirection'] || ''
      };
  
      return params;
    }

    return null;
  }

  public getPreviousUrl() {
    return this.previousUrl;
  } 

  public adminPanelUsersBack(){
    return this.adminUsersBackUrl;
  }
 

  


}
