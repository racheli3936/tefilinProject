import type { StatusCall } from "./statusCall";
import type { ToDoVisit } from "./toDoVisit";

export type StoreOwnerConversation={
  id :number,
  storeOwnerId :number,
  storeStandId: number;
  userId: number;
  conversionDate: Date;
  statusCall: StatusCall;
  notes: string;
  toDoVisits: ToDoVisit[];
  image: string;
}