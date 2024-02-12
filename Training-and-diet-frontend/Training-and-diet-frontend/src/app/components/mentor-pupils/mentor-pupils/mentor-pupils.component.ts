import { Component, OnInit } from '@angular/core';
import { forkJoin, of, switchMap } from 'rxjs';
import { Invitation } from 'src/app/models/mentor-pupil/invitation.model';
import { FileService } from 'src/app/services/file.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-mentor-pupils',
  templateUrl: './mentor-pupils.component.html',
  styleUrls: ['./mentor-pupils.component.css']
})
export class MentorPupilsComponent implements OnInit {
 

  pupils: Invitation[] | undefined;


  constructor(private userService: UserService, private fileService: FileService) {

    
  }


  ngOnInit(): void {
    this.userService.getMentorPupils().pipe(
      switchMap((pupils) => {
        this.pupils = pupils;
  
        if (pupils.length === 0) {
          return of([]);
        }
  
        const imageRequests = pupils.map(pupil => {
          if (pupil.imageUri) {
  
            return this.fileService.getFile(pupil.imageUri).pipe(
              switchMap((imageSrc) => {
   
                pupil.imageSrc = URL.createObjectURL(imageSrc); 
                return of(pupil); 
              })
            );
          } else {
     
            pupil.imageSrc = 'assets/images/user.png';
            return of(pupil); 
          }
        });
        return forkJoin(imageRequests);
      })
    ).subscribe(
    );
  }
}
