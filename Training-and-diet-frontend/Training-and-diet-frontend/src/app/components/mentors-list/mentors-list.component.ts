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

    currentPage: number = 1;
    searchPhrase: string='';
    sortBy: Sort={
      sort:'',
      gymCity:'',
      gymName:''
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
    this.userService.GetAllTrainers(this.currentPage, this.searchPhrase, this.sortBy.sort, this.sortBy.gymCity, this.sortBy.gymName).subscribe({
      next:(response)=>{
        this.response=response;
        this.mentors=response.items;
        this.totalPages=response.totalPages;
      },
      error: (response)=>{
        this.mentors=[];
      }
    })

  }


  if(this.role=="dieticiansList"){
    this.userService.GetAllDieteticians(this.currentPage, this.searchPhrase, this.sortBy.sort).subscribe({
      next:(response)=>{
        this.response=response;
        this.mentors=response.items;
        this.totalPages=response.totalPages;
      },
      error: (response)=>{
        this.mentors=[];
      }
    })
  }
  }

  goToPage(page : number) {
    this.currentPage = page;
    this.loadData();
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
    this.currentPage=1;
    this.loadData();
  }
}
  
