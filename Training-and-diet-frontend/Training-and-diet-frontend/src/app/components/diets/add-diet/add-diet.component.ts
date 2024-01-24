import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DietAddEdit } from 'src/app/models/diet/DietAddEdit.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { DietService } from 'src/app/services/diet.service';

@Component({
  selector: 'app-add-diet',
  templateUrl: './add-diet.component.html',
  styleUrls: ['./add-diet.component.css']
})
export class AddDietComponent implements OnInit{
  

  submitted=false;

  addDietRequest: DietAddEdit={
    name: '',
    customName: '',
    type: '',
    startDate: new Date,
    numberOfWeeks: 0,
    TotalKcal: 0
  }

  dateToday:string='';

  constructor(private dietService:DietService, private router:Router, private authenticationService:AuthenticationService){}
  ngOnInit(): void {
    this.dateToday=new Date().toISOString().split("T")[0];
    console.log(document.getElementById("start_date"));


  }

  addTrainingPlan(){

    this.dietService.addDiet(this.addDietRequest).subscribe({
      next:(diet)=>{
   
        console.log(localStorage.getItem('acessToken'));
        this.router.navigate(['/training-plans']);
      },
      error: (response)=>{
        console.log(response);

      }
    });
  }



  onSubmit(valid:any){
    this.submitted=true;
    if(valid){
      console.log(this.addDietRequest);
      
      this.addTrainingPlan();
      
    }
    
  }


}
