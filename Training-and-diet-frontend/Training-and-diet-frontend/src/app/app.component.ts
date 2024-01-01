import { Component } from '@angular/core';
import { PreviousUrlService } from './services/previous-url.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Training-and-diet-frontend';
  constructor(previousUrl: PreviousUrlService){}
}
