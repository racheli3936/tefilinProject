import { makeAutoObservable } from "mobx";
import axios from "axios";
import type { User } from "../types/user";

class UserStore {
    token = localStorage.getItem("token");
    
    baseUrl = "https://localhost:7179/api/";
    users:User[] = [];
    currentUser = null;

    constructor() {
        makeAutoObservable(this);
    }

    // פונקציה לקבל את כל המשתמשים
    async getAllUsers() {
        try {
            const response = await axios.get(`${this.baseUrl}User`, {
                headers: {
                    'Authorization': `Bearer ${this.token}`
                }
            });
            this.users = response.data;
            console.log(response.data,"response.data");
            
            console.log("Users fetched successfully:", this.users);
        } catch (error) {
            console.error("Error fetching users:", error);
        }
    }

    // פונקציה לקבל משתמש לפי מזהה
    async getUserById(id:number) {
        try {
            const response = await axios.get(`${this.baseUrl}users/${id}`, {
                headers: {
                    'Authorization': `Bearer ${this.token}`
                }
            });
            this.currentUser = response.data;
            console.log("User fetched successfully:", this.currentUser);
            return response.data;
        } catch (error) {
            console.error("Error fetching user:", error);
        }
    }

    // פונקציה להוסיף משתמש חדש
    async addUser(userData:Partial<User>) {
        try {
            const response = await axios.post(`${this.baseUrl}users`, userData, {
                headers: {
                    'Authorization': `Bearer ${this.token}`,
                    'Content-Type': 'application/json'
                }
            });
            this.users.push(response.data); // מוסיף את המשתמש החדש לרשימה המקומית
            console.log("User added successfully:", response.data);
            return response.data; // מחזיר את המשתמש שנוסף
        } catch (error) {
            console.error("Error adding user:", error);
        }
    }

    // פונקציה לעדכן משתמש קיים
    async updateUser(id:number, userData:Partial<User>) {
        try {
            const response = await axios.put(`${this.baseUrl}users/${id}`, userData, {
                headers: {
                    'Authorization': `Bearer ${this.token}`,
                    'Content-Type': 'application/json'
                }
            });
            // עדכון המשתמש ברשימה המקומית
            this.users = this.users.map(user => (user.id === id ? response.data : user));
            console.log("User updated successfully:", response.data);
            return response.data; // מחזיר את המשתמש המעודכן
        } catch (error) {
            console.error("Error updating user:", error);
        }
    }
}

export default new UserStore();
