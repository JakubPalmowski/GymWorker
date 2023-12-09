import { Component, OnInit } from '@angular/core';
import { TrainerService } from 'src/app/services/trainer.service';
import { Trainer } from 'src/app/models/trainer';


@Component({
  selector: 'app-trainer-list',
  templateUrl: './trainer-list.component.html',
  styleUrls: ['./trainer-list.component.css']
})
export class TrainerListComponent implements OnInit{

  constructor(private trainerService: TrainerService){
    
  }
  trainers: Trainer[]=[];

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
