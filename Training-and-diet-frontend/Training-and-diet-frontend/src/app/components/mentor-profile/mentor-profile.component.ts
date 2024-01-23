import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { catchError, forkJoin, of } from 'rxjs';
import { MentorProfile } from 'src/app/models/mentorProfile';
import { PupilProfile } from 'src/app/models/pupilProfile';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { FileService } from 'src/app/services/file.service';
import { PreviousUrlService } from 'src/app/services/previous-url.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-mentor-profile',
  templateUrl: './mentor-profile.component.html',
  styleUrls: ['./mentor-profile.component.css']
})
export class MentorProfileComponent implements OnInit {
  constructor(private userService: UserService, private route:ActivatedRoute, private previousUrlService: PreviousUrlService, private router: Router, private fileService: FileService, private authenticationService: AuthenticationService){

  }

 
  mentor:MentorProfile | undefined;
  role: string|undefined='';
  imageUrl: string = "";
  

  ngOnInit():void{
    const user = this.authenticationService.getUserId();
    console.log(user);
    const mentorId = this.route.snapshot.params['id'];
    this.route.url.subscribe(segments => {
      this.role = segments[0].path;})

    
    if(this.role=="trainerProfile"){
      this.userService.GetTrainerWithOpinionsById(mentorId).subscribe({
        next: (trainerInfo) => {
          if (!trainerInfo) {
            return;
          }
          this.mentor = trainerInfo;
          

          this.handleImage(this.mentor.imageUri ?? "");
    
          if (this.mentor.opinions && this.mentor.opinions.length > 0) {
            const imageRequests = this.mentor.opinions
              .filter(opinion => opinion.imageUri)
              .map(opinion => {
                return this.fileService.getFile(opinion.imageUri ?? "").pipe(
                  catchError(error => {
                    return of(null)
                  })
                );
              });
      
            forkJoin(imageRequests).subscribe(images => {
              images.forEach((blob, index) => {
                if (this.mentor && blob) {
                  const objectUrl = URL.createObjectURL(blob);
                  this.mentor.opinions.filter(opinion=>opinion.imageUri)[index].imageSrc = objectUrl;
                }
              });
            });
          }
        },
        error: (response) => {
          console.log('Wystąpił błąd podczas pobierania danych ucznia.', response);
        }
      });
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
              this.fileService.getFile(this.mentor.imageUri).subscribe(
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

  handleImage(imageUri: string) {
    if (imageUri) {
      this.fileService.getFile(imageUri).pipe(
        catchError(error => {
          this.imageUrl = "assets/images/user.png";
          return of(null);
        })
      ).subscribe(blob => {
        if (blob) {
          const objectUrl = URL.createObjectURL(blob);
          this.imageUrl = objectUrl;
        }
      });
    } else {
      this.imageUrl = "assets/images/user.png";
    }
  }
}
