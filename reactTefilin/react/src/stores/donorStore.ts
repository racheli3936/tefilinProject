import {makeAutoObservable} from "mobx"
import axios from "axios"
import type { Donor } from "../types/donor"


class DonorStore{

    donors:Donor[]=[]
    constructor()
    {
        makeAutoObservable(this)
    }
    async GetAllDonors()
    {
        const token=localStorage.getItem('userToken')

         try{
            const response=await axios.get('https://localhost:7179/api/Donor',
                {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            }
            )
            this.donors=response.data
            console.log(response.data,":\nget all donors");
            console.log(this.donors,":\nget all donors in store");
            
            
        }
        catch(e:any)
        {
            console.log(e,":\nerror get donord");
        }
    }
}
export default new DonorStore
