import { Time } from "@angular/common";

export interface TrainingPlan{
    idTrainingPlan: number;
    name: string;
    customName:string;
    startDate:Date;
    numberOfWeeks:number ;
    endDate:Date;
    
}