export interface Mentor{
    id_user: number;
    bio: string;
    last_name: string;
    name: string;
    phone_number: string;
    city: string;
    opinion_number: number;
    rate: number;
    role_name: string;
    training_plan_price_from?: number;
    training_plan_price_to?: number;
    personal_training_price_from?: number;
    personal_training_price_to?: number;
    diet_price_from?: number;
    diet_price_to?: number;
}