import { Component } from '@angular/core';
import { DietPupilList } from 'src/app/models/diet/diet-pupil-list.model';
import { DietService } from 'src/app/services/diet.service';

@Component({
  selector: 'app-pupil-diet-list',
  templateUrl: './pupil-diet-list.component.html',
  styleUrls: ['./pupil-diet-list.component.css']
})
export class PupilDietListComponent {


  diets:DietPupilList[]=[];

  constructor(private dietService:DietService){}

  ngOnInit(): void {
    this.dietService.getPupilDiets().subscribe({
      next:(diets)=>{
        this.diets=diets;
      },
      error: (response)=>{
      }
    })
  }

  getEndDate(date:Date){
    return new Date(date).toISOString().split("T")[0];
  }
}
