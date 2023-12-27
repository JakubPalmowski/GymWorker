import { Component, Input, Output, EventEmitter, OnInit, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Gym } from 'src/app/models/gym';
import { Sort } from 'src/app/models/sort';
import { GymService } from 'src/app/services/gym.service';

@Component({
  selector: 'app-search-options',
  templateUrl: './search-options.component.html',
  styleUrls: ['./search-options.component.css']
})
export class SearchOptionsComponent implements OnInit{

  constructor(private gymService: GymService, private route:ActivatedRoute){}

  gymCities:string[]=[];
  gymClubsNames:string[]=[];

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.sortOptions.sort = params['SortBy'] || '';
      if(this.sortOptions.sort=="Mentor_Opinions"){
        this.sortOptionsView.sort = "Ocena";
      }
      
    });
    this.route.queryParams.subscribe(params => {
      this.sortOptions.gymCity = params['GymCityPhrase'] || '';
      this.sortOptionsView.gymCity = params['GymCityPhrase'] || '';
    });
    this.route.queryParams.subscribe(params => {
      this.sortOptions.gymName = params['GymNamePhrase'] || '';
      this.sortOptionsView.gymName = params['GymNamePhrase'] || '';
    });

    this.gymService.GetAllGyms().subscribe({
      next:(response)=>{
        this.gymCities=response.map(gym=>gym.cityName);
        this.gymClubsNames=response.map(gym=>gym.name);
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

  @Input()
  sortOptionsView: Sort={
    sort:'',
    gymCity:'',
    gymName:''
  }
  @Input()
  sortOptions: Sort={
    sort:'',
    gymCity:'',
    gymName:''
  }

  @Output()
  filterData: EventEmitter<Sort> = new EventEmitter<Sort>()


  onFilterData(action: string){
    if(action=="filter"){
        if(this.sortOptions.sort=="Mentor_Opinions"){
          this.sortOptionsView.sort = "Ocena";
        }
      this.sortOptionsView.gymCity = this.sortOptions.gymCity;
      this.sortOptionsView.gymName = this.sortOptions.gymName;
      this.filterData.emit(this.sortOptions);
       
        }
    if(action=="deleteSort"){
      this.sortOptions.sort='';
      this.sortOptionsView.sort = '';
      this.filterData.emit(this.sortOptions)
    }
    if(action=="deleteGymCity"){
      this.sortOptions.gymCity = '';
      this.sortOptionsView.gymCity = '';
      this.filterData.emit(this.sortOptions)
    }
    if(action=="deleteGymName"){
      this.sortOptions.gymName = '';
      this.sortOptionsView.gymName = '';
      this.filterData.emit(this.sortOptions)
    }
    
}
  
  onSelectGymCity(selectedCity: string) {
    this.sortOptions.gymCity = selectedCity;
  }

  onSelectGymName(selectedName: string){
    this.sortOptions.gymName = selectedName;
  }


  onDeletePhrase(){
    this.deletePhrase.emit();
  }
}
