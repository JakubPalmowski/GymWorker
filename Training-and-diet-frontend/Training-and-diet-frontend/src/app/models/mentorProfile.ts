import { Opinion } from "./opinion";

export interface MentorProfile{
    id: number;
    name: string;
    lastName: string;
    role: string;
    street: string;
    city: string;
    phoneNumber: string;
    bio: string;
    opinion_number: number;
    totalRate: number;
    opinions: Opinion[];
}