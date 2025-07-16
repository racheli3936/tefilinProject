import { useEffect, useState } from "react";
import { observer } from "mobx-react-lite";
import CityStore from "../stores/cityStore";
import RegionStore from "../stores/regionStore";
import StoreStore from "../stores/storeStore";
import type { Store as StoreType } from "../types/store";
import type { City, Region } from "../types/city&Region";
import {
  Typography,
  TextField,
  Button,
  Grid,
  Box,
  Select,
  MenuItem,
  FormControl,
  InputLabel,
  Alert,
  CircularProgress,
  IconButton,
} from "@mui/material";
import { Store, Close } from "@mui/icons-material";

const AddStore = ({ storeOwnerId, onAdded }: { storeOwnerId: number; onAdded: Function }) => {
  const [selectedCityName, setSelectedCityName] = useState("");
  const [selectedRegionName, setSelectedRegionName] = useState("");

  const [formData, setFormData] = useState<Partial<StoreType>>({
    storeName: "",
    phone: "",
    address: "",
    cityId: 0,
    regionId: 0,
    moreDetails: "",
    standPlace: "",
    status: false,
    permitRoles: false,
    storeOwnerId,
    latitude: 0,
    longitude: 0,
  });

  const [notification, setNotification] = useState<{
    show: boolean;
    message: string;
    type: "success" | "error";
  }>({
    show: false,
    message: "",
    type: "success",
  });

  const [loading, setLoading] = useState(false);

  useEffect(() => {
    if (CityStore.cities.length === 0) {
      CityStore.GetAllCities();
    }
    if (RegionStore.regions.length === 0) {
      RegionStore.fetchRegions();
    }
  }, []);

  const handleChange = (field: keyof StoreType, value: any) => {
    setFormData((prev) => ({ ...prev, [field]: value }));
  };

  const showNotification = (message: string, type: "success" | "error") => {
    setNotification({ show: true, message, type });
    setTimeout(() => {
      setNotification({ show: false, message: "", type: "success" });
    }, 3000);
  };

  const isValid = () => {
    return (
      formData.storeName &&
      formData.phone &&
      formData.address &&
      formData.cityId &&
      formData.regionId &&
      formData.standPlace
    );
  };

  const handleSubmit = async () => {
    setLoading(true);
    try {
      await StoreStore.AddStore(formData);
      showNotification("החנות נוספה בהצלחה!", "success");

      onAdded?.();
      setFormData({
        storeName: "",
        phone: "",
        address: "",
        cityId: undefined,
        regionId: undefined,
        moreDetails: "",
        standPlace: "",
        status: false,
        permitRoles: false,
        storeOwnerId,
      });
    } catch (e) {
      showNotification("שגיאה בהוספת חנות", "error");
    } finally {
      setLoading(false);
    }
  };

  return (
    <Box sx={{ p: 2 }}>
      <Box sx={{ display: "flex", alignItems: "center", justifyContent: "space-between", mb: 3 }}>
        <Box display="flex" alignItems="center" gap={1}>
          <Store color="primary" />
          <Typography variant="h6" fontWeight="bold">
            הוספת חנות חדשה
          </Typography>
        </Box>
      </Box>

      <Grid container spacing={2}>
        <Grid size={{xs:12,md:6}}>
          <TextField
            fullWidth
            label="שם החנות *"
            value={formData.storeName || ""}
            onChange={(e) => handleChange("storeName", e.target.value)}
          />
        </Grid>

        <Grid size={{xs:12,md:6}}>
          <TextField
            fullWidth
            label="טלפון *"
            value={formData.phone || ""}
            onChange={(e) => handleChange("phone", e.target.value)}
          />
        </Grid>

        <Grid size={{xs:12}}>
          <TextField
            fullWidth
            label="כתובת *"
            value={formData.address || ""}
            onChange={(e) => handleChange("address", e.target.value)}
          />
        </Grid>

        <Grid size={{xs:12,md:6}}>
          <FormControl fullWidth>
            <InputLabel>בחר עיר *</InputLabel>
            <Select
              value={formData.cityId || ""}
              label="בחר עיר *"
              onChange={(e) => {
                const selectedCity = CityStore.cities.find((c) => c.id == Number(e.target.value));
                handleChange("cityId", selectedCity?.id || 0);
                setSelectedCityName(selectedCity?.cityName || "");
              }}
            >
              {CityStore.cities.map((city: City) => (
                <MenuItem key={city.id} value={city.id}>
                  {city.cityName}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
        </Grid>

        <Grid size={{xs:12,md:6}}>
          <FormControl fullWidth>
            <InputLabel>בחר אזור *</InputLabel>
            <Select
              value={formData.regionId || ""}
              label="בחר אזור *"
              onChange={(e) => {
                const selectedRegion = RegionStore.regions.find((r) => r.id == Number(e.target.value));
                handleChange("regionId", selectedRegion?.id || 0);
                setSelectedRegionName(selectedRegion?.name || "");
              }}
            >
              {RegionStore.regions.map((region: Region) => (
                <MenuItem key={region.id} value={region.id}>
                  {region.name}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
        </Grid>

        <Grid size={{xs:12,md:6}}>
          <TextField
            fullWidth
            label="עיר שנבחרה"
            value={selectedCityName}
            InputProps={{ readOnly: true }}
            disabled
          />
        </Grid>

        <Grid size={{xs:12,md:6}}>
          <TextField
            fullWidth
            label="אזור שנבחר"
            value={selectedRegionName}
            InputProps={{ readOnly: true }}
            disabled
          />
        </Grid>

        <Grid size={{xs:12}}>
          <TextField
            fullWidth
            label="מקום הדוכן *"
            value={formData.standPlace || ""}
            onChange={(e) => handleChange("standPlace", e.target.value)}
          />
        </Grid>

        <Grid size={{xs:12}}>
          <TextField
            fullWidth
            label="פרטים נוספים"
            multiline
            rows={3}
            value={formData.moreDetails || ""}
            onChange={(e) => handleChange("moreDetails", e.target.value)}
          />
        </Grid>
      </Grid>

      <Box sx={{ display: "flex", justifyContent: "flex-end", mt: 3 }}>
        <Button
          variant="contained"
          disabled={!isValid() || loading}
          onClick={handleSubmit}
          startIcon={loading ? <CircularProgress size={20} /> : null}
          sx={{ minWidth: 120 }}
        >
          {loading ? "שומר..." : "שמור חנות"}
        </Button>
      </Box>

      {notification.show && (
        <Alert severity={notification.type} sx={{ mt: 2 }}>
          {notification.message}
        </Alert>
      )}
    </Box>
  );
};

export default observer(AddStore);
