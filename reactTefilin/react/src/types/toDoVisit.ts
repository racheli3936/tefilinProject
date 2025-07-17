export type ToDoVisit = {
    id: number;
    toDoId: number;
    visitId: number; //אם זה תוצאה של ביקור
    storeOwnerConversationId: number; //אם זה תוצאה של שיחה 
    description: string;
    source: string; //אם צריך העברה של הסטנד או שצריך להביר חלקים ממנו  וכו
    destination: string;
};