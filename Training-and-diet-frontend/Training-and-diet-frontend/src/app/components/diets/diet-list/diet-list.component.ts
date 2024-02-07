import { Component, OnInit } from '@angular/core';
import { DietListDietician } from 'src/app/models/diet/diet-list-dietician.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { DietService } from 'src/app/services/diet.service';

@Component({
  selector: 'app-diet-list',
  templateUrl: './diet-list.component.html',
  styleUrls: ['./diet-list.component.css']
})
export class DietListComponent implements OnInit {

  diets:DietListDietician[]=[];
  filteredDiets:DietListDietician[]=[];
  searchTerm: string = '';



  constructor(private dietService:DietService, private authenticationService:AuthenticationService){}

  ngOnInit(): void {
    if(this.authenticationService.getUserId()==undefined){
     // TODO return this.authenticationService.logout();
    }
    this.dietService.getDieticianDiets().subscribe({
      next:(diets)=>{
        this.diets=diets;
        this.filteredDiets=this.diets;
      },
      error: (response)=>{
        console.log(response);
      }
    })
  }

  filterResults() {
    if (!this.searchTerm) {
      this.filteredDiets = this.diets; 
    } else {
      this.filteredDiets = this.diets?.filter(diet =>
        diet.name.toLowerCase().includes(this.searchTerm.toLowerCase())
      );
    }
  }

  getEndDate(date:Date){
    return new Date(date).toISOString().split("T")[0];
  }

}
