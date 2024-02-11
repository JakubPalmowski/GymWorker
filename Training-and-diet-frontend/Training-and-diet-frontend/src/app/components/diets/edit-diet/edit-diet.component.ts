import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DietMentorGet } from 'src/app/models/diet/diet-mentor-get.model';
import { MealDietList } from 'src/app/models/diet/meal-diet-list.model';
import { DietService } from 'src/app/services/diet.service';
import { MealsService } from 'src/app/services/meals.service';

@Component({
  selector: 'app-edit-diet',
  templateUrl: './edit-diet.component.html',
  styleUrls: ['./edit-diet.component.css']
})
export class EditDietComponent implements OnInit{

  submitted=false;
  fieldErrors: { [key: string]: string[] } = {};
  errorFlag: string = "";
  successFlag: string = "";


  filteredDietMeals:MealDietList[]=[];

  dietMeals:MealDietList[]=[];
 
  diet:DietMentorGet={
    idDiet: 0,
    name: '',
    customName: '',
    type: '',
    startDate: new Date(),
    endDate: new Date(),
    numberOfWeeks: 0,
    idDietician: 0,
    idPupil: 0,
    pupilName: '',
    pupilLastName: '',
    totalKcal: 0
  }

  formStartDate:string='';
  formEndDate:string='';

  dateToday:string='';


  idDiet:string='';
  deleteDialogFlag: boolean=false;
  deleteErrorFlag: boolean=false;



  constructor(private route:ActivatedRoute, private dietService:DietService, private mealService:MealsService, private router:Router){}

  ngOnInit(): void {
    this.dateToday=new Date().toISOString().split("T")[0];
    this.route.paramMap.subscribe({
      next:(params)=>{
        const id=params.get('id');
        
      
        this.changeDietDay(1,'pn');
        
        if(id){
          this.idDiet=id;
          
          this.dietService.getDieticianDietById(this.idDiet).subscribe({
            next:(diet)=>{
              this.diet=diet;
              this.formStartDate=this.diet.startDate.toString().split('T')[0];
          
            },
            error: (response)=>{
            }
          })
            this.getDietMeals(id);
        }
        else{
        }
      }
    })
  }

  getDietMeals(id:string){
    this.dietService.getDietMealsByDietId(id).subscribe({
      next:(dietMeals)=>{
        this.dietMeals=dietMeals;
        this.changeDietDay(1,"pn");

      

      },
      error: (response)=>{
      }
    })
  }

  

  editDiet(){
    const responseDiv = document.getElementById("edit-resp");
    this.fieldErrors = {};

    this.dietService.editDiet(this.diet,this.idDiet).subscribe({
      next:(diet)=>{
        this.successFlag = "success";
          this.showSuccessPopup(this.successFlag);
          this.fieldErrors = {}; 
          document.documentElement.scrollTop = 0;
      },
      error:(error)=>{
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
        }}
    });
  }

  showSuccessPopup(status: string) {
    if (status == "success") {
      setTimeout(() => this.successFlag="", 3000); 
    }
    if(status == "error"){
      setTimeout(() => this.successFlag="", 3000); 
    }
  
  }

  onSubmit(valid:any)
  {
    this.submitted=true;
    if(valid){
      this.diet.startDate=new Date(this.formStartDate);
      this.editDiet();
      
    }
  }

  showErrorPopup(status: string) {
    if(status == "error"){
      setTimeout(() => this.errorFlag="", 3000); 
    }
  
  }
  
  filterDietDay(day:number){
    this.filteredDietMeals=this.dietMeals.filter(
      dietMeals => dietMeals?.dayOfWeek==day
    )
    this.filteredDietMeals.sort((a,b)=>a.hourOfMeal.localeCompare(b.hourOfMeal));
  }

  changeDietDay(day:number,val:string){

    const dayIds = ['pn', 'wt', 'sr', 'czw', 'pt', 'sob', 'nd'];
    dayIds.forEach(dayId => {
        document.getElementById(dayId)?.classList.remove('selected-day');
        document.getElementById(dayId + '-sm')?.classList.remove('selected-day');
    });


    let smVal, fullVal;
    if (val.includes('-sm')) {
        smVal = val;
        fullVal = val.replace('-sm', ''); 
    } else {
        smVal = val + '-sm'; 
        fullVal = val;
    }
    document.getElementById(fullVal)?.classList.add('selected-day');
    document.getElementById(smVal)?.classList.add('selected-day');

    this.filterDietDay(day);


  }

  

  openDeleteDialog(name:string){
    this.deleteErrorFlag=false;
    if(this.deleteDialogFlag!=true){
     this.deleteDialogFlag=true;
    
   }
   }
 
   
   deleteDietMeal(idMealDiet:number) {
     this.mealService.deleteDietMeal(idMealDiet.toString()).subscribe({
       next:(response)=>{
         this.deleteDialogFlag=false;
        window.location.reload(); 
         
      
       },
       error:(response)=>{
         this.deleteErrorFlag=true;
       }});
 
     }
 
   cancelDelete(){
     this.deleteDialogFlag=false;
   }
   
}
