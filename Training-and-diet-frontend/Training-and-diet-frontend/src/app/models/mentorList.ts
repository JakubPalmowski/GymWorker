import { Mentor } from "./mentor";

export interface MentorList{
    items: Mentor[];
  totalPages: number;
  itemsFrom: number;
  itemsTo: number;
  totalItemsCount: number;
}