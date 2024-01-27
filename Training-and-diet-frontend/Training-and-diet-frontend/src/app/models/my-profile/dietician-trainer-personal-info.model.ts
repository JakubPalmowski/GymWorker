import { ActiveGym } from "../gym/active-gym.model";

export interface DieticianTrainerPersonalInfo {
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
    dietPriceFrom?: number;
    dietPriceTo?: number;
    trainerGyms : ActiveGym[];
}
