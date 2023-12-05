import { Component } from '@angular/core';
import { TrainerService } from 'src/app/services/trainer.service';

@Component({
  selector: 'app-trainer-list',
  templateUrl: './trainer-list.component.html',
  styleUrls: ['./trainer-list.component.css']
})
export class TrainerListComponent {

  constructor(private trainerService: TrainerService){
    
  }
  trainers = this.trainerService.GetAllTrainers();

}
