import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-mentor-opinion',
  templateUrl: './mentor-opinion.component.html',
  styleUrls: ['./mentor-opinion.component.css']
})
export class MentorOpinionComponent {
  
  @Input()
  rate:number=0;

  @Input()
  pupilName:string='';

  @Input()
  content:string='';

  @Input()
  date:string="";
}
