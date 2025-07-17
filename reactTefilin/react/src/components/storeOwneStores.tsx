// import { useEffect, useState } from "react";
// import { observer } from "mobx-react-lite";
// import {
//   Box,
//   Button,
//   Typography,
//   CircularProgress,
//   Grid,
//   Paper,
//   Chip,
//   Divider,
//   Container,
//   Card,
//   CardContent,
//   Modal,
// } from "@mui/material";
// import storeStore from "../stores/storeStore";
// import type { storeOwner } from "../types/storeOwner";
// import type { Store } from "../types/store";
// import AddStore from "./addStore";

// interface StoreOwnerStoresProps {
//   storeOwner: storeOwner;
//   onClose: () => void;
// }

// const StoreOwnerStores = observer(({ storeOwner, onClose }: StoreOwnerStoresProps) => {
//   const [stores, setStores] = useState<Store[]>([]);
//   const [loading, setLoading] = useState(false);
//   const [showAddForm, setShowAddForm] = useState(false);

//   useEffect(() => {
//     fetchOwnerStores();
//   }, [storeOwner]);

//   const fetchOwnerStores = async () => {
//     setLoading(true);
//     try {
//       const ownerStores = await storeStore.GetStoresByOwnerId(storeOwner.id);
//       setStores(ownerStores);
//     } catch (error) {
//       console.error("Error fetching owner stores:", error);
//     } finally {
//       setLoading(false);
//     }
//   };

//   const handleStoreAdded = async () => {
//     setShowAddForm(false);
//     await fetchOwnerStores();
//   };

//   return (
//     <Container maxWidth="lg" sx={{ py: 4 }}>
//       <Card sx={{ mb: 3 }}>
//         <CardContent sx={{ display: "flex", justifyContent: "space-between", alignItems: "center" }}>
//           <Box>
//             <Typography variant="h5" fontWeight="bold">
//               החנויות של {storeOwner.name}
//             </Typography>
//             <Typography variant="body2" color="text.secondary">
//               ניהול כל החנויות עבור בעל עסק זה
//             </Typography>
//           </Box>
//           <Box display="flex" gap={2}>
//             <Button variant="contained" onClick={() => setShowAddForm(true)}>
//               ➕ הוסף חנות
//             </Button>
//             <Button variant="outlined" color="error" onClick={onClose}>
//               חזרה
//             </Button>
//           </Box>
//         </CardContent>
//       </Card>

//       <Modal
//         open={showAddForm}
//         onClose={() => setShowAddForm(false)}
//         sx={{ display: 'flex', alignItems: 'center', justifyContent: 'center' }}
//       >
//         <Paper sx={{ maxWidth: 700, width: '95%', maxHeight: '90vh', overflowY: 'auto', p: 3 }}>
//           <AddStore storeOwnerId={storeOwner.id} onAdded={handleStoreAdded} />
//         </Paper>
//       </Modal>

//       {loading ? (
//         <Box textAlign="center" py={4}>
//           <CircularProgress />
//           <Typography color="textSecondary" mt={2}>
//             טוען חנויות...
//           </Typography>
//         </Box>
//       ) : stores.length === 0 ? (
//         <Box textAlign="center" py={4}>
//           <Typography color="textSecondary">אין חנויות עבור בעל עסק זה</Typography>
//         </Box>
//       ) : (
//         <Box display="flex" flexDirection="column" gap={3}>
//           {stores.map((store: Store) => (
//             <Paper key={store.id} elevation={2} sx={{ p: 2 }}>
//               <Grid container spacing={2}>
//                 <Grid size={{xs:12,md:6}}>
//                   <Typography variant="h6">{store.storeName}</Typography>
//                   <Typography variant="body2">כתובת: {store.address}</Typography>
//                   <Typography variant="body2">טלפון: {store.phone}</Typography>
//                   <Typography variant="body2">מקום עמדה: {store.standPlace}</Typography>
//                   {store.cityId && <Typography variant="body2">עיר: {store.cityId}</Typography>}
//                   {store.regionId && <Typography variant="body2">אזור: {store.regionId}</Typography>}
//                 </Grid>
                
//                 <Grid size={{xs:12,md:6}}>
//                   <Box display="flex" flexDirection="column" gap={1}>
//                     <Box display="flex" alignItems="center" gap={1}>
//                       <Typography variant="body2">סטטוס:</Typography>
//                       <Chip
//                         label={store.status ? "פעיל" : "לא פעיל"}
//                         color={store.status ? "success" : "error"}
//                         size="small"
//                       />
//                     </Box>
//                     <Box display="flex" alignItems="center" gap={1}>
//                       <Typography variant="body2">רישיונות:</Typography>
//                       <Chip
//                         label={store.permitRoles ? "מאושר" : "ממתין"}
//                         color={store.permitRoles ? "success" : "warning"}
//                         size="small"
//                       />
//                     </Box>
//                     {store.moreDetails && (
//                       <Box>
//                         <Typography variant="body2">פרטים נוספים:</Typography>
//                         <Typography variant="body2" color="text.secondary">
//                           {store.moreDetails}
//                         </Typography>
//                       </Box>
//                     )}
//                   </Box>
//                 </Grid>
//               </Grid>

//               {store.storeStand && store.storeStand.length > 0 && (
//                 <Box mt={2}>
//                   <Divider />
//                   <Typography variant="body2" mt={1}>
//                     עמדות חנות:
//                   </Typography>
//                   <Box display="flex" gap={1} flexWrap="wrap">
//                     {store.storeStand.map((stand, index) => (
//                       <Chip
//                         key={index}
//                         label={stand.StandId || `עמדה ${index + 1}`}
//                         color="info"
//                         size="small"
//                       />
//                     ))}
//                   </Box>
//                 </Box>
//               )}
//             </Paper>
//           ))}
//         </Box>
//       )}
//     </Container>
//   );
// });

