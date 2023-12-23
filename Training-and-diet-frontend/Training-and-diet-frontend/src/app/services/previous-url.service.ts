import { Injectable } from '@angular/core';
import { Router, NavigationEnd, UrlTree, UrlSegmentGroup, UrlSegment } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class PreviousUrlService {

  private previousUrl: string ='';
  private currentUrl: string ='';
  private pageNumber: string='';
  private searchPhrase: string='';

  constructor(private router : Router) {
    
  }

  public getPreviousUrlParamsMentorList(){
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.previousUrl = this.currentUrl;
        this.currentUrl = event.url;
        const previousUrlTree: UrlTree = this.router.parseUrl(this.previousUrl);
        const previousUrlSegmentGroup: UrlSegmentGroup = previousUrlTree.root;
        const previousUrlSegments: UrlSegment[] = previousUrlSegmentGroup.segments;

        this.pageNumber = previousUrlTree.queryParams['SearchPhrase'] || '';
        this.searchPhrase = previousUrlTree.queryParams['PageNumber'] || '';

      }
    });      
  }


}
