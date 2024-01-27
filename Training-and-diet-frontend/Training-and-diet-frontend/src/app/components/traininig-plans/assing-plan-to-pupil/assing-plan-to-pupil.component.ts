import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { TrainingPlanPupilList } from 'src/app/models/training-plan/training-plan-pupil-list.model';
import { PupilShort } from 'src/app/models/mentor-pupil/pupil-short.model';
import { PreviousUrlService } from 'src/app/services/previous-url.service';
import { TrainingPlanService } from 'src/app/services/training-plan.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-assing-plan-to-pupil',
  templateUrl: './assing-plan-to-pupil.component.html',
  styleUrls: ['./assing-plan-to-pupil.component.css']
})
export class AssingPlanToPupilComponent implements OnInit{

  previousUrl:string='';

  pupils:PupilShort[]=[];
  filteredPupils:PupilShort[]=[];
  DialogFlag:boolean=false;
  sucessFlag:boolean=false;

  planId:string='';

  constructor( private route:ActivatedRoute, private userService:UserService,private previousUrlService: PreviousUrlService, private router:Router, private trainingPlanService:TrainingPlanService) {}

  ngOnInit(): void {
    this.previousUrl=this.previousUrlService.getPreviousUrl();

    this.route.paramMap.subscribe({
      next:(params)=>{
        const id=params.get('id');
        if(id)
        this.planId=id;

        this.userService.GetMentorPupils().subscribe({
          next:(pupils)=>{
            this.pupils=pupils;
            this.filteredPupils=this.pupils;
          },
          error: (response)=>{
            console.log(response);
          }
        });

        console.log(id);
      }});




  }


  assignPlanToPupil(idPupil:number){
    console.log(idPupil);
    this.trainingPlanService.assignPlanToPupil(this.planId,idPupil.toString()).subscribe({
    next:(response)=>{
      console.log(response);
      this.DialogFlag=true;
      this.sucessFlag=true;
      
    },
    error:(response)=>{
      console.log(response);
      this.DialogFlag=true;
      this.sucessFlag=false;
    }
  });
  }

  errorShown(){
    this.DialogFlag=false;
  }


  back(): void{
    this.router.navigateByUrl(this.previousUrl);
  }


}
