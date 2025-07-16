import type { StoreStand } from "./storeStand";
import type { TefilinStatus } from "./tefilinStatus";

export type Stand = {
    id: number;
    standId: number;
    status: boolean;
    notes: string;
    countTefilin: number;
    isThereLeftHanded: boolean;
    lastCheckDate: string; // or Date if you want JS Date object
    tefilinStatus: TefilinStatus;
    // visits: Visit[];
    // standItems: StandItem[];
    // Ddonations: Donation[];
     storeStands: StoreStand[];
};

// Make sure to import or define the types below in this file or elsewhere:
// TefilinStatus, Visit, StandItem, Donation, StoreStand