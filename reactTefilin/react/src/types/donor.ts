import type { City } from "./city&Region"

export type Donor = {
    id: number, 
    name: string,
    phone: string,
    email: string,
    address: string,
    city: City
}