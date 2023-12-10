import { Component, Input } from '@angular/core';
import { Trainer } from 'src/app/models/trainer';
import { TrainerService } from 'src/app/services/trainer.service';

@Component({
  selector: 'app-trainer-window',
  templateUrl: './trainer-window.component.html',
  styleUrls: ['./trainer-window.component.css']
})
export class TrainerWindowComponent {
  constructor(private trainerService: TrainerService){

  }

  @Input()
  id: number=0;

  @Input()
name: string = '';

@Input()
lastName: string = '';

@Input()
biography: string = '';

@Input()
phoneNumber: string = '';

@Input()
city: string = '';

@Input()
opinionNumber: number = 0;

@Input()
rate: number = 0;


}
