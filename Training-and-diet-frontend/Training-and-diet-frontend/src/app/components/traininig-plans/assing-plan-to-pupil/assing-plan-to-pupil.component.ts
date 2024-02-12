import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { TrainingPlanPupilList } from 'src/app/models/training-plan/training-plan-pupil-list.model';
import { PupilShort } from 'src/app/models/mentor-pupil/pupil-short.model';
import { PreviousUrlService } from 'src/app/services/previous-url.service';
import { TrainingPlanService } from 'src/app/services/training-plan.service';
import { UserService } from 'src/app/services/user.service';
import { Invitation } from 'src/app/models/mentor-pupil/invitation.model';
import { forkJoin, of, switchMap } from 'rxjs';
import { FileService } from 'src/app/services/file.service';

@Component({
  selector: 'app-assing-plan-to-pupil',
  templateUrl: './assing-plan-to-pupil.component.html',
  styleUrls: ['./assing-plan-to-pupil.component.css']
})
export class AssingPlanToPupilComponent implements OnInit{

  previousUrl:string='';

  pupils: Invitation[] | undefined;
  DialogFlag:boolean=false;
  sucessFlag:boolean=false;

  planId:string='';

  constructor(private fileService: FileService, private route:ActivatedRoute, private userService:UserService,private previousUrlService: PreviousUrlService, private router:Router, private trainingPlanService:TrainingPlanService) {}

  ngOnInit(): void {
    this.previousUrl=this.previousUrlService.getPreviousUrl();

    this.route.paramMap.subscribe({
      next:(params)=>{
        const id=params.get('id');
        if(id)
        this.planId=id;

      
          this.userService.getMentorPupils().pipe(
            switchMap((pupils) => {
              this.pupils = pupils;
        
              if (pupils.length === 0) {
                return of([]);
              }
        
              const imageRequests = pupils.map(pupil => {
                if (pupil.imageUri) {
        
                  return this.fileService.getFile(pupil.imageUri).pipe(
                    switchMap((imageSrc) => {
         
                      pupil.imageSrc = URL.createObjectURL(imageSrc); 
                      return of(pupil); 
                    })
                  );
                } else {
           
                  pupil.imageSrc = 'assets/images/user.png';
                  return of(pupil); 
                }
              });
              return forkJoin(imageRequests);
            })
          ).subscribe(
            () => {
      
            },
            (error) => {
      
            }
          );

      }});




  }


  assignPlanToPupil(idPupil:number){
    this.trainingPlanService.assignPlanToPupil(this.planId,idPupil.toString()).subscribe({
    next:(response)=>{
      this.DialogFlag=true;
      this.sucessFlag=true;
      
    },
    error:(response)=>{
      this.DialogFlag=true;
      this.sucessFlag=false;
    }
  });
  }

  errorShown(){
    this.DialogFlag=false;
  }


  back(): void{
    this.router.navigateByUrl('/training-plans/edit/' + this.planId);
  }


}
