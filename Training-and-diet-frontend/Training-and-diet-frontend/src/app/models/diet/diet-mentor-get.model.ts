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
    TotalKcal:number;
    //na podstawie id Pupil z tabelki users
    pupilName:string;
    pupilLastName:string;
}