import type { Store } from "./store"

export type storeOwner = {
    id: number,
    name: string,
    address: string,
    phone: string
    email: string,
    stores: Store[]
}