import { Gym } from "../gym";

export interface UserPersonalInfo{
    name: string;
    lastName: string;
    role: string;
    email: string;
    emailValidated: boolean;
    phoneNumber?: string;
    bio?: string;
    weight?: number;
    height?: number;
    dateOfBirth?: Date;
    sex?: string;
    trainingPlanPriceFrom?: number;
    trainingPlanPriceTo?: number;
    personalTrainingPriceFrom?: number;
    personalTrainingPriceTo?: number;
    trainerGyms: Gym[];
}