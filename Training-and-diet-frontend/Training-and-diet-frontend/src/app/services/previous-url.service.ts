import { Injectable } from '@angular/core';
import { Router, NavigationEnd, UrlTree, UrlSegmentGroup, UrlSegment } from '@angular/router';
import { ListQueryParams } from '../models/listQueryParams';

@Injectable({
  providedIn: 'root'
})
export class PreviousUrlService {

  private previousUrl:string='';
  private currentUrl:string='';

  constructor(private router : Router) {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.previousUrl = this.currentUrl;
        this.currentUrl = event.url;
      }
    });
  }

  public getPreviousUrlParamsMentorList(){
    if (this.previousUrl) {
      const previousUrlTree: UrlTree = this.router.parseUrl(this.previousUrl);
      const params: ListQueryParams = {
        pageNumber: +previousUrlTree.queryParams['PageNumber'] || 1,
        searchPhrase: previousUrlTree.queryParams['SearchPhrase'] || '',
        sortBy: previousUrlTree.queryParams['SortBy'] || '',
        gymCityPhrase: previousUrlTree.queryParams['GymCityPhrase'] || '',
        gymNamePhrase: previousUrlTree.queryParams['GymNamePhrase'] || ''
      };
  
      return params;
    }

    return null;
  }


}
