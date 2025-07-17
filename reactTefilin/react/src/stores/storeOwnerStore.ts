import {makeAutoObservable} from "mobx"
import type { storeOwner } from "../types/storeOwner"
import axios from "axios"

class StoreOwnerStore
{
    storeOwners:storeOwner[]=[]
    constructor(){
        makeAutoObservable(this)

    }
    async GetAllStoreOwners()
    {
        const token=localStorage.getItem('userToken')

        try{
            const response=await axios.get('https://localhost:7179/api/StoreOwner',{
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            })
            this.storeOwners=response.data
            console.log(response.data);
            console.log(this.storeOwners,"listt");
            
            
        }
        catch(e:any)
        {
            console.log(e,"error get storeOwners");
            
        }
    }
    async AddStoreOwner(storeOwner:Partial<storeOwner>)
    {
        const token=localStorage.getItem('userToken')
         try{
            const response=await axios.post('https://localhost:7179/api/StoreOwner',storeOwner,
                 {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            }
            )
            this.storeOwners.push(response.data)
        }
        catch(e:any)
        {
            console.log(e,"error add storeOwner");
            
        }
    }
    async DeleteStoreOwner(id:number)
    {
        // const token=localStorage.getItem('userToken')
        // try{
        //     await axios.delete(`https://localhost:7179/api/StoreOwner/${id}`,{
        //         headers: {
        //             'Authorization': `Bearer ${token}`
        //         }
        //     })
        //     this.storeOwners = this.storeOwners.filter(storeOwner => storeOwner.id !== id);
        //     console.log("Store owner deleted successfully");
        // }
        // catch(e:any)
        // {
        //     console.log(e,"error delete storeOwner");
            
        // }
    }

}
export default new StoreOwnerStore
