import { useEffect } from "react";
import storeOwnerStore from "../stores/storeOwnerStore";
import { observer } from "mobx-react-lite";

const StoreOwner =
    observer(
    () => {

    useEffect(() => {
        storeOwnerStore.GetAllStoreOwners();
    }, []);
        return (
            <div>
                <h2>Store Owner</h2>
                {storeOwnerStore.storeOwners.map(storeOwner => (
                    <>
                      <div key={storeOwner.id}>
                        <h3>{storeOwner.name}</h3>
                        <div>{storeOwner.address}</div>
                        <div>{storeOwner.email}</div>
                        <div>{storeOwner.phone}</div>
                        </div>
                    </>
                )
                )}
            </div>
        );
    }
);
export default StoreOwner;