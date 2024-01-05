export interface EditTrainingPlan{
    idTrainingPlan:number;
    name: string;
    customName:string;
    type:string;
    startDate:Date;
    endDate:Date;
    planDuration:number;
    numberOfWeeks:number;
}