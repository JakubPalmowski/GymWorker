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
          console.log(id);
          this.idDiet=id;
          
          this.dietService.getDieticianDietById(this.idDiet).subscribe({
            next:(diet)=>{
              console.log(diet);
              this.diet=diet;
             
              this.formStartDate=this.diet.startDate.toString().split('T')[0];
            
              
          
            },
            error: (response)=>{
             console.log(response);
            }
          })
            this.getDietMeals(id);
        }
        else{
          console.log("no");
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
        console.log("here"+response);
      }
    })
  }

  

  editDiet(){
    console.log("edit");
    console.log(this.diet);
    console.log(this.idDiet);
    const responseDiv = document.getElementById("edit-resp");
    this.fieldErrors = {};

    this.dietService.editDiet(this.diet,this.idDiet).subscribe({
      next:(diet)=>{
        console.log(diet);
        if(responseDiv){
        responseDiv.innerHTML="Edycja diety powiodła się";
        }
      },
      error:(error)=>{
        console.log(error);
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

  onSubmit(valid:any)
  {
    this.submitted=true;
    if(valid){
      console.log(valid)
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

    const selectedDay=document.getElementById(val);

    const pn=document.getElementById('pn');
    const wt=document.getElementById('wt');
    const sr=document.getElementById('sr');
    const czw=document.getElementById('czw');
    const pt=document.getElementById('pt');
    const sob=document.getElementById('sob');
    const nd=document.getElementById('nd');

    pn?.classList.remove('selected-day');
    wt?.classList.remove('selected-day');
    sr?.classList.remove('selected-day');
    czw?.classList.remove('selected-day');
    pt?.classList.remove('selected-day');
    sob?.classList.remove('selected-day');
    nd?.classList.remove('selected-day');

    this.filterDietDay(day);


    selectedDay?.classList.add('selected-day');


  }

  

  openDeleteDialog(name:string){
    console.log("open");
    this.deleteErrorFlag=false;
    if(this.deleteDialogFlag!=true){
     this.deleteDialogFlag=true;
    
   }
   }
 
   
   deleteDietMeal(idMealDiet:number) {
     console.log("delete");
     console.log(idMealDiet);
     this.mealService.deleteDietMeal(idMealDiet.toString()).subscribe({
       next:(response)=>{
         console.log(response);
         this.deleteDialogFlag=false;
        window.location.reload(); 
         
      
       },
       error:(response)=>{
         console.log(response);
         this.deleteErrorFlag=true;
       }});
 
     }
 
   cancelDelete(){
     console.log("cancel");
     this.deleteDialogFlag=false;
   }
   
  
}
