import { ActiveGym } from "../gym/active-gym.model";
import { Opinion } from "./opinion.model";

export interface MentorProfile{
    id: number;
    name: string;
    lastName: string;
    role: string;
    phoneNumber: string;
    email: string;
    bio: string;
    opinionNumber: number;
    totalRate: number;
    trainingPlanPriceFrom?: number;
    trainingPlanPriceTo?: number;
    personalTrainingPriceFrom?: number;
    personalTrainingPriceTo?: number;
    dietPriceFrom?: number;
    dietPriceTo?: number;
    opinions: Opinion[];
    trainerGyms: ActiveGym[]
    imageUri?: string;
    cooperation?: boolean;
    isOpinionExists?: boolean;
}