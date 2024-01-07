import { Component, OnInit } from '@angular/core';
import { PupilPersonalInfo } from 'src/app/models/pupilPersonalInfo';
import { PupilProfile } from 'src/app/models/pupilProfile';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.css']
})
export class MyProfileComponent implements OnInit {


constructor(private userSerive: UserService) {}

  pupil: PupilPersonalInfo|undefined;

  ngOnInit(): void {
    //Po dodaniu uwierzytelnienia trzeba będzie pobrać dane zalogowanego użytkownika z jwt Tokena
    var role = "Pupil"
    var id = "2";

    if (role == "Pupil") {
      this.userSerive.GetPupilPersonalInfoById(id).subscribe(
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
    else if (role == "Trainer") {
      //Pobranie danych mentora
      //Pobranie danych osobowych mentora
    }else if (role == "Dietician") {
      //Pobranie danych mentora
      //Pobranie danych osobowych mentora
    }
    else if (role == "Dietician-Trainer") {
      //Pobranie danych mentora
      //Pobranie danych osobowych mentora
    }
    
  }

}
