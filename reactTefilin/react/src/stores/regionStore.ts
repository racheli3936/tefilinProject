import { makeAutoObservable } from "mobx";
import axios from "axios";
import type { Region } from "../types/city&Region";

class RegionStore {
    regions: Region[] = [];
    loading = false;
    error: unknown | null = null;
    url="https://localhost:7179/api/Region";
    constructor() {
        makeAutoObservable(this);
    }

    async fetchRegions() {
        this.loading = true;
        this.error = null;
        try {
            const response = await axios.get(this.url);
            this.regions = response.data;
        } catch (error) {
            this.error = error;
        } finally {
            this.loading = false;
        }
    }

    async addRegion(region:Region) {
        this.loading = true;
        this.error = null;
        try {
            const response = await axios.post("/api/region", region);
            this.regions.push(response.data);
        } catch (error) {
            this.error = error;
        } finally {
            this.loading = false;
        }
    }
}

export default  new RegionStore();

