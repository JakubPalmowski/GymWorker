import { Component, Input } from '@angular/core';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-mentor-window',
  templateUrl: './mentor-window.component.html',
  styleUrls: ['./mentor-window.component.css']
})
export class MentorWindowComponent {

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

@Input()
role:string|undefined='';


}

