import { makeAutoObservable } from "mobx";
import type { ToDoVisit } from "../types/toDoVisit";
import { common } from "@mui/material/colors";
import axios from "axios";

class TodoVisitStore{
    token = localStorage.getItem("userToken");
    baseUrl = "https://localhost:7179/api/";
    constructor() {
        makeAutoObservable(this);
    }
    async addTodoVisitList(todoVisitList:Partial<ToDoVisit>[]) {
        try{
const response =await axios.post(`${this.baseUrl}ToDoVisit/list`, todoVisitList,{
                headers: {
                    'Authorization': `Bearer ${this.token}`
                }
            })
            console.log(response.data, "response data todo visit");
        }
        catch(error) {
            console.error("Error adding todo visit:", error);   
        }

    }
}
export default new TodoVisitStore();