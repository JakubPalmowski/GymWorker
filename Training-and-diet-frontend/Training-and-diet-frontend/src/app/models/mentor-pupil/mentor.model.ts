export interface Mentor{
    idUser: number;
    bio: string;
    lastName: string;
    name: string;
    phoneNumber: string;
    city: string;
    opinionNumber: number;
    rate: number;
    roleName: string;
    trainingPlanPriceFrom?: number;
    trainingPlanPriceTo?: number;
    personalTrainingPriceFrom?: number;
    personalTrainingPriceTo?: number;
    dietPriceFrom?: number;
    dietPriceTo?: number;
    imageUri?: string;
    imageSrc?: string;
}