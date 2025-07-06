import {makeAutoObservable} from "mobx"
import type { City } from "../types/city&Region"
import axios from "axios"
class CityStore{

    cities:City[]=[]
    constructor()
    {
        makeAutoObservable(this)
    }
    async GetAllCities()
    {
                const token=localStorage.getItem('userToken')

         try{
            const response=await axios.get('https://localhost:7179/api/City',
                {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            }
            )
            this.cities.push(response.data)
        }
        catch(e:any)
        {
            console.log(e,":\nerror add city");
            
        }
        
    }
    async AddNewCity(cityName:string)
    {
        const token=localStorage.getItem('userToken')

         try{
            const response=await axios.post('https://localhost:7179/api/City',{cityName},
                {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            }
            )
            this.cities.push(response.data)
        }
        catch(e:any)
        {
            console.log(e,":\nerror add city");
            
        }
    }
}
export default new CityStore
