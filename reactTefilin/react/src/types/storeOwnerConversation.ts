import type { StatusCall } from "./statusCall";
import type { ToDoVisit } from "./toDoVisit";

export type StoreOwnerConversation={
  id :number,
  storeOwnerId :number,
  storeStandId: number;
  userId: number;
  conversationDate: Date;
  statusCallId: number;
  statusCall: StatusCall; // Optional, if you want to include the status call details
  notes: string;
  toDoVisits: ToDoVisit[];
  image: string;
}