import { makeAutoObservable } from "mobx";
import type { Store } from "../types/store";
import axios from "axios";

// Define the StorePostModel interface to match your backend

class StoreStore {
    stores: Store[] = [];
    
    constructor() {
        makeAutoObservable(this);
    }

    // GET - Get all stores
    async GetAllStores() {
        const token = localStorage.getItem('userToken');
        
        try {
            const response = await axios.get('https://localhost:7179/api/Store', {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            });
            this.stores = response.data;
            console.log(response.data);
            console.log(this.stores, "stores list");
        } catch (e: any) {
            console.log(e, "error get stores");
        }
    }

    // GET - Get store by ID
    async GetStoreById(id: number) {
        const token = localStorage.getItem('userToken');
        
        try {
            const response = await axios.get(`https://localhost:7179/api/Store/${id}`, {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            });
            return response.data;
        } catch (e: any) {
            console.log(e, `error get store with id: ${id}`);
            return null;
        }
    }

    // POST - Add new store (updated to match controller)
    async AddStore(storeData: Partial<Store>) {
        console.log(storeData, "store data to add");
        
        const token = localStorage.getItem('userToken');
        
        try {
            const response = await axios.post('https://localhost:7179/api/Store', storeData, {
                headers: {
                    'Authorization': `Bearer ${token}`,
                    'Content-Type': 'application/json'
                }
            });
            
            // Add the returned store to the local array
            this.stores.push(response.data);
            console.log("Store added successfully:", response.data);
            return response.data;
        } catch (e: any) {
            console.log(e, "error add store");
            throw e;
        }
    }

    // PUT - Update existing store
    async UpdateStore(id: number, store: Partial<Store>) {
        const token = localStorage.getItem('userToken');
        
        try {
            const response = await axios.put(`https://localhost:7179/api/Store/${id}`, store, {
                headers: {
                    'Authorization': `Bearer ${token}`,
                    'Content-Type': 'application/json'
                }
            });
            
            // Update the store in the local array
            const index = this.stores.findIndex(s => s.id === id);
            if (index !== -1) {
                this.stores[index] = response.data;
            }
            
            console.log("Store updated successfully:", response.data);
            return response.data;
        } catch (e: any) {
            console.log(e, `error update store with id: ${id}`);
            throw e;
        }
    }

    // DELETE - Delete store
    async DeleteStore(id: number) {
        const token = localStorage.getItem('userToken');
        
        try {
            await axios.delete(`https://localhost:7179/api/Store/${id}`, {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            });
            
            // Remove the store from the local array
            this.stores = this.stores.filter(store => store.id !== id);
            console.log(`Store with id ${id} deleted successfully`);
        } catch (e: any) {
            console.log(e, `error delete store with id: ${id}`);
            throw e;
        }
    }

    async GetStoresByOwnerId(ownerId: number) {
        const token = localStorage.getItem('userToken');
        
        try {
            const response = await axios.get(`https://localhost:7179/api/Store/owner/${ownerId}`, {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            });
            return response.data;
        } catch (e: any) {
            console.log(e, `error get stores for owner: ${ownerId}`);
            return [];
        }
    }

    // Helper method to toggle store status
    async ToggleStoreStatus(id: number) {
        const store = this.stores.find(s => s.id === id);
        if (store) {
            await this.UpdateStore(id, { status: !store.status });
        }
    }

    // Helper method to toggle permit roles
    async TogglePermitRoles(id: number) {
        const store = this.stores.find(s => s.id === id);
        if (store) {
            await this.UpdateStore(id, { permitRoles: !store.permitRoles });
        }
    }


}

export default new StoreStore();