import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DietMentorGet } from 'src/app/models/diet/diet-mentor-get.model';
import { MealDietMentorList } from 'src/app/models/diet/meal-diet-mentor-list.model';
import { DietService } from 'src/app/services/diet.service';
import { MealsService } from 'src/app/services/meals.service';

@Component({
  selector: 'app-edit-diet',
  templateUrl: './edit-diet.component.html',
  styleUrls: ['./edit-diet.component.css']
})
export class EditDietComponent implements OnInit{

  submitted=false;



  filteredDietMeals:MealDietMentorList[]=[];

  dietMeals:MealDietMentorList[]=[
    {idMeal: 0, idMealDiet: 1, dayOfWeek: 1, hourOfMeal: '16:30', name: 'test'}
  ];
 
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
    TotalKcal: 0
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
              console.log("get diet by id"+diet.toString());
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
      //  this.dietMeals=dietMeals;
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


    this.dietService.editDiet(this.diet,this.idDiet).subscribe({
      next:(diet)=>{
        console.log(diet);
        if(responseDiv){
        responseDiv.innerHTML="Edycja diety powiodła się";
        }
      },
      error:(response)=>{
        console.log(response);
        if(responseDiv){
          responseDiv.innerHTML="Podczas edycji wystąpił błąd";
          
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


  
  filterDietDay(day:number){
    this.filteredDietMeals=this.dietMeals.filter(
      dietMeals => dietMeals?.dayOfWeek==day
    )
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
 
   
   deleteDietMeal(idExercise:number) {
     console.log("delete");
     this.mealService.deleteDietMeal(idExercise.toString()).subscribe({
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
