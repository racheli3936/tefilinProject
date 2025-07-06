import type { City, Region } from "./city&Region"
import { type StoreStand } from "./storeStand"
export type Store = {
    id: number,
    storeOwnerId: number,
    storeName: string,
    phone: string,
    address: string,
    city: City,
    region: Region,
    moreDetails: string,
    standPlace: string,
    status: boolean,
    permitRoles: boolean,
    storeStand: StoreStand[]
}