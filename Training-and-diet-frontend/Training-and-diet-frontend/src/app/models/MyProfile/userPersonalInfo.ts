import { Certificate } from "../certificate/certificate";
import { ActiveGym } from "../gym/activeGym";

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
    dietPriceFrom?: number;
    dietPriceTo?: number;
    trainerGyms: ActiveGym[];
    certificates: Certificate[];
    imageUri?: string;
}