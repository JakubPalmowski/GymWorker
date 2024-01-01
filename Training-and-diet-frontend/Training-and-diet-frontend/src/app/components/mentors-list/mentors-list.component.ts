import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Mentor } from 'src/app/models/mentor';
import { MentorList } from 'src/app/models/mentorList';
import { Sort } from 'src/app/models/sort';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-mentors-list',
  templateUrl: './mentors-list.component.html',
  styleUrls: ['./mentors-list.component.css']
})
export class MentorsListComponent implements OnInit{

    constructor(private userService: UserService,  private route:ActivatedRoute, private router: Router){
      
    }
    response: MentorList | undefined;
    mentors: Mentor[]=[];
    role: string|undefined='';
    totalPages: number=0;
    isDataLoaded: boolean=true;

    currentPage: number = 1;
    searchPhrase: string='';
    sortBy: Sort={
      sort:'',
      gymCity:'',
      gymName:'',
      sortDirection:''
    }
    
  
  ngOnInit(): void{
   

    this.route.url.subscribe(segments => {
      const lastSegment = segments[segments.length - 1];
      this.role = lastSegment.path;
      })

    this.route.queryParams.subscribe(params => {
      this.currentPage = +params['PageNumber'] || 1;
    });

    this.route.queryParams.subscribe(params => {
      this.searchPhrase = params['SearchPhrase'] || '';
    });

    this.route.queryParams.subscribe(params => {
      this.sortBy.sort = params['SortBy'] || '';
    });
    this.route.queryParams.subscribe(params => {
      this.sortBy.gymCity = params['GymCityPhrase'] || '';
    });
    this.route.queryParams.subscribe(params => {
      this.sortBy.gymName = params['GymNamePhrase'] || '';
    });
    this.route.queryParams.subscribe(params => {
      this.sortBy.sortDirection = params['SortDirection'] || '';
    });
    
    
   this.loadData();
}



  private loadData(){


    const queryParams: any = { PageNumber: this.currentPage };
    if(this.searchPhrase){
      queryParams.SearchPhrase = this.searchPhrase;
    }
    if(this.sortBy.sort){
      queryParams.SortBy = this.sortBy.sort;
    }
    if(this.sortBy.sortDirection){
      queryParams.SortDirection = this.sortBy.sortDirection;
    }

  if(this.role == 'trainersList'){
    if(this.sortBy.gymCity){
      queryParams.GymCityPhrase = this.sortBy.gymCity;
    }
    if(this.sortBy.gymName){
      queryParams.GymNamePhrase = this.sortBy.gymName;
    }
    this.router.navigate(['/trainersList'], { queryParams: queryParams});
  }

  if(this.role == 'dieticiansList'){
    this.router.navigate(['/dieticiansList'],{queryParams: queryParams});
  }

    
    if(this.role=="trainersList"){
    this.userService.GetAllTrainers(this.currentPage, this.searchPhrase, this.sortBy.sort, this.sortBy.sortDirection, this.sortBy.gymCity, this.sortBy.gymName).subscribe({
      next:(response)=>{
        this.response=response;
        this.mentors=response.items;
        this.totalPages=response.totalPages;
        this.isDataLoaded=true;
      },
      error: (response)=>{
        this.isDataLoaded=false;
      }
    })

  }


  if(this.role=="dieticiansList"){
    this.userService.GetAllDieteticians(this.currentPage, this.searchPhrase, this.sortBy.sort, this.sortBy.sortDirection).subscribe({
      next:(response)=>{
        this.response=response;
        this.mentors=response.items;
        this.totalPages=response.totalPages;
        this.isDataLoaded=true;
      },
      error: (response)=>{
        this.isDataLoaded=false;
      }
    })
  }
  }

  goToPage(page : number) {
    this.currentPage = page;
    this.loadData();
    document.documentElement.scrollTop = 0;
    }




  searchMentorByPhrase(phrase: string){
    this.searchPhrase=phrase;
    this.currentPage=1;
    this.loadData();
  }


  deletePhrase(){
    this.searchPhrase='';
    this.currentPage=1;
    this.loadData();
  }

  filterData(sortOptions:Sort){
    this.sortBy.sort=sortOptions.sort;
    this.sortBy.gymCity=sortOptions.gymCity;
    this.sortBy.gymName=sortOptions.gymName;
    this.sortBy.sortDirection=sortOptions.sortDirection;
    this.currentPage=1;
    this.loadData();
  }
}
  
