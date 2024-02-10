import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { PreviousUrlService } from 'src/app/services/previous-url.service';
import { TrainingPlanService } from 'src/app/services/training-plan.service';
import { UserService } from 'src/app/services/user.service';
import { Invitation } from 'src/app/models/mentor-pupil/invitation.model';
import { forkJoin, of, switchMap } from 'rxjs';
import { FileService } from 'src/app/services/file.service';
import { DietService } from 'src/app/services/diet.service';

@Component({
  selector: 'app-assign-diet',
  templateUrl: './assign-diet.component.html',
  styleUrls: ['./assign-diet.component.css']
})
export class AssignDietComponent implements OnInit{

  previousUrl:string='';

  pupils: Invitation[] | undefined;
  DialogFlag:boolean=false;
  sucessFlag:boolean=false;

  dietId:string='';

  constructor(private fileService: FileService, private route:ActivatedRoute, private userService:UserService,private previousUrlService: PreviousUrlService, private router:Router, private dietService:DietService) {}

  ngOnInit(): void {
    this.previousUrl=this.previousUrlService.getPreviousUrl();

    this.route.paramMap.subscribe({
      next:(params)=>{
        const id=params.get('id');
        if(id)
        this.dietId=id;

      
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


  assignDietToPupil(idPupil:number){
    this.dietService.assignDiet(this.dietId,idPupil.toString()).subscribe({
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
    this.router.navigateByUrl('/diet/edit/' + this.dietId);
  }


}
