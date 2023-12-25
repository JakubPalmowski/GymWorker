import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Sort } from 'src/app/models/sort';

@Component({
  selector: 'app-search-options',
  templateUrl: './search-options.component.html',
  styleUrls: ['./search-options.component.css']
})
export class SearchOptionsComponent {
  @Input()
  role:string|undefined='';

  @Input()
  searchPhrase:string='';

  @Output()
  deletePhrase: EventEmitter<void> = new EventEmitter<void>()


  sortOptionsView: Sort={
    sort:''
  }

  sortOptions: Sort={
    sort: ''
  }

  @Output()
  filterData: EventEmitter<Sort> = new EventEmitter<Sort>()


  onFilterData(action: string){
    if(action=="filter"){
        if(this.sortOptions.sort=="Mentor_Opinions"){
      this.sortOptionsView.sort = "Ocena";
        }
      this.filterData.emit(this.sortOptions)
       
        }
    if(action=="deleteSort"){
      this.sortOptions.sort='';
      this.sortOptionsView.sort = '';
      this.filterData.emit(this.sortOptions)
    }
    
}
  

  onDeletePhrase(){
    this.deletePhrase.emit();
  }

}
