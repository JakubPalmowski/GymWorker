export interface PupilPersonalInfo{
    name: string;
    lastName: string;
    role: string;
    email: string;
    emailValidated: boolean;
    weight?: number;
    height?: number;
    dateOfBirth?: Date;
    sex?: string|null;
    bio?: string;
    imageUri?: string;
}