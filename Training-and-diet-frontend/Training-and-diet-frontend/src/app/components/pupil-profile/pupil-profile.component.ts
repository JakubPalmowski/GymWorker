import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PupilProfile } from 'src/app/models/pupilProfile';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-pupil-profile',
  templateUrl: './pupil-profile.component.html',
  styleUrls: ['./pupil-profile.component.css']
})
export class PupilProfileComponent implements OnInit{

pupil: PupilProfile | undefined;

constructor(private route: ActivatedRoute, private userService: UserService) {
  
}
  ngOnInit(): void {
    const pupilId = this.route.snapshot.params['id'];

   
      this.userService.GetPupilById(pupilId).subscribe(
        {
          next:(pupilInfo)=>{
            this.pupil=pupilInfo;
          },
          error: (response)=>{
            console.log(response);
          }
        }
      )
    }
  

}
