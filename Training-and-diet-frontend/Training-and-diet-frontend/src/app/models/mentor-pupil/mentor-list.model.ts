import { Mentor } from "./mentor.model";

export interface MentorList{
    items: Mentor[];
  totalPages: number;
  itemsFrom: number;
  itemsTo: number;
  totalItemsCount: number;
}