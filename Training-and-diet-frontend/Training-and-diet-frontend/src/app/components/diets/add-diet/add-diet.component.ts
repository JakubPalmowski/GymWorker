import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DietAddEdit } from 'src/app/models/diet/diet-add-edit.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { DietService } from 'src/app/services/diet.service';

@Component({
  selector: 'app-add-diet',
  templateUrl: './add-diet.component.html',
  styleUrls: ['./add-diet.component.css']
})
export class AddDietComponent implements OnInit{
  

  submitted=false;
  fieldErrors: { [key: string]: string[] } = {};
  errorFlag: string = "";

  addDietRequest: DietAddEdit={
    name: '',
    customName: '',
    type: '',
    startDate: new Date,
    numberOfWeeks: 0,
    totalKcal: 0
  }

  dateToday:string='';

  constructor(private dietService:DietService, private router:Router, private authenticationService:AuthenticationService){}
  ngOnInit(): void {
    this.dateToday=new Date().toISOString().split("T")[0];
  }

  addDiet(){
    this.fieldErrors = {};
    this.dietService.addDiet(this.addDietRequest).subscribe({
      next:(diet)=>{
        this.router.navigate(['/diet']);
      },
      error: (error)=>{
       if(error.status===400){
        const {errors} = error.error;
        for(const key in errors){
          if(errors.hasOwnProperty(key)){
            this.fieldErrors[key] = errors[key]; 
          }
        }
       }else{
            this.errorFlag = "error";
            this.showErrorPopup(this.errorFlag);
            document.documentElement.scrollTop = 0;
       }

      }
    });
  }


  onSubmit(valid:any){
    this.submitted=true;
    if(valid){
      this.addDiet();
    }
    
  }

  showErrorPopup(status: string) {
    if(status == "error"){
      setTimeout(() => this.errorFlag="", 3000); 
    }
  }


}
