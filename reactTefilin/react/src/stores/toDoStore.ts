import axios from "axios";
import { makeAutoObservable } from "mobx";
import type { ToDo } from "../types/todo";

class ToDoStore {
    toDos: ToDo[] = []
    constructor() {
        makeAutoObservable(this)
    }
    async getAllToDo() {
        try {
            const res = await axios.get('https://localhost:7179/api/ToDo')
            this.toDos = res.data
            console.log(res.data);


        }
        catch (e: any) {
            console.log(e);

        }
    }
}
export default new ToDoStore()