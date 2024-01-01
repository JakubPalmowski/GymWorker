import { Component, Input } from '@angular/core';
import { Mentor } from 'src/app/models/mentor';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-mentor-window',
  templateUrl: './mentor-window.component.html',
  styleUrls: ['./mentor-window.component.css']
})
export class MentorWindowComponent {

 @Input()
 mentor:Mentor|undefined;
 
 @Input()
 role:string|undefined='';


}

