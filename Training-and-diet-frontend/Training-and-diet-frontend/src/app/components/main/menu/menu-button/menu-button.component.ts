import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-menu-button',
  templateUrl: './menu-button.component.html',
  styleUrls: ['./menu-button.component.css']
})
export class MenuButtonComponent {

  @Input()
  name: string='';

  @Input()
  imagePath: string='../../../assets/icons/record.png';

  @Input()
  routePath: string='/';
}
