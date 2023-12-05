import { Address } from "./address";

export interface Trainer{
    id: number;
    role: string;
    name: string;
    lastName: string;
    address: Address;
    phoneNumber: string;
    photoUrl: string;
}