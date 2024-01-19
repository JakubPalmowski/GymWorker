import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MentorProfile } from 'src/app/models/mentorProfile';
import { PupilProfile } from 'src/app/models/pupilProfile';
import { FileService } from 'src/app/services/file.service';
import { PreviousUrlService } from 'src/app/services/previous-url.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-mentor-profile',
  templateUrl: './mentor-profile.component.html',
  styleUrls: ['./mentor-profile.component.css']
})
export class MentorProfileComponent implements OnInit {
  constructor(private userService: UserService, private route:ActivatedRoute, private previousUrlService: PreviousUrlService, private router: Router, private fileService: FileService){

  }

 
  mentor:MentorProfile | undefined;
  role: string|undefined='';
  imageUrl: string = "";
  

  ngOnInit():void{

    const mentorId = this.route.snapshot.params['id'];
    this.route.url.subscribe(segments => {
      this.role = segments[0].path;})

    
    if(this.role=="trainerProfile"){
      this.userService.GetTrainerWithOpinionsById(mentorId).subscribe(
        {
          next: (trainerInfo) => {
            if (!trainerInfo) {
              return;
            }
            this.mentor = trainerInfo;
            if (this.mentor.imageUri) {
              this.fileService.getImage(this.mentor.imageUri).subscribe(
                blob => {
                  if (blob) {
                    const objectUrl = URL.createObjectURL(blob);
                    this.imageUrl = objectUrl;
                  }
                },
                error => {
                  this.imageUrl = "assets/images/user.png";
                }
              );
            } else {
              this.imageUrl = "assets/images/user.png";
            }
          },
          error: (response) => {
            console.log('Wystąpił błąd podczas pobierania danych ucznia.', response);
          }
        }
      );
    }
    if(this.role=="dieticianProfile"){
      this.userService.GetDieticianWithOpinionsById(mentorId).subscribe(
        {
          next: (dieticianInfo) => {
            if (!dieticianInfo) {
              return;
            }
            this.mentor = dieticianInfo;
            if (this.mentor.imageUri) {
              this.fileService.getImage(this.mentor.imageUri).subscribe(
                blob => {
                  if (blob) {
                    const objectUrl = URL.createObjectURL(blob);
                    this.imageUrl = objectUrl;
                  }
                },
                error => {
                  this.imageUrl = "assets/images/user.png";
                }
              );
            } else {
              this.imageUrl = "assets/images/user.png";
            }
          },
          error: (response) => {
            console.log('Wystąpił błąd podczas pobierania danych ucznia.', response);
          }
        }
      );
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
