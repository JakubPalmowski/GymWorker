import { Directive, ElementRef, Input, OnInit, Output, EventEmitter } from '@angular/core';
import * as $ from 'jquery';
import 'jquery-ui/ui/widgets/autocomplete';

@Directive({
  selector: '[appAutocomplete]'
})
export class AutocompleteDirective implements OnInit {
  @Input() appAutocomplete: string[] | undefined; 
  @Output() selectedOption = new EventEmitter<string>(); 

  constructor(private el: ElementRef) {}

  ngOnInit() {
    (<any>$(this.el.nativeElement)).autocomplete({
      source: this.appAutocomplete || [],
      select: (event: any, ui: { item: { value: string | undefined; }; }) => {
        this.selectedOption.emit(ui.item.value);
      }
    });
  }
}
