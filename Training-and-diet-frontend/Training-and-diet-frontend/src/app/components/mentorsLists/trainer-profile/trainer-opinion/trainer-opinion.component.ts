import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-trainer-opinion',
  templateUrl: './trainer-opinion.component.html',
  styleUrls: ['./trainer-opinion.component.css']
})
export class TrainerOpinionComponent {
  @Input()
  rate:number=0;

  @Input()
  pupilName:string='';

  @Input()
  content:string='';

  @Input()
  date:string="";


}
