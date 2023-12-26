import { Component, Input, Output, EventEmitter, OnInit, ChangeDetectorRef } from '@angular/core';
import { Gym } from 'src/app/models/gym';
import { Sort } from 'src/app/models/sort';
import { GymService } from 'src/app/services/gym.service';

@Component({
  selector: 'app-search-options',
  templateUrl: './search-options.component.html',
  styleUrls: ['./search-options.component.css']
})
export class SearchOptionsComponent implements OnInit{

  constructor(private gymService: GymService){}

  gym:Gym[]=[];
  gymCities:string[]=[];
  gymClubsNames:string[]=[];

  ngOnInit(): void {
    this.gymService.GetAllGyms().subscribe({
      next:(response)=>{
        this.gymCities=response.map(gym=>gym.cityName);
        this.gymClubsNames=response.map(gym=>gym.name);
        console.log(this.gymCities);
        console.log(this.gymClubsNames);
      },
      error:(error)=>{

      }
    })
    
  }

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
