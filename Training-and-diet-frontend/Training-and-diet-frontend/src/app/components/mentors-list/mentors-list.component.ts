import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Mentor } from 'src/app/models/mentor';
import { MentorList } from 'src/app/models/mentorList';
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
    nextPage: number=1;
  
  ngOnInit(): void{
    this.route.queryParams.subscribe(params => {
      this.currentPage = +params['PageNumber'] || 1;
    });
    
    this.route.url.subscribe(segments => {
      const lastSegment = segments[segments.length - 1];
      this.role = lastSegment.path;
      })
   this.loadData(this.currentPage);
}

goToPage(page : number) {
if(this.role == 'trainersList'){
  this.router.navigate(['/trainersList'], { queryParams: { PageNumber: page } });
}
if(this.role == 'dieticiansList'){
  this.router.navigate(['/dieticiansList'],{queryParams: {PageNumber: page}});
}
  this.loadData(page);
  }

  private loadData(page: number){
  this.currentPage=page;
    
    if(this.role=="trainersList"){
    this.userService.GetAllTrainers(this.currentPage).subscribe({
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
}
  
