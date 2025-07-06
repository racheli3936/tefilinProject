import { useEffect, useState } from "react";
import storeOwnerStore from "../stores/storeOwnerStore";
import type { storeOwner } from "../types/storeOwner";
import { observer } from "../../node_modules/mobx-react-lite"
const StoreOwner =
    observer(
    () => {
        const [storeOwners,setStoreOwners]=useState<storeOwner[]>([])
        useEffect(() => {
            const fetchStoreOwners = async () => {

                try {
                    await storeOwnerStore.GetAllStoreOwners()
                } catch (error: any) {
                    console.error("Error fetching storeOwners:", error.response ? error.response.data : error.message);
                }
            };
            fetchStoreOwners();
            setStoreOwners(storeOwnerStore.storeOwners);
        }) 


        return (
            <div>
                <h2>Store Owner</h2>
                {storeOwners.map(storeOwner => (
                    <>
                        <h3>{storeOwner.name}</h3>
                        <div>{storeOwner.address}</div>
                    </>
                )
                )}
            </div>
        );
    }
);
export default StoreOwner;