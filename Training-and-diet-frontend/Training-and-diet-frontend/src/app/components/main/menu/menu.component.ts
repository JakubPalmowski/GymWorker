import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd, UrlTree, UrlSegment } from '@angular/router';
import { Subscription } from 'rxjs';
import { filter } from 'rxjs/operators';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { PreviousUrlService } from 'src/app/services/previous-url.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent{


  showSidebar = false;

  userId=this.authService.getUserId();
  userName?=this.authService.getUserId();//TO DO ZAMIANA NA NAME
  role='';
    toggleSidebar() {
        this.showSidebar = !this.showSidebar;
    }
 
  activeRoute: string = '';
  private firstSegmentSubscription: Subscription;
 

  constructor(private router: Router, private url: PreviousUrlService, private authService: AuthenticationService) {
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
      if(!(this.activeRoute=='meals')){
        this.router.navigateByUrl('meals');
      }
    }

    goToExercices() {
      if(!(this.activeRoute=='exercises')){
        this.router.navigateByUrl('exercises');
      }
    }


    goToTrainingPlans() {
      if(!(this.activeRoute=='training-plans')){
        this.router.navigateByUrl('training-plans');
      }
    }
    goPupilToTrainingPlans(){
      if(!(this.activeRoute=='pupilTrainingPlans')){
        this.router.navigateByUrl('pupilTrainingPlans');
      }
    }

    logout(){
        this.authService.logout();
        
    }

    
}