import { ActiveGym } from "../gym/activeGym";

export interface TrainerPersonalInfo {
    name: string;
    lastName: string;
    role: string;
    email: string;
    phoneNumber?: string;
    bio?: string;
    trainingPlanPriceFrom?: number;
    trainingPlanPriceTo?: number;
    personalTrainingPriceFrom?: number;
    personalTrainingPriceTo?: number;
    trainerGyms : ActiveGym[];
}
