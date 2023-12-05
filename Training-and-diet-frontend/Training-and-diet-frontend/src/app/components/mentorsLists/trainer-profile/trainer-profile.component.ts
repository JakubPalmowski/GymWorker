import { Component, OnInit} from '@angular/core';
import { Trainer } from 'src/app/models/trainer';
import { TrainerService } from 'src/app/services/trainer.service';


@Component({
  selector: 'app-trainer-profile',
  templateUrl: './trainer-profile.component.html',
  styleUrls: ['./trainer-profile.component.css'],

})
export class TrainerProfileComponent implements OnInit {
  constructor(private trainerService: TrainerService){

  }
  selectedTrainer: Trainer | undefined;

  ngOnInit(){
    this.selectedTrainer=this.trainerService.getTrainer();
  }
}