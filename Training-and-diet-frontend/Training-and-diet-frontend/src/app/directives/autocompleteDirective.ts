import { Directive, ElementRef, Input, OnInit } from '@angular/core';
import * as $ from 'jquery';
import 'jquery-ui/ui/widgets/autocomplete';

@Directive({
  selector: '[appAutocomplete]'
})
export class AutocompleteDirective implements OnInit {
  @Input() appAutocomplete: string[] | undefined; // dane wejściowe

  constructor(private el: ElementRef) {}

  ngOnInit() {
    (<any>$(this.el.nativeElement)).autocomplete({
      source: this.appAutocomplete || []
    });
}
}
