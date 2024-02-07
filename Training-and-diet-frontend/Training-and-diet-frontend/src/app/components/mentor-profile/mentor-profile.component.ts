import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { catchError, forkJoin, of } from 'rxjs';
import { CreateOpinion } from 'src/app/models/opinion/create-opinion.model';
import { MentorProfile } from 'src/app/models/mentor-pupil/mentor-profile.model';
import { PupilProfile } from 'src/app/models/mentor-pupil/pupil-profile.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { FileService } from 'src/app/services/file.service';
import { OpinionService } from 'src/app/services/opinion.service';
import { PreviousUrlService } from 'src/app/services/previous-url.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-mentor-profile',
  templateUrl: './mentor-profile.component.html',
  styleUrls: ['./mentor-profile.component.css']
})
export class MentorProfileComponent implements OnInit {



  constructor(private opinionService: OpinionService,private userService: UserService, private route:ActivatedRoute, private previousUrlService: PreviousUrlService, private router: Router, private fileService: FileService, private authenticationService: AuthenticationService){

  }

  mentorId: string|undefined;
  mentor:MentorProfile | undefined;
  role: string|undefined='';
  imageUrl: string = "";
  idUser: string|undefined;
  roleUser: string|undefined;
  fromList: boolean = true;

  newOpinion: CreateOpinion = {
    idMentor: 0,
    rate: 5,
    content: ""
  };

  editOpinion: CreateOpinion | undefined;

  @ViewChild('profileForm') profileForm: NgForm | undefined;
  @ViewChild('editForm') editForm: NgForm | undefined;
  fieldErrors: { [key: string]: string[] } = {};
  submitted: boolean = false;
  errorFlag: string = "";
  @ViewChild('createOpinionModal') createOpinionModalRef: ElementRef | undefined;
  @ViewChild('updateOpinionModal') updateOpinionModalRef: ElementRef | undefined;

  ngOnInit():void{
    const role = this.authenticationService.getRole();
    switch (role) {
      case '2':
        this.roleUser = 'Pupil';
        break;
    }

    const previousUrl = this.previousUrlService.getPreviousUrl();
    if(previousUrl.includes('/pupilDiets')||previousUrl.includes('/pupilTrainingPlans'))
    {
      this.fromList = false;
    }
    
    const mentorId = this.route.snapshot.params['id'];
    this.newOpinion = {
      idMentor: mentorId,
      rate: 5,
      content: ""
    };
    this.submitted = false;
    this.mentorId = mentorId;

    this.route.url.subscribe(segments => {
      this.role = segments[0].path;})

    
    if(this.role=="trainerProfile"){
      this.userService.GetTrainerWithOpinionsById(mentorId).subscribe({
        next: (trainerInfo) => {
          if (!trainerInfo) {
            return;
          }
          this.mentor = trainerInfo;
          if(this.mentor?.isOpinionExists){
            this.loadOpinion();
          }

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
            if(this.mentor?.isOpinionExists){
              this.loadOpinion();
            }
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

  onCreateSubmit() {
    this.submitted = true;
    if (this.profileForm?.valid) {
      this.opinionService.createOpinion(this.newOpinion).subscribe({
        next: (response) => {
          if (this.createOpinionModalRef && this.createOpinionModalRef.nativeElement) {
            (<any>$(this.createOpinionModalRef.nativeElement)).modal('hide');
          }
          this.ngOnInit();
          this.errorFlag = "successCreate";
          this.showErrorPopup(this.errorFlag);
        },
        error: (error) => {
    
          if (error.status === 400) {
           const { errors } = error.error;
  
           this.fieldErrors = {}; 
        
           for (const key in errors) {
               if (errors.hasOwnProperty(key)) {
                   this.fieldErrors[key] = errors[key]; 
               }
           }
          }else{
            this.errorFlag = "error";
            this.showErrorPopup(this.errorFlag);
          }
            
          
        }
      });
    }
    }

    onEditSubmit() {
      this.submitted = true;
    if (this.editForm?.valid && this.editOpinion) {
      this.opinionService.updateOpinion(this.editOpinion).subscribe({
        next: (response) => {
          if (this.updateOpinionModalRef && this.updateOpinionModalRef.nativeElement) {
            (<any>$(this.updateOpinionModalRef.nativeElement)).modal('hide');
          }
          this.ngOnInit();
          this.errorFlag = "successUpdate";
          this.showErrorPopup(this.errorFlag);
        },
        error: (error) => {
    
          if (error.status === 400) {
           const { errors } = error.error;
  
           this.fieldErrors = {}; 
        
           for (const key in errors) {
               if (errors.hasOwnProperty(key)) {
                   this.fieldErrors[key] = errors[key]; 
               }
           }
          }else{
            this.errorFlag = "error";
            this.showErrorPopup(this.errorFlag);
          }
            
          
        }
      });
    }
      }

      loadOpinion() {
        this.opinionService.getOpinion(this.newOpinion.idMentor).subscribe({
          next: (opinion) => {
            if (!opinion) {
              return;
            }
            this.editOpinion = opinion;
            this.editOpinion.idMentor = this.newOpinion.idMentor;
          },
          error: (response) => {
            console.log('Wystąpił błąd podczas pobierania danych ucznia.', response);
          }
        });
        }

        deleteOpinion() {
          if(this.editOpinion){
            this.opinionService.deleteOpinion(this.editOpinion.idMentor).subscribe({
              next: (response) => {
                if (this.updateOpinionModalRef && this.updateOpinionModalRef.nativeElement) {
                  (<any>$(this.updateOpinionModalRef.nativeElement)).modal('hide');
                }
                this.ngOnInit();
                this.errorFlag = "successDelete";
                this.showErrorPopup(this.errorFlag);
              },
              error: (error) => {
          
                if (error.status === 400) {
                 const { errors } = error.error;
        
                 this.fieldErrors = {}; 
              
                 for (const key in errors) {
                     if (errors.hasOwnProperty(key)) {
                         this.fieldErrors[key] = errors[key]; 
                     }
                 }
                }else{
                  this.errorFlag = "error";
                  this.showErrorPopup(this.errorFlag);
                }
                  
                
              }
            });
          }
          }



          sendInvitation() {
            if(this.mentorId)
            {
            this.userService.sendInvitation(this.mentorId).subscribe({
              next: (response) => {
                if(this.mentor){
                this.mentor.cooperation=false;
                }
              },
              error: (error) => {
                  this.errorFlag = "error";
                  this.showErrorPopup(this.errorFlag);
              }
            });
            }
          }

          cancelInvitation() {
            if(this.mentorId)
            {
            this.userService.deleteInvitation(this.mentorId).subscribe({
              next: (response) => {
                if(this.mentor){
                this.mentor.cooperation=undefined;
                }
              },
              error: (error) => {
                  this.errorFlag = "error";
                  this.showErrorPopup(this.errorFlag);
              }
            });
            }
          }

    showErrorPopup(status: string) {
      if(status == "error"){
        setTimeout(() => this.errorFlag="", 3000); 
      }
      if(status == "successDelete" || status == "successCreate" || status == "successUpdate"){
        setTimeout(() => this.errorFlag="", 3000); 
      }
    
    }
    back() {
      this.router.navigateByUrl(this.previousUrlService.getPreviousUrl())
      }

  
}
