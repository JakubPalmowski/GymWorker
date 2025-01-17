import { Directive, ElementRef, Input, OnInit, Output, EventEmitter } from '@angular/core';
import * as $ from 'jquery';
import 'jquery-ui/ui/widgets/autocomplete';
import { ActiveGym } from '../models/gym/active-gym.model';


type AutocompleteData = string[] | ActiveGym[];

@Directive({
  selector: '[appAutocomplete]'
})
export class AutocompleteDirective implements OnInit {
  @Input() appAutocomplete: AutocompleteData | undefined;
  @Output() selectedOption = new EventEmitter<string | ActiveGym>();
  @Input() removeDuplicates = false;

  constructor(private el: ElementRef) {}

  ngOnInit() {
    if (this.removeDuplicates && Array.isArray(this.appAutocomplete) && typeof this.appAutocomplete[0] === 'string') {
      this.appAutocomplete = Array.from(new Set(this.appAutocomplete as string[]));
    }
    (<any>$(this.el.nativeElement)).autocomplete({
      source: Array.isArray(this.appAutocomplete) && this.appAutocomplete.length > 0
        ? typeof this.appAutocomplete[0] === 'string'
          ? this.appAutocomplete
          : this.appAutocomplete.map((gym: ActiveGym | string) => ({
              label: typeof gym === 'string' ? gym : `${gym.cityName}, ${gym.name}`,
              value: gym
            }))
        : [],
        focus: (event: any, ui: { item: { label: string} }) => {
          this.el.nativeElement.value = ui.item.label;
          event.preventDefault();
        },
      select: (event: any, ui: { item: { label: string, value: ActiveGym | string } }) => {
        this.el.nativeElement.value = ui.item.label;
        this.selectedOption.emit(ui.item.value);
        event.preventDefault();
        
      }
    });
  }

}
