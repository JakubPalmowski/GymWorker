export interface FullTrainingPlanGet{
    idTrainingPlan:number;
    idTrainer:number;
    idPupil:number;
    name: string;
    customName:string;
    type:string;
    startDate:Date;
    endDate:Date;   
    numberOfWeeks:number;
    pupilName:string;
    pupilLastName:string;
}