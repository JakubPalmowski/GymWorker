export interface PupilPersonalInfo{
    name: string;
    lastName: string;
    role: string;
    email: string;
    weight?: number;
    height?: number;
    dateOfBirth?: Date;
    sex?: string|null;
    bio?: string;
}