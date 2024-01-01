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
    });
    this.route.queryParams.subscribe(params => {
      this.sortOptions.sortDirection = params['SortDirection'] || '';
    });

    switch (this.sortOptions.sort + "_" + this.sortOptions.sortDirection) {
    case "Mentor_Opinions_DESC":
        this.sortOptionsView.sort = "Ocena(od najlepszych)";
        this.sortValue = "Mentor_Opinions_DESC";
        break;
    case "Mentor_Opinions_ASC":
        this.sortOptionsView.sort = "Ocena(od najgorszych)";
        this.sortValue = "Mentor_Opinions_ASC";
        break;
    case "Plan_Price_ASC":
        this.sortOptionsView.sort = "Cena planu(od najtańszych)";
        this.sortValue = "Plan_Price_ASC";
        break;
    case "Plan_Price_DESC":
        this.sortOptionsView.sort = "Cena planu(od najdroższych)";
        this.sortValue = "Plan_Price_DESC";
        break;
    case "Training_Price_ASC":
          this.sortOptionsView.sort = "Cena treningu(od najtańszych)";
          this.sortValue = "Training_Price_ASC";
          break;
    case "Training_Price_DESC":
          this.sortOptionsView.sort = "Cena treningu(od najdroższych)";
          this.sortValue = "Plan_Price_DESC";
          break;
    case "Diet_Price_ASC":
            this.sortOptionsView.sort = "Cena diety(od najtańszych)";
            this.sortValue = "Diet_Price_ASC";
            break;
    case "Diet_Price_DESC":
            this.sortOptionsView.sort = "Cena diety(od najdroższych)";
            this.sortValue = "Diet_Price_DESC";
            break;
    
    }


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

  
  sortOptionsView: Sort={
    sort:'',
    gymCity:'',
    gymName:'',
    sortDirection:''
  }
  
  sortOptions: Sort={
    sort:'',
    gymCity:'',
    gymName:'',
    sortDirection:''
  }

  sortValue: string='';

  @Output()
  filterData: EventEmitter<Sort> = new EventEmitter<Sort>()


  onFilterData(action: string){
    if(action=="filter"){
      switch (this.sortValue) {
        case "Mentor_Opinions_DESC":
            this.sortOptionsView.sort = "Ocena(od najlepszych)";
            this.sortOptions.sort = "Mentor_Opinions";
            this.sortOptions.sortDirection = "DESC";
            break;
        case "Mentor_Opinions_ASC":
            this.sortOptionsView.sort = "Ocena(od najgorszych)";
            this.sortOptions.sort = "Mentor_Opinions";
            this.sortOptions.sortDirection = "ASC";
            break;
        case "Plan_Price_ASC":
            this.sortOptionsView.sort = "Cena planu(od najtańszych)";
            this.sortOptions.sort = "Plan_Price";
            this.sortOptions.sortDirection = "ASC";
            break;
        case "Plan_Price_DESC":
            this.sortOptionsView.sort = "Cena planu(od najdroższych)";
            this.sortOptions.sort = "Plan_Price";
            this.sortOptions.sortDirection = "DESC";
            break;
        case "Training_Price_ASC":
              this.sortOptionsView.sort = "Cena treningu(od najtańszych)";
              this.sortOptions.sort = "Training_Price";
              this.sortOptions.sortDirection = "ASC";
              break;
        case "Training_Price_DESC":
              this.sortOptionsView.sort = "Cena treningu(od najdroższych)";
              this.sortOptions.sort = "Training_Price";
              this.sortOptions.sortDirection = "DESC";
              break;
        case "Diet_Price_ASC":
                this.sortOptionsView.sort = "Cena diety(od najtańszych)";
                this.sortOptions.sort = "Diet_Price";
                this.sortOptions.sortDirection = "ASC";
                break;
        case "Diet_Price_DESC":
                this.sortOptionsView.sort = "Cena diety(od najdroższych)";
                this.sortOptions.sort = "Diet_Price";
                this.sortOptions.sortDirection = "DESC";
                break;
      }
      this.sortOptionsView.gymCity = this.sortOptions.gymCity;
      this.sortOptionsView.gymName = this.sortOptions.gymName;
      this.filterData.emit(this.sortOptions);
       
        }
    if(action=="deleteSort"){
      this.sortOptions.sort='';
      this.sortOptionsView.sort = '';
      this.sortOptions.sortDirection='';
      this.sortValue='';
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
