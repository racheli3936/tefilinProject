export type ToDoVisit = {
    Id: number;
    ToDoId: number;
    VisitId: number; //אם זה תוצאה של ביקור
    StoreOwnerConversationId: number; //אם זה תוצאה של שיחה 
    Description: string;
    Source: string; //אם צריך העברה של הסטנד או שצריך להביר חלקים ממנו  וכו
    Destination: string;
};