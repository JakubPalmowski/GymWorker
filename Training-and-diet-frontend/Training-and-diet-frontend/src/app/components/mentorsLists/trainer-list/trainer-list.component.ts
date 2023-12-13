import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { Mentor } from 'src/app/models/mentor';


@Component({
  selector: 'app-trainer-list',
  templateUrl: './trainer-list.component.html',
  styleUrls: ['./trainer-list.component.css']
})
export class TrainerListComponent implements OnInit{

  constructor(private trainerService: UserService){
    
  }
  trainers: Mentor[]=[];

ngOnInit(): void{
  this.trainerService.GetAllTrainers().subscribe({
    next:(trainers)=>{
      this.trainers=trainers;
    },
    error: (response)=>{
      console.log(response);
    }
  })
}

}
