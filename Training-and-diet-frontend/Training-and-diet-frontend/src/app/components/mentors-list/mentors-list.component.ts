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
    currentPage: number = 1;
    totalPages: number=0;
    searchPhrase: string='';
  
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
    
    
   this.loadData(this.currentPage, this.searchPhrase);
}



  private loadData(page: number, searchPhrase: string){
  this.currentPage=page;
  this.searchPhrase=searchPhrase;

  if(this.role == 'trainersList'){
    const queryParams: any = { PageNumber: page };
    if(this.searchPhrase){
      queryParams.SearchPhrase = this.searchPhrase;
    }
    this.router.navigate(['/trainersList'], { queryParams: queryParams});
  }

  if(this.role == 'dieticiansList'){
    this.router.navigate(['/dieticiansList'],{queryParams: {PageNumber: page}});
  }

    
    if(this.role=="trainersList"){
    this.userService.GetAllTrainers(this.currentPage, this.searchPhrase).subscribe({
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
    this.userService.GetAllDieteticians(this.currentPage).subscribe({
      next:(response)=>{
        this.response=response;
        this.mentors=response.items;
        this.totalPages=response.totalPages;
      },
      error: (response)=>{
        console.log(response);
      }
    })
  }
  }

  goToPage(page : number) {
    this.loadData(page, this.searchPhrase);
    }




  searchMentorByPhrase(phrase: string){
    this.searchPhrase=phrase;
    this.loadData(1, this.searchPhrase);
  }


  deletePhrase(){
    this.searchPhrase='';
    this.loadData(1, this.searchPhrase);
  }

  filterData(sortOptions:Sort){

  }
}
  
