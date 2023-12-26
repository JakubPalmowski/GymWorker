import { Component, EventEmitter, Input, Output } from '@angular/core';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent {


  @Input()
  placeholderText: string='Wyszukaj trenera';
  
  @Input()
  searchInput: string='';
  
  @Output()
  searchMentor: EventEmitter<string> = new EventEmitter<string>()

  onSearchMentor(){
    this.searchMentor.emit(this.searchInput);
  }
}
