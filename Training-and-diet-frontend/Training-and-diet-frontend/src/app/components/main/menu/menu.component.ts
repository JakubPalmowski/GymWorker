import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd, UrlTree, UrlSegment } from '@angular/router';
import { error } from 'jquery';
import { Subscription } from 'rxjs';
import { filter } from 'rxjs/operators';
import { UserPhoto } from 'src/app/models/others/user-photo.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { FileService } from 'src/app/services/file.service';
import { PreviousUrlService } from 'src/app/services/previous-url.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit{


  isLoggedIn = false;
  userImage: string | undefined;
  role='';
  userImageResponse: UserPhoto | undefined;

 
  activeRoute: string = '';
  private firstSegmentSubscription: Subscription | undefined;
 

  constructor(private router: Router, private url: PreviousUrlService, private authService: AuthenticationService, private userService: UserService, private fileService: FileService) {

  }

  ngOnInit() {
    this.authService.isLoggedIn.subscribe(loggedIn => {
      this.isLoggedIn = loggedIn;
      if(loggedIn){
      const user = this.authService.getRole();
      switch(user){
        case '1':
          this.role='Admin';
          break;
        case '2':
          this.role='Pupil';
          break;
        case '3':
          this.role='Trainer';
          break;
        case '4':
          this.role='Dietician';
          break;
        case '5':
          this.role='Dietician-Trainer';
          break;
      }
      this.loadUserImage();
    }else{
      this.role='';
    }
    });

    this.userService.userImageChangedObservable.subscribe(
      (changed) => {
        if (changed) {
          this.loadUserImage();
        }
      }
    );

    this.firstSegmentSubscription = this.url.getFirstSegmentObservable().subscribe(
      (firstSegment) => {
        this.activeRoute=firstSegment;
      }
    );
  }

  loadUserImage() {
    this.userService.getUserImage().subscribe({
      next:(response)=>{ 
        this.userImageResponse = response
        if(this.userImageResponse?.imageUri!=null){
          this.fileService.getFile(response.imageUri).subscribe(
            (blob) => {
              this.userImage = URL.createObjectURL(blob);
            },
            (error) => {
              this.userImage = 'assets/images/user.png'
            }
          );
        }else{
          this.userImage = 'assets/images/user.png'
        }
      }
    })
      }
    
  



goToTrainersList(){
  if(!(this.activeRoute=='trainersList')){
    this.router.navigateByUrl('trainersList')
}
}

goToMentorPupilsList() {
  if(!(this.activeRoute=='myPupilsList')){
    this.router.navigateByUrl('myPupilsList')
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

    goToMyDiets() {
      if(!(this.activeRoute=='pupilDiets')){
        this.router.navigateByUrl('pupilDiets');
      }
    }
      

    goToDiets() {
      if(!(this.activeRoute=='diet')){
        this.router.navigateByUrl('diet');
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

    goToInvitationList() {
      if(!(this.activeRoute=='invitationList')){
        this.router.navigateByUrl('invitationList');
      }
      }

    
}