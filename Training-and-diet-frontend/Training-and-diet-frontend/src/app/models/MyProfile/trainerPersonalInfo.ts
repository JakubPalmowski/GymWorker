import { Gym } from "../gym";

export interface TrainerPersonalInfo {
    name: string;
    lastName: string;
    role: string;
    email: string;
    emailValidated: boolean;
    phoneNumber?: string;
    bio?: string;
    trainingPlanPriceFrom?: number;
    trainingPlanPriceTo?: number;
    personalTrainingPriceFrom?: number;
    personalTrainingPriceTo?: number;
    trainerGyms : Gym[];
}
