import { Component } from '@angular/core';
import { Router, NavigationEnd, UrlTree, UrlSegment } from '@angular/router';
import { Subscription } from 'rxjs';
import { filter } from 'rxjs/operators';
import { PreviousUrlService } from 'src/app/services/previous-url.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent {


  showSidebar = false;

    toggleSidebar() {
        this.showSidebar = !this.showSidebar;
    }
 
  activeRoute: string = '';
  private firstSegmentSubscription: Subscription;
 

  constructor(private router: Router, private url: PreviousUrlService) {
    this.firstSegmentSubscription = this.url.getFirstSegmentObservable().subscribe(
      (firstSegment) => {
        this.activeRoute=firstSegment;
      }
    );
  }


goToTrainersList(){
  if(!(this.activeRoute=='trainersList')){
    this.router.navigateByUrl('trainersList')
}
}

goToMainPage() {
  if(!(this.activeRoute=='')){
    this.router.navigateByUrl('');
  }
  }

  goToDieticiansList() {
    if(!(this.activeRoute=='dieticiansList')){
      this.router.navigateByUrl('dieticiansList');
    }
    }

    goToMeals() {
      if(!(this.activeRoute=='meals-list')){
        this.router.navigateByUrl('meals-list');
      }
    }

    goToExercices() {
      if(!(this.activeRoute=='exercises-list')){
        this.router.navigateByUrl('exercises-list');
      }
    }


    goToTrainingPlans() {
      if(!(this.activeRoute=='training-plans')){
        this.router.navigateByUrl('training-plans');
      }
    }
}