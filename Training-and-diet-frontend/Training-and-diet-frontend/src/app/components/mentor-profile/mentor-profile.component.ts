import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MentorProfile } from 'src/app/models/mentorProfile';
import { PupilProfile } from 'src/app/models/pupilProfile';
import { PreviousUrlService } from 'src/app/services/previous-url.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-mentor-profile',
  templateUrl: './mentor-profile.component.html',
  styleUrls: ['./mentor-profile.component.css']
})
export class MentorProfileComponent implements OnInit {
  constructor(private userService: UserService, private route:ActivatedRoute, private previousUrlService: PreviousUrlService, private router: Router){

  }

 
  mentor:MentorProfile | undefined;
  role: string|undefined='';
  

  ngOnInit():void{

    const mentorId = this.route.snapshot.params['id'];
    this.route.url.subscribe(segments => {
      this.role = segments[0].path;})

    
    if(this.role=="trainerProfile"){
    this.userService.GetTrainerWithOpinionsById(mentorId).subscribe(
      {
        next:(trainerInfo)=>{
          this.mentor=trainerInfo;
        },
        error: (response)=>{
          console.log(response);
        }
      }
    )
    }
    if(this.role=="dieticianProfile"){
      this.userService.GetDieticianWithOpinionsById(mentorId).subscribe(
        {
          next:(dieticianInfo)=>{
            this.mentor=dieticianInfo;
          },
          error: (response)=>{
            console.log(response);
          }
        }
      )
      }
      

    
  }

  goToTrainersList(){
    const params = this.previousUrlService.getPreviousUrlParamsMentorList();
    if(params!=null){
      const queryParams: any = { PageNumber: params.pageNumber };
      if(params.searchPhrase){
        queryParams.SearchPhrase = params.searchPhrase;
      }
      if(params.sortBy){
        queryParams.SortBy = params.sortBy;
      }
      if(params.gymCityPhrase){
        queryParams.GymCityPhrase = params.gymCityPhrase;
      }
      if(params.gymNamePhrase){
        queryParams.GymNamePhrase = params.gymNamePhrase;
      }
      if(params.sortDirection){
        queryParams.SortDirection = params.sortDirection;
      }
      this.router.navigate(['/trainersList'], { queryParams: queryParams});
    }else{
      this.router.navigate(['/trainersList']);
    }
    }
  
  
  

  goToDieticiansList(){
    const params = this.previousUrlService.getPreviousUrlParamsMentorList();
    if(params!=null){
      const queryParams: any = { PageNumber: params.pageNumber };
      if(params.searchPhrase){
        queryParams.SearchPhrase = params.searchPhrase;
      }
      if(params.sortBy){
        queryParams.SortBy = params.sortBy;
      }
      if(params.sortDirection){
        queryParams.SortDirection = params.sortDirection;
      }
      this.router.navigate(['/dieticiansList'], { queryParams: queryParams});
    }else{
      this.router.navigate(['/dieticiansList']);
    }
  }
}
