import { Component, OnInit} from '@angular/core';
import { TrainerProfile } from 'src/app/models/trainerProfile';
import { TrainerService } from 'src/app/services/trainer.service';


@Component({
  selector: 'app-trainer-profile',
  templateUrl: './trainer-profile.component.html',
  styleUrls: ['./trainer-profile.component.css'],

})
export class TrainerProfileComponent implements OnInit {
  constructor(private trainerService: TrainerService){

  }

  trainerId:number=0;
  trainer:TrainerProfile | undefined;

  ngOnInit():void{
    this.trainerId=this.trainerService.getTrainerId();
    this.trainerService.GetTrainerWithOpinionsById(this.trainerId.toString()).subscribe(
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