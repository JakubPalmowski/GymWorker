import { Component, OnInit } from '@angular/core';
import { PupilPersonalInfo } from 'src/app/models/pupilPersonalInfo';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-my-profile-edit',
  templateUrl: './my-profile-edit.component.html',
  styleUrls: ['./my-profile-edit.component.css']
})
export class MyProfileEditComponent implements OnInit {


constructor(private userSerive: UserService) {}

pupil: PupilPersonalInfo|undefined;


imageUrl: string | ArrayBuffer | null = null;

onFileSelected(event:any) {
  const file = event.target.files[0];
  if (file) {
    const reader = new FileReader();
    reader.onload = e => this.imageUrl = reader.result;
    reader.readAsDataURL(file);
  }
}


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
