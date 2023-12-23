import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MentorProfile } from 'src/app/models/mentorProfile';
import { PreviousUrlService } from 'src/app/services/previous-url.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-mentor-profile',
  templateUrl: './mentor-profile.component.html',
  styleUrls: ['./mentor-profile.component.css']
})
export class MentorProfileComponent implements OnInit {
  constructor(private userService: UserService, private router:ActivatedRoute, private previousUrlService: PreviousUrlService){

  }

  mentorId:string='';
  mentor:MentorProfile | undefined;
  role: string|undefined='';
  previousUrl: string='';

  ngOnInit():void{

    this.mentorId = this.router.snapshot.params['id'];
    this.router.url.subscribe(segments => {
      const roleSegment = segments[segments.length - 2];
      this.role = roleSegment.path;})

    
    if(this.role=="trainerProfile"){
    this.userService.GetTrainerWithOpinionsById(this.mentorId).subscribe(
      {
        next:(trainerInfo)=>{
          this.mentor=trainerInfo;
        },
        error: (response)=>{
          console.log(response);
        }
      }
    )
    }
    if(this.role=="dieticianProfile"){
      this.userService.GetDieticianWithOpinionsById(this.mentorId).subscribe(
        {
          next:(dieticianInfo)=>{
            this.mentor=dieticianInfo;
          },
          error: (response)=>{
            console.log(response);
          }
        }
      )
      }

    
  }
}
