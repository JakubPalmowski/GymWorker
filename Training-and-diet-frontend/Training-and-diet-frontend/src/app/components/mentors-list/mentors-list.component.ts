import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Mentor } from 'src/app/models/mentor';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-mentors-list',
  templateUrl: './mentors-list.component.html',
  styleUrls: ['./mentors-list.component.css']
})
export class MentorsListComponent implements OnInit{

    constructor(private userService: UserService,  private router:ActivatedRoute){
      
    }
    mentors: Mentor[]=[];
    role: string|undefined='';
  
  ngOnInit(): void{

    this.router.url.subscribe(segments => {
      const lastSegment = segments[segments.length - 1];
      this.role = lastSegment.path;
      })
    
    if(this.role=="trainersList"){
    this.userService.GetAllTrainers().subscribe({
      next:(mentors)=>{
        this.mentors=mentors;
      },
      error: (response)=>{
        console.log(response);
      }
    })
  }
  if(this.role=="dieticiansList"){
    this.userService.GetAllDieteticians().subscribe({
      next:(mentors)=>{
        this.mentors=mentors;
      },
      error: (response)=>{
        console.log(response);
      }
    })
  }
}
  
  }
  
