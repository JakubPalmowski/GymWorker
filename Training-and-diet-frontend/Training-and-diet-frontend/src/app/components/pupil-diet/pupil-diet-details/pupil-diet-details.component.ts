import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FullPupilDietGet } from 'src/app/models/diet/full-pupil-diet-get.model';
import { MealDietList } from 'src/app/models/diet/meal-diet-list.model';
import { DietService } from 'src/app/services/diet.service';

@Component({
  selector: 'app-pupil-diet-details',
  templateUrl: './pupil-diet-details.component.html',
  styleUrls: ['./pupil-diet-details.component.css']
})
export class PupilDietDetailsComponent {


  filteredDietMeals:MealDietList[]=[];
  dietMeals:MealDietList[]=[];
 
  diet:FullPupilDietGet={
    idDiet: 0,
    idDietician: 0,
    name: '',
    type: '',
    endDate: new Date(),
    dieticianName: '',
    dieticianLastName: '',
    totalKcal: 0,
  }

  formStartDate:string='';
  formEndDate:string='';

  dateInput:Date=new Date();
  dateInputString:string='';
  idDiet:string='';

  constructor(private route:ActivatedRoute, private dietService:DietService){}

  ngOnInit(): void {
    this.dateInputString=new Date().toISOString().split("T")[0];


    this.route.paramMap.subscribe({
      next:(params)=>{
        const id=params.get('id');

        // do wrzucenie w get cwiczen
        this.changeTrainingDay(1,'pn');
        
        if(id){
          console.log(id);
          this.idDiet=id;
          this.dietService.getPupilDietById(this.idDiet).subscribe({
            next:(diet)=>{
              this.diet=diet;
            //  this.formStartDate=new Date(this.trainingPlan.startDate).toLocaleDateString();
            this.formEndDate=diet.endDate.toString().split("T")[0];
              this.defaultType();
            },
            error: (response)=>{
             console.log(response);
            }
          })
          this.dietService.getDietMealsByDietId(id).subscribe({
            next:(dietMeals)=>{
              this.dietMeals=dietMeals;
              //this.changeTrainingDay(1,"pn");
              this.changeTrainingDayByCalendar();

            },
            error: (response)=>{
              this.changeTrainingDayByCalendar();
            }
          })
        }
        else{
          console.log("no");
        }
      }
    })
    
  }

  changeTrainingDayByCalendar(){
    console.log(this.dateInputString);
    var date=new Date(this.dateInputString);
    var dayOfWeek=date.getDay() == 0? 7 : date.getDay();
    console.log("day:"+dayOfWeek);
    switch(dayOfWeek){
      case 1:
        this.changeTrainingDay(1,'pn');
        break;
      case 2:
        this.changeTrainingDay(2,'wt');
        break;
      case 3:
        this.changeTrainingDay(3,'sr');
        break;
      case 4:
        this.changeTrainingDay(4,'czw');
        break;
      case 5:
        this.changeTrainingDay(5,'pt');
        break;
      case 6:
        this.changeTrainingDay(6,'sob');
        break;
      case 7:
        this.changeTrainingDay(7,'nd');
        break;  
        }
        
  }


  defaultType(){
    if(this.diet.type==""){
    this.diet.type="brak typu";
    }
  }

  filterTrainingDay(day:number){
    this.filteredDietMeals=this.dietMeals.filter(
      dietMeals => dietMeals?.dayOfWeek==day
    )
    this.filteredDietMeals.sort((a,b)=>a.hourOfMeal.localeCompare(b.hourOfMeal));
  }

  changeTrainingDay(day: number, val: string) {
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

    this.filterTrainingDay(day);
}
}
