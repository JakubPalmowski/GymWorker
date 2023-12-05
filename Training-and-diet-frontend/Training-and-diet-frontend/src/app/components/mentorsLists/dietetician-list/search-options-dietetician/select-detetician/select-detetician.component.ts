import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-dropdown-select-dietetician',
  templateUrl: './select-detetician.component.html',
  styleUrls: ['./select-detetician.component.css']
})
export class SelectDeteticianComponent {
  @Input()
  inputLabel: string='Kategoria'

  @Input()
  options: string[] = ['Toyota', 'Honda', 'Ford', 'Chevrolet', 'BMW', 'Mercedes', 'Audi'];

}
