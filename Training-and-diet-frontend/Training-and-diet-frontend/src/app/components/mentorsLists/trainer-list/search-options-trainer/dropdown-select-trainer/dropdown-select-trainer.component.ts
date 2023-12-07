import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-dropdown-select-trainer',
  templateUrl: './dropdown-select-trainer.component.html',
  styleUrls: ['./dropdown-select-trainer.component.css']
})
export class DropdownSelectTrainerComponent {
  @Input()
  inputLabel: string='Kategoria'

  @Input()
  options: string[] = ['Toyota', 'Honda', 'Ford', 'Chevrolet', 'BMW', 'Mercedes', 'Audi'];
}
