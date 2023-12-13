import { Component, OnInit} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TrainerProfile } from 'src/app/models/trainerProfile';
import { UserService } from 'src/app/services/user.service';


@Component({
  selector: 'app-trainer-profile',
  templateUrl: './trainer-profile.component.html',
  styleUrls: ['./trainer-profile.component.css'],

})
export class TrainerProfileComponent implements OnInit {
  constructor(private trainerService: UserService, private route:ActivatedRoute){

  }

  trainerId:string='';
  trainer:TrainerProfile | undefined;

  ngOnInit():void{
    this.trainerId = this.route.snapshot.params['id'];
    console.log(this.trainerId);
    
    this.trainerService.GetTrainerWithOpinionsById(this.trainerId).subscribe(
      {
        next:(trainerInfo)=>{
          this.trainer=trainerInfo;
        },
        error: (response)=>{
          console.log(response);
        }
      }
    )
    
  }
}