import { makeAutoObservable } from "mobx"
import type { StatusCall } from "../types/statusCall"
import axios from "axios"

class StatusCallStore {
    statusesCall: StatusCall[] = []
    baseUrl = "https://localhost:7179/api/";
    token = localStorage.getItem("userToken");
    constructor() {
        makeAutoObservable(this)
    }
    async getAllStatusesCall() {
        try {
            const res =await axios.get('https://localhost:7179/api/StatusCall', {
                headers: {
                    'Authorization': `Bearer ${this.token}`
                }
            })
            this.statusesCall=res.data
            console.log(res.data,"res.data status-call");
            console.log(this.statusesCall,'this.status-calls');
            
            
        }
        catch (error: any) {
            console.log(error,' error get atatuses call');
            

        }
    }
}
export default new StatusCallStore()