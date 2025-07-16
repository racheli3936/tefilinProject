import { type StoreStand } from "./storeStand"
export type Store = {
    id: number,
    storeOwnerId: number,
    storeName: string,
    phone: string,
    address: string,
    longitude:number,
    latitude:number,
    cityId: number,
    regionId: number,
    moreDetails: string,
    standPlace: string,
    status: boolean,
    permitRoles: boolean,
    storeStand: StoreStand[]
}