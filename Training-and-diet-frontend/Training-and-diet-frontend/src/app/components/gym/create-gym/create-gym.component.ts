import { Component, OnInit } from '@angular/core';
import { GymsAddedByUser } from 'src/app/models/gym/gymsAddedByUser';
import { GymService } from 'src/app/services/gym.service';

@Component({
  selector: 'app-create-gym',
  templateUrl: './create-gym.component.html',
  styleUrls: ['./create-gym.component.css']
})
export class CreateGymComponent implements OnInit {

  //Komponent dostepny dla Trainer/Dietician/Dietician-Trainer i moze admin
  GymsAddedByUser: GymsAddedByUser[] | undefined;
  constructor(private gymService: GymService) { }

  ngOnInit(): void {
    //Po dodaniu uwierzytelnienia trzeba będzie pobrać dane zalogowanego użytkownika z jwt Tokena
    this.gymService.GetGymsAddedByUser("2").subscribe({
      next: (gyms) => {
        this.GymsAddedByUser = gyms;
      },
      error: (response) => {
        console.log(response);
      }
    })
  }
}
