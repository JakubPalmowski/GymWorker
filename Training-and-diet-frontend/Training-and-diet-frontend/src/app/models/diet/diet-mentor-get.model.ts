export interface DietMentorGet{
    idDiet:number;
    idDietician:number;
    idPupil:number;
    name:string;
    customName:string;
    type:string;
    startDate:Date;
    endDate:Date;
    numberOfWeeks:number;
    totalKcal:number;
    pupilName:string;
    pupilLastName:string;
}