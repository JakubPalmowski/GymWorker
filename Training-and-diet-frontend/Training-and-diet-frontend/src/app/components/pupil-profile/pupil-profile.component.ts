import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PupilProfile } from 'src/app/models/pupilProfile';
import { FileService } from 'src/app/services/file.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-pupil-profile',
  templateUrl: './pupil-profile.component.html',
  styleUrls: ['./pupil-profile.component.css']
})
export class PupilProfileComponent implements OnInit{

pupil: PupilProfile | undefined;
imageUrl: string = "";

constructor(private route: ActivatedRoute, private userService: UserService, private fileService: FileService) {
  
}
  ngOnInit(): void {
    const pupilId = this.route.snapshot.params['id'];

   
      this.userService.GetPupilById(pupilId).subscribe(
        {
          next: (pupilInfo) => {
            if (!pupilInfo) {
              return;
            }
            this.pupil = pupilInfo;
            if (this.pupil.imageUri) {
              this.fileService.getImage(this.pupil.imageUri).subscribe(
                blob => {
                  if (blob) {
                    const objectUrl = URL.createObjectURL(blob);
                    this.imageUrl = objectUrl;
                  }
                },
                error => {
                  this.imageUrl = "assets/images/user.png";
                }
              );
            } else {
              this.imageUrl = "assets/images/user.png";
            }
          },
          error: (response) => {
          }
        }
      );
      
    }
  

}
