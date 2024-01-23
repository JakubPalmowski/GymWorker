export interface DieticianPersonalInfo{
    name: string;
    lastName: string;
    role: string;
    email: string;
    emailValidated: boolean;
    phoneNumber?: string;
    bio?: string;
    dietPriceFrom?: number;
    dietPriceTo?: number;
}