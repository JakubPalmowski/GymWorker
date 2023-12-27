import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MentorProfile } from 'src/app/models/mentorProfile';
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

  mentorId:string='';
  mentor:MentorProfile | undefined;
  role: string|undefined='';
  previousUrl: string='';

  ngOnInit():void{

    this.mentorId = this.route.snapshot.params['id'];
    this.route.url.subscribe(segments => {
      const roleSegment = segments[segments.length - 2];
      this.role = roleSegment.path;})

    
    if(this.role=="trainerProfile"){
    this.userService.GetTrainerWithOpinionsById(this.mentorId).subscribe(
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
      this.userService.GetDieticianWithOpinionsById(this.mentorId).subscribe(
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
      this.router.navigate(['/dieticiansList'], { queryParams: queryParams});
    }else{
      this.router.navigate(['/dieticiansList']);
    }
  }
}
