import { Component, Input } from '@angular/core';
import { Mentor } from 'src/app/models/mentor';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-trainer-window',
  templateUrl: './trainer-window.component.html',
  styleUrls: ['./trainer-window.component.css']
})
export class TrainerWindowComponent {
  constructor(private trainerService: UserService){

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
