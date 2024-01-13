export interface FullTrainingPlanGet{
    idTrainingPlan:number;
    idTrainer:number;
    idPupil:number;
    name: string;
    customName:string;
    type:string;
    startDate:Date;
    numberOfWeeks:number;
}