// export default StoreOwnerStores;
import { useEffect, useState } from "react";
import { observer } from "mobx-react-lite";
import {
  Box,
  Button,
  Typography,
  CircularProgress,
  Grid,
  Paper,
  Chip,
  Divider,
  Container,
  Card,
  CardContent,
  Modal,
} from "@mui/material";
import storeStore from "../stores/storeStore";
import type { storeOwner } from "../types/storeOwner";
import type { Store } from "../types/store";
import AddStore from "./addStore";
import { useLocation, useNavigate, useParams } from "react-router-dom";

const StoreOwnerStores = observer(( ) => {
  const [stores, setStores] = useState<Store[]>([]);
  const [loading, setLoading] = useState(false);
  const [showAddForm, setShowAddForm] = useState(false);
   const navigate=useNavigate()
 const { id } = useParams(); // קבלת id מה-URL
 const { name } = useParams(); // קבלת id מה-URL

  useEffect(() => {
    fetchOwnerStores();
  }, [id]);

  const fetchOwnerStores = async () => {
    setLoading(true);
    try {
      const ownerStores = await storeStore.GetStoresByOwnerId(Number(id));
      setStores(ownerStores);
    } catch (error) {
      console.error("Error fetching owner stores:", error);
    } finally {
      setLoading(false);
    }
  };

  const handleStoreAdded = async () => {
    setShowAddForm(false);
    await fetchOwnerStores();
  };

  return (
    <Container maxWidth="lg" sx={{ py: 4 }}>
      <Card sx={{ mb: 3 }}>
        <CardContent sx={{ display: "flex", justifyContent: "space-between", alignItems: "center" }}>
          <Box>
            <Typography variant="h5" fontWeight="bold">
              החנויות של {name}
            </Typography>
            <Typography variant="body2" color="text.secondary">
              ניהול כל החנויות עבור בעל עסק זה
            </Typography>
          </Box>
          <Box display="flex" gap={2}>
            <Button variant="contained" onClick={() => setShowAddForm(true)}>
              ➕ הוסף חנות
            </Button>
            <Button variant="outlined" color="error" onClick={()=>{navigate(-1)}}>
              חזרה
            </Button>
          </Box>
        </CardContent>
      </Card>

      <Modal
        open={showAddForm}
        onClose={() => setShowAddForm(false)}
        sx={{ display: 'flex', alignItems: 'center', justifyContent: 'center' }}
      >
        <Paper sx={{ maxWidth: 700, width: '95%', maxHeight: '90vh', overflowY: 'auto', p: 3 }}>
          <AddStore storeOwnerId={Number(id)} onAdded={handleStoreAdded} />
        </Paper>
      </Modal>

      {loading ? (
        <Box textAlign="center" py={4}>
          <CircularProgress />
          <Typography color="textSecondary" mt={2}>
            טוען חנויות...
          </Typography>
        </Box>
      ) : stores.length === 0 ? (
        <Box textAlign="center" py={4}>
          <Typography color="textSecondary">אין חנויות עבור בעל עסק זה</Typography>
        </Box>
      ) : (
        <Box display="flex" flexDirection="column" gap={3}>
          {stores.map((store: Store) => (
            <Paper key={store.id} elevation={2} sx={{ p: 2 }}>
              <Grid container spacing={2}>
                <Grid size={{xs:12,md:6}}>
                  <Typography variant="h6">{store.storeName}</Typography>
                  <Typography variant="body2">כתובת: {store.address}</Typography>
                  <Typography variant="body2">טלפון: {store.phone}</Typography>
                  <Typography variant="body2">מקום עמדה: {store.standPlace}</Typography>
                  {store.cityId && <Typography variant="body2">עיר: {store.cityId}</Typography>}
                  {store.regionId && <Typography variant="body2">אזור: {store.regionId}</Typography>}
                </Grid>
                
                <Grid size={{xs:12,md:6}}>
                  <Box display="flex" flexDirection="column" gap={1}>
                    <Box display="flex" alignItems="center" gap={1}>
                      <Typography variant="body2">סטטוס:</Typography>
                      <Chip
                        label={store.status ? "פעיל" : "לא פעיל"}
                        color={store.status ? "success" : "error"}
                        size="small"
                      />
                    </Box>
                    <Box display="flex" alignItems="center" gap={1}>
                      <Typography variant="body2">רישיונות:</Typography>
                      <Chip
                        label={store.permitRoles ? "מאושר" : "ממתין"}
                        color={store.permitRoles ? "success" : "warning"}
                        size="small"
                      />
                    </Box>
                    {store.moreDetails && (
                      <Box>
                        <Typography variant="body2">פרטים נוספים:</Typography>
                        <Typography variant="body2" color="text.secondary">
                          {store.moreDetails}
                        </Typography>
                      </Box>
                    )}
                  </Box>
                </Grid>
              </Grid>

              {store.storeStand && store.storeStand.length > 0 && (
                <Box mt={2}>
                  <Divider />
                  <Typography variant="body2" mt={1}>
                    עמדות חנות:
                  </Typography>
                  <Box display="flex" gap={1} flexWrap="wrap">
                    {store.storeStand.map((stand, index) => (
                      <Chip
                        key={index}
                        label={stand.StandId || `עמדה ${index + 1}`}
                        color="info"
                        size="small"
                      />
                    ))}
                  </Box>
                </Box>
              )}
            </Paper>
          ))}
        </Box>
      )}
    </Container>
  );
});

export default StoreOwnerStores;

