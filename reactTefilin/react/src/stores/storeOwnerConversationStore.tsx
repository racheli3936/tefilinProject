import { makeAutoObservable } from "mobx";
import type { StoreOwnerConversation } from "../types/storeOwnerConversation";
import axios from "axios";

class StoreOwnerConversationsStore {
    token = localStorage.getItem("userToken");
    baseUrl = "https://localhost:7179/api/";
    conversations: StoreOwnerConversation[] = [];
    conversationsByStoreOwnerId: StoreOwnerConversation[] = []

    constructor() {
        makeAutoObservable(this);
    }

    // פונקציה לקבל את כל השיחות
    async getAllConversations() {
        try {

            const response = await axios.get(`${this.baseUrl}StoreOwnerConversation`, {
                headers: {
                    'Authorization': `Bearer ${this.token}`
                }
            });
            this.conversations = response.data;
            console.log("response data conversations:", response.data);
            console.log("Conversations fetched successfully:", this.conversations);
        }
        catch (error) {
            console.error("Error fetching conversations:", error);
        }
    }

    //  פונקציה לקבל שיחה לפי מזהה
    async getConversationById(id: number) {
        try {

            const response = await axios.get(`${this.baseUrl}StoreOwnerConversation/${id}`, {
                headers: {
                    'Authorization': `Bearer ${this.token}`
                }
            });
            // this.conversations = response.data;
            console.log("response data conversations:", response.data);
            console.log("Conversations fetched successfully:", this.conversations);
            return response.data
        }
        catch (error) {
            console.error("Error fetching conversations:", error);
        }
    }
    //לקבל את כל השיחות על פי מזהה של בעל העסק
    async getConversationsByStoreOwnerId(storeOwnerId: number) {
        try {
            const response = await axios.get(`${this.baseUrl}StoreOwnerConversation/id/${storeOwnerId}`, {
                headers: {
                    'Authorization': `Bearer ${this.token}`
                }
            })
            console.log(response.data, ": response data conversations by storeOwnerId");
            console.log(typeof response.data, ": type of response data conversations by storeOwnerId");

            this.conversationsByStoreOwnerId = response.data
            //console.log(this.conversationsByStoreOwnerId);



        }
        catch (error: any) {
            console.log(error, ": error get conversations by storeOwnerId");

        }
    }
    async addConversation(conversationData:Partial<StoreOwnerConversation>) {
        try {
            const response = await axios.post(`${this.baseUrl}StoreOwnerConversation`, conversationData, {
                headers: {
                    'Authorization': `Bearer ${this.token}`,
                    'Content-Type': 'application/json'
                }
            });
            console.log("Conversation added successfully:", response.data);
            
            this.conversations.push(response.data);
            return response.data;
            
        } catch (error) {
            console.error("Error adding conversation:", error);
        }
    }

}
export default new StoreOwnerConversationsStore();

