import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PupilProfile } from 'src/app/models/mentor-pupil/pupil-profile.model';
import { FileService } from 'src/app/services/file.service';
import { PreviousUrlService } from 'src/app/services/previous-url.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-pupil-profile',
  templateUrl: './pupil-profile.component.html',
  styleUrls: ['./pupil-profile.component.css']
})
export class PupilProfileComponent implements OnInit{


pupil: PupilProfile | undefined;
imageUrl: string = "";

constructor(private route: ActivatedRoute, private userService: UserService, private fileService: FileService, private previousUrl: PreviousUrlService, private router: Router) {
  
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
              this.fileService.getFile(this.pupil.imageUri).subscribe(
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
          error: () => {
            this.router.navigateByUrl('/');
          }
        }
      );
      
    }

    back() {
      this.router.navigateByUrl(this.previousUrl.getPreviousUrl());
      }


      calculateAge(birthDateInput: Date | undefined): number | undefined{
        if (!birthDateInput) {
            return undefined;
        }
        const birthDate = birthDateInput instanceof Date ? birthDateInput : new Date(birthDateInput);
            const currentDate = new Date();
            let age = currentDate.getFullYear() - birthDate.getFullYear();
            const monthDifference = currentDate.getMonth() - birthDate.getMonth();
    
            if (monthDifference < 0 || (monthDifference === 0 && currentDate.getDate() < birthDate.getDate())) {
                age--;
            }
    
            return age;
       
    }
  
    
  

}
