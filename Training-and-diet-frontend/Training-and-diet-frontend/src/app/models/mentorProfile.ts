import { Gym } from "./gym";
import { Opinion } from "./opinion";

export interface MentorProfile{
    id: number;
    name: string;
    lastName: string;
    role: string;
    phoneNumber: string;
    email: string;
    bio: string;
    opinion_number: number;
    totalRate: number;
    training_plan_price_from?: number;
    training_plan_price_to?: number;
    personal_training_price_from?: number;
    personal_training_price_to?: number;
    diet_price_from?: number;
    diet_price_to?: number;
    opinions: Opinion[];
    trainerGyms: Gym[]
}