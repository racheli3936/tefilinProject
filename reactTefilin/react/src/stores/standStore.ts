import axios from "axios";
import { makeAutoObservable } from "mobx";

class StandStore {
    baseUrl = "https://localhost:7179/api/";
    token = localStorage.getItem("userToken");
    constructor() {
        makeAutoObservable(this)
    }
    async getStandsByOwnerId(ownerId: number) {
        try {
            const response = await axios.get(`${this.baseUrl}Stand/by-store-owner/${ownerId}`, {
                headers: {
                    'Authorization': `Bearer ${this.token}`
                }
            })
            console.log(response.data, ": response data conversations by storeOwnerId");
            console.log(typeof response.data, ": type of response data conversations by storeOwnerId");
            return response.data
        }
        catch (error: any) {
            console.error("Error fetching stand by owner id:", error);
        }
    }
}
export default new StandStore();