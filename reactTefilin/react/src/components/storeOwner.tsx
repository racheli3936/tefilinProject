// import { useState, useEffect } from "react";
// import storeOwnerStore from "../stores/storeOwnerStore";
// import { observer } from "mobx-react-lite";
// import StoreOwnerStores from "./storeOwneStores";
// import type { storeOwner } from "../types/storeOwner";
// import AddStoreOwner from "./addStoreOwner";
// import StoreOwnerConversations from "./storeOwnerConversations";
// import {
//   Box, Paper, Typography, Button, Table, TableBody, TableCell, TableContainer, TableHead, TableRow,
//   Avatar, Chip, Container, Card, CardContent, Stack
// } from '@mui/material';
// import { Add, Store, Email, Phone, LocationOn, Person } from '@mui/icons-material';
// import TableCellInput from "../styleComponents/tableCellInput";
// import { useNavigate } from "react-router-dom";

// const StoreOwner = observer(() => {
//   const [isModalOpen, setIsModalOpen] = useState(false);
//   const [selectedStoreOwnerForStores, setSelectedStoreOwnerForStores] = useState<storeOwner | null>(null);
//   const [selectedStoreOwnerForConversations, setSelectedStoreOwnerForConversations] = useState<storeOwner | null>(null);
//   const [isConversationsModalOpen, setIsConversationsModalOpen] = useState(false);
// const navigate = useNavigate();
//   useEffect(() => {
//     storeOwnerStore.GetAllStoreOwners();
//   }, []);

//   const handleOpenModal = () => {
//     setIsModalOpen(true);
//   };

//   const handleCloseModal = () => {
//     setIsModalOpen(false);
//   };

//   const handleStoreOwnerClick = (storeOwner: storeOwner) => {
//     setSelectedStoreOwnerForStores(storeOwner);
//   };

//   const handleOpenConversationsModal = (storeOwner: storeOwner) => {
//     console.log(storeOwner);
//     setSelectedStoreOwnerForConversations(storeOwner);
//     console.log(selectedStoreOwnerForConversations);
//     setIsConversationsModalOpen(true);
//   };
//   return (
//     <>

//       {selectedStoreOwnerForStores ? (
//         <StoreOwnerStores
//           storeOwner={selectedStoreOwnerForStores}
//           onClose={() => setSelectedStoreOwnerForStores(null)}
//         />
//       ) : (
//         <>
//           <Container maxWidth="xl" sx={{ py: 3 }}>
//             {/* Header */}
//             <Card sx={{ mb: 3 }}>
//               <CardContent>
//                 <Box
//                   sx={{
//                     display: "flex",
//                     justifyContent: "space-between",
//                     alignItems: "center",
//                     direction: "rtl",
//                   }}
//                 >
//                   <Box>
//                     <Typography
//                       variant="h6"
//                       component="h6"
//                       gutterBottom
//                       sx={{ fontWeight: "bold" }}
//                     >
//                       בעלי חנויות
//                     </Typography>
//                     <Typography variant="body1" color="text.secondary">
//                       ניהול ומעקב אחר בעלי החנויות במערכת
//                     </Typography>
//                   </Box>
//                   <Button
//                     variant="contained"
//                     startIcon={<Add />}
//                     onClick={handleOpenModal}
//                     size="large"
//                     sx={{ px: 3 }}
//                   >
//                     הוסף בעל חנות
//                   </Button>
//                 </Box>
//               </CardContent>
//             </Card>

//             {/* Table */}
//             <Paper elevation={2}>
//               {storeOwnerStore.storeOwners.length === 0 ? (
//                 <Box sx={{ textAlign: "center", py: 8 }}>
//                   <Avatar
//                     sx={{
//                       mx: "auto",
//                       mb: 2,
//                       bgcolor: "grey.100",
//                       width: 64,
//                       height: 64,
//                     }}
//                   >
//                     <Person sx={{ fontSize: 32, color: "grey.400" }} />
//                   </Avatar>
//                   <Typography variant="h6" color="text.primary" gutterBottom>
//                     אין בעלי חנויות
//                   </Typography>
//                   <Typography variant="body2" color="text.secondary">
//                     התחל בהוספת בעל חנות ראשון
//                   </Typography>
//                 </Box>
//               ) : (
//                 <TableContainer>
//                   <Table>
//                     <TableHead>
//                       <TableRow sx={{ bgcolor: "grey.50" }}>
//                         <TableCellInput text={"שם"} />
//                         <TableCellInput text={"מייל"} />
//                         <TableCellInput text={"כתובת"} />
//                         <TableCellInput text={"טלפון"} />
//                         <TableCellInput text={"חנויות"} />
//                         <TableCellInput text={"שיחות"} /> {/* הוספת כותרת לשיחות */}
//                       </TableRow>
//                     </TableHead>
//                     <TableBody>
//                       {storeOwnerStore.storeOwners.map((storeOwner) => (
//                         <TableRow
//                           key={storeOwner.id}
//                           hover
//                           sx={{
//                             "&:nth-of-type(odd)": { bgcolor: "grey.50" },
//                             cursor: "pointer",
//                           }}
//                         >
//                           <TableCell align="right">
//                             <Box sx={{ display: "flex", alignItems: "center", gap: 2 }}>
//                               <Avatar sx={{ bgcolor: "primary.main", width: 40, height: 40 }}>
//                                 {storeOwner.name?.charAt(0).toUpperCase() || "U"}
//                               </Avatar>
//                               <Button
//                                 variant="text"
//                                 onClick={() => handleStoreOwnerClick(storeOwner)}
//                                 sx={{
//                                   textTransform: "none",
//                                   fontWeight: "medium",
//                                   color: "text.primary",
//                                   "&:hover": { color: "primary.main" },
//                                 }}
//                               >
//                                 {storeOwner.name}
//                               </Button>
//                             </Box>
//                           </TableCell>
//                           <TableCell align="right">
//                             <Box sx={{ display: "flex", alignItems: "center", gap: 1 }}>
//                               <Email sx={{ fontSize: 16, color: "text.secondary" }} />
//                               <Typography variant="body2">{storeOwner.email}</Typography>
//                             </Box>
//                           </TableCell>
//                           <TableCell align="right">
//                             <Box sx={{ display: "flex", alignItems: "center", gap: 1 }}>
//                               <LocationOn sx={{ fontSize: 16, color: "text.secondary" }} />
//                               <Typography variant="body2">{storeOwner.address}</Typography>
//                             </Box>
//                           </TableCell>
//                           <TableCell align="right">
//                             <Box sx={{ display: "flex", alignItems: "center", gap: 1 }}>
//                               <Phone sx={{ fontSize: 16, color: "text.secondary" }} />
//                               <Typography variant="body2" sx={{ fontFamily: "monospace" }}>
//                                 {storeOwner.phone}
//                               </Typography>
//                             </Box>
//                           </TableCell>
//                           <TableCell align="right">
//                             {storeOwner.stores && storeOwner.stores.length > 0 ? (
//                               <Stack direction="row" spacing={1} sx={{ justifyContent: "flex-end" }}>
//                                 {storeOwner.stores.slice(0, 2).map((store, index) => (
//                                   <Chip
//                                     key={store.id || index}
//                                     label={store.storeName || `חנות ${store.id}`}
//                                     size="small"
//                                     variant="outlined"
//                                     color="primary"
//                                     icon={<Store />}
//                                   />
//                                 ))}
//                                 {storeOwner.stores.length > 2 && (
//                                   <Chip
//                                     label={`+${storeOwner.stores.length - 2}`}
//                                     size="small"
//                                     variant="outlined"
//                                     color="default"
//                                   />
//                                 )}
//                               </Stack>
//                             ) : (
//                               <Typography
//                                 variant="body2"
//                                 color="text.secondary"
//                                 sx={{ fontStyle: "italic" }}
//                               >
//                                 אין חנויות
//                               </Typography>
//                             )}
//                           </TableCell>
//                           <TableCell align="right">
//                             <Button
//                               variant="outlined"
//                               size="small"
//                               onClick={() => {
//                                 navigate(`/storeOwnerConversations/${storeOwner.id}`)
//                               }}
//                             >
//                               שיחות
//                             </Button>
//                           </TableCell>
//                         </TableRow>
//                       ))}
//                     </TableBody>
//                   </Table>
//                 </TableContainer>
//               )}
//             </Paper>

//             {/* Stats Footer */}
//             <Card sx={{ mt: 3 }}>
//               <CardContent>
//                 <Box sx={{ display: "flex", justifyContent: "space-between", alignItems: "center" }}>
//                   <Typography variant="body2" color="text.secondary">
//                     סך הכל: {storeOwnerStore.storeOwners.length} בעלי חנויות
//                   </Typography>
//                   <Typography variant="body2" color="text.secondary">
//                     עודכן לאחרונה: {new Date().toLocaleDateString("he-IL")}
//                   </Typography>
//                 </Box>
//               </CardContent>
//             </Card>

//             <AddStoreOwner isOpen={isModalOpen} onClose={handleCloseModal} />

//           </Container>
//           {/* <StoreOwnerConversations 
//             isOpen={isConversationsModalOpen}
//             onClose={() => setIsConversationsModalOpen(false)}
//             storeOwner={selectedStoreOwnerForConversations}
//             //conversations={selectedConversations}
//           /> */}
//         </>
//       )}
//     </>
//   );
// });

// export default StoreOwner;
import { useState, useEffect } from "react";
import { observer } from "mobx-react-lite";
import { Box, Typography, Button, Table, TableBody, TableCell,TableContainer, TableHead, TableRow,Avatar,Container,Card, CardContent, Stack,IconButton,Tooltip,
  Dialog, DialogTitle,DialogContent,DialogActions,DialogContentText,TextField,InputAdornment} from '@mui/material';
import { Add, Store, Email, Phone, LocationOn,
  Person, Edit, Delete, Chat, Search, Clear} from '@mui/icons-material';
import type { storeOwner } from "../types/storeOwner";
import storeOwnerStore from "../stores/storeOwnerStore";
import StoreOwnerConversations from "./storeOwnerConversations";
import AddStoreOwner from "./addStoreOwner";
import { useNavigate } from "react-router-dom";

const StoreOwner = observer(() => {
  const [isAddModalOpen, setIsAddModalOpen] = useState(false);
  const [isEditModalOpen, setIsEditModalOpen] = useState(false);
  const [isDeleteModalOpen, setIsDeleteModalOpen] = useState(false);
  const [isConversationsModalOpen, setIsConversationsModalOpen] = useState(false);
  const [selectedStoreOwner, setSelectedStoreOwner] = useState<storeOwner | null>(null);
  const [searchTerm, setSearchTerm] = useState("");
const navigate=useNavigate();

  useEffect(() => {
    storeOwnerStore.GetAllStoreOwners();
  }, []);

  // const handleAddStoreOwner = () => {
  //   setIsAddModalOpen(false);
  // };

  const handleEditStoreOwner = (storeOwner: storeOwner) => {
    console.log("Edit store owner:", storeOwner);
    setSelectedStoreOwner(storeOwner);
    setIsEditModalOpen(true);
  };

  const handleDeleteStoreOwner = (storeOwner: storeOwner) => {
    setSelectedStoreOwner(storeOwner);
    setIsDeleteModalOpen(true);
  };

  // const handleOpenStoreDetails = (store: any) => {
  //   setSelectedStore(store);
  //   setIsStoreDetailsModalOpen(true);
  // };

  const confirmDeleteStoreOwner = async () => {
    if (selectedStoreOwner) {
      try {
        await storeOwnerStore.DeleteStoreOwner(selectedStoreOwner.id);
        setIsDeleteModalOpen(false);
        setSelectedStoreOwner(null);
      } catch (error) {
        console.error("Error deleting store owner:", error);
      }
    }
  };

  const handleOpenConversations = (storeOwner: storeOwner) => {
    setSelectedStoreOwner(storeOwner);
    setIsConversationsModalOpen(true);
  };

  const storeOwners = storeOwnerStore.storeOwners;

  // פילטור חכם
  const filteredStoreOwners = storeOwners.filter(owner => {
    if (!searchTerm) return true;

    const searchLower = searchTerm.toLowerCase();

    // חיפוש לפי שם בעל עסק
    if (owner.name?.toLowerCase().includes(searchLower)) return true;

    // חיפוש לפי אימייל
    if (owner.email?.toLowerCase().includes(searchLower)) return true;

    // חיפוש לפי טלפון
    if (owner.phone?.includes(searchTerm)) return true;

    // חיפוש לפי שם חנות או כתובת חנות
    if (owner.stores?.some(store =>
      store.storeName?.toLowerCase().includes(searchLower) ||
      store.address?.toLowerCase().includes(searchLower)
    )) return true;

    return false;
  });

  return (
    <Container maxWidth="xl" sx={{ py: 3, direction: 'rtl' }}>
      {/* Header */}
      <Card sx={{ mb: 3 }}>
        <CardContent>
          <Box
            sx={{
              display: "flex",
              justifyContent: "space-between",
              alignItems: "center",
              mb: 3
            }}
          >
            <Box>
              <Typography
                variant="h4"
                component="h1"
                gutterBottom
                sx={{ fontWeight: "bold", color: "primary.main" }}
              >
                בעלי עסקים
              </Typography>
              <Typography variant="body1" color="text.secondary">
                ניהול ומעקב אחר בעלי העסקים במערכת
              </Typography>
            </Box>
            <Button
              variant="contained"
              startIcon={<Add />}
              onClick={() => setIsAddModalOpen(true)}
              size="large"
              sx={{
                px: 4,
                py: 1.5,
                borderRadius: 2,
                boxShadow: 2,
                '&:hover': { boxShadow: 4 }
              }}
            >
              הוסף בעל עסק
            </Button>
          </Box>

          {/* Search Bar */}
          <Box sx={{ width: '100%', maxWidth: 600 }}>
            <TextField
              fullWidth
              placeholder="חיפוש לפי שם בעל עסק, אימייל, טלפון, שם חנות או כתובת..."
              value={searchTerm}
              onChange={(e) => setSearchTerm(e.target.value)}
              variant="outlined"
              sx={{
                '& .MuiOutlinedInput-root': {
                  borderRadius: 2,
                  bgcolor: 'background.paper',
                  '&:hover': {
                    boxShadow: 1
                  },
                  '&.Mui-focused': {
                    boxShadow: 2
                  }
                }
              }}
              InputProps={{
                startAdornment: (
                  <InputAdornment position="start">
                    <Search sx={{ color: 'text.secondary' }} />
                  </InputAdornment>
                ),
                endAdornment: searchTerm && (
                  <InputAdornment position="end">
                    <IconButton
                      size="small"
                      onClick={() => setSearchTerm("")}
                      sx={{ color: 'text.secondary' }}
                    >
                      <Clear />
                    </IconButton>
                  </InputAdornment>
                )
              }}
            />
          </Box>
        </CardContent>
      </Card>

      {/* Table */}
      <Card sx={{ boxShadow: 3 }}>
        {filteredStoreOwners.length === 0 ? (
          <Box sx={{ textAlign: "center", py: 8 }}>
            <Avatar
              sx={{
                mx: "auto",
                mb: 3,
                bgcolor: "primary.50",
                width: 80,
                height: 80,
              }}
            >
              {searchTerm ? <Search sx={{ fontSize: 40, color: "primary.main" }} /> : <Person sx={{ fontSize: 40, color: "primary.main" }} />}
            </Avatar>
            <Typography variant="h5" color="text.primary" gutterBottom>
              {searchTerm ? 'לא נמצאו תוצאות' : 'אין בעלי עסקים'}
            </Typography>
            <Typography variant="body1" color="text.secondary" sx={{ mb: 3 }}>
              {searchTerm ? 'נסה לחפש במילים אחרות' : 'התחל בהוספת בעל עסק ראשון'}
            </Typography>
            {!searchTerm && (
              <Button
                variant="contained"
                startIcon={<Add />}
                onClick={() => setIsAddModalOpen(true)}
                size="large"
              >
                הוסף בעל עסק
              </Button>
            )}
          </Box>
        ) : (
          <TableContainer sx={{ direction: 'rtl' }}>
            <Table>
              <TableHead>
                <TableRow sx={{ bgcolor: "primary.50" }}>
                  <TableCell align="right" sx={{ fontWeight: "bold", fontSize: "1rem", minWidth: 250 }}>
                    שם בעל העסק
                  </TableCell>
                  <TableCell align="right" sx={{ fontWeight: "bold", fontSize: "1rem", minWidth: 300 }}>
                    פרטי קשר
                  </TableCell>
                  <TableCell align="right" sx={{ fontWeight: "bold", fontSize: "1rem", minWidth: 350 }}>
                    חנויות ({filteredStoreOwners.reduce((total, owner) => total + (owner.stores?.length || 0), 0)})
                  </TableCell>
                  <TableCell align="right" sx={{ fontWeight: "bold", fontSize: "1rem", minWidth: 150 }}>
                    פעולות
                  </TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {filteredStoreOwners.map((storeOwner, index) => (
                  <TableRow
                    key={storeOwner.id}
                    sx={{
                      "&:hover": {
                        bgcolor: "action.hover",
                        transform: "translateY(-1px)",
                        boxShadow: 1
                      },
                      transition: "all 0.2s ease-in-out"
                    }}
                  >
                    {/* שם בעל העסק */}
                    <TableCell align="right">
                      <Box sx={{ display: "flex", alignItems: "center", gap: 2 }}>
                        <Avatar
                          sx={{
                            bgcolor: `hsl(${index * 137.5 % 360}, 70%, 50%)`,
                            width: 48,
                            height: 48,
                            fontWeight: "bold"
                          }}
                        >
                          {storeOwner.name?.charAt(0).toUpperCase() || "U"}
                        </Avatar>
                        <Box>
                          <Typography variant="h6" sx={{ fontWeight: "medium", color: "text.primary" }}>
                            {storeOwner.name}
                          </Typography>
                        </Box>
                      </Box>
                    </TableCell>

                    {/* פרטי קשר */}
                    <TableCell align="right">
                      <Stack spacing={1.5}>
                        <Box sx={{ display: "flex", alignItems: "center", gap: 1 }}>
                          <Email sx={{ fontSize: 18, color: "primary.main" }} />
                          <Typography variant="body2" sx={{ fontWeight: "medium" }}>
                            {storeOwner.email}
                          </Typography>
                        </Box>
                        <Box sx={{ display: "flex", alignItems: "center", gap: 1 }}>
                          <Phone sx={{ fontSize: 18, color: "success.main" }} />
                          <Typography variant="body2" sx={{ fontFamily: "monospace", fontWeight: "medium" }}>
                            {storeOwner.phone}
                          </Typography>
                        </Box>
                        <Box sx={{ display: "flex", alignItems: "flex-start", gap: 1 }}>
                          <LocationOn sx={{ fontSize: 18, color: "error.main", mt: 0.2 }} />
                          <Typography variant="body2" sx={{ maxWidth: 200, lineHeight: 1.4 }}>
                            {storeOwner.address}
                          </Typography>
                        </Box>
                      </Stack>
                    </TableCell>

                    {/* חנויות */}
                    <TableCell align="right">
                      {storeOwner.stores && storeOwner.stores.length > 0 ? (
                        <Box>
                          <Typography variant="body2" sx={{ fontWeight: "bold", color: "primary.main", mb: 2 }}>
                            {storeOwner.stores.length} חנויות
                          </Typography>

                          {storeOwner.stores.map((store, storeIndex) => (
                            <Box
                              key={store.id || storeIndex}
                              sx={{
                                p: 2,
                                bgcolor: "background.default",
                                borderRadius: 1,
                                border: "1px solid",
                                borderColor: "divider",
                                boxShadow: 1,
                                cursor: "pointer",
                                transition: "0.2s",
                                "&:hover": {
                                  boxShadow: 4,
                                  bgcolor: "primary.50"
                                }
                              }}
                              onClick={() => navigate(`/stores/${storeOwner.id}/${storeOwner.name}`)}

                            >
                             <Typography variant="body1" color="text.primary">
                                  <Box component="span" sx={{ fontWeight: "bold" }}>
                                    {store.storeName || `חנות ${store.id}`}
                                  </Box>
                                  : {store.address}, {store.city?.cityName || "לא צוין עיר"}
                                </Typography>
                            </Box>

                          ))}
                        </Box>
                      ) : (
                        <Box sx={{ textAlign: "center", py: 3, color: "text.secondary", fontStyle: "italic" }}>
                          <Store sx={{ fontSize: 32, opacity: 0.3, mb: 1 }} />
                          <Typography variant="body2">
                            אין חנויות (0)
                          </Typography>
                        </Box>
                      )}
                    </TableCell>



                    {/* פעולות */}
                    <TableCell align="right">
                      <Stack direction="row" spacing={1} sx={{ justifyContent: "flex-end" }}>
                        <Tooltip title="עריכה" arrow>
                          <IconButton
                            size="small"
                            color="primary"
                            onClick={() => handleEditStoreOwner(storeOwner)}
                            sx={{
                              bgcolor: "primary.50",
                              "&:hover": { bgcolor: "primary.100" }
                            }}
                          >
                            <Edit />
                          </IconButton>
                        </Tooltip>
                        <Tooltip title="מחיקה" arrow>
                          <IconButton
                            size="small"
                            color="error"
                            onClick={() => handleDeleteStoreOwner(storeOwner)}
                            sx={{
                              bgcolor: "error.50",
                              "&:hover": { bgcolor: "error.100" }
                            }}
                          >
                            <Delete />
                          </IconButton>
                        </Tooltip>
                        <Tooltip title="שיחות" arrow>
                          <IconButton
                            size="small"
                            color="success"
                            onClick={() => handleOpenConversations(storeOwner)}
                            sx={{
                              bgcolor: "success.50",
                              "&:hover": { bgcolor: "success.100" }
                            }}
                          >
                            <Chat />
                          </IconButton>
                        </Tooltip>
                      </Stack>
                    </TableCell>
                  </TableRow>
                ))}
              </TableBody>
            </Table>
          </TableContainer>
        )}
      </Card>

      {/* Stats Footer */}
      <Card sx={{ mt: 3, bgcolor: "grey.50" }}>
        <CardContent>
          <Box sx={{ display: "flex", justifyContent: "space-between", alignItems: "center" }}>
            <Typography variant="body1" color="text.secondary" sx={{ fontWeight: "medium" }}>
              {searchTerm ?
                `נמצאו ${filteredStoreOwners.length} תוצאות מתוך ${storeOwners.length} בעלי עסקים` :
                `סך הכל: ${storeOwners.length} בעלי עסקים`
              }
            </Typography>
            <Typography variant="body1" color="text.secondary" sx={{ fontWeight: "medium" }}>
              עודכן לאחרונה: {new Date().toLocaleDateString("he-IL")}
            </Typography>
          </Box>
        </CardContent>
      </Card>

      {/* Delete Confirmation Dialog */}
      <Dialog
        open={isDeleteModalOpen}
        onClose={() => setIsDeleteModalOpen(false)}
        aria-labelledby="delete-dialog-title"
        aria-describedby="delete-dialog-description"
        maxWidth="sm"
        fullWidth
      >
        <DialogTitle id="delete-dialog-title" sx={{
          bgcolor: "error.50",
          color: "error.main",
          fontWeight: "bold"
        }}>
          <Box sx={{ display: "flex", alignItems: "center", gap: 1 }}>
            <Delete />
            מחיקת בעל עסק
          </Box>
        </DialogTitle>
        <DialogContent sx={{ pt: 3 }}>
          <DialogContentText id="delete-dialog-description" sx={{ fontSize: "1rem" }}>
            האם אתה בטוח שברצונך למחוק את בעל העסק <strong>"{selectedStoreOwner?.name}"</strong>?
          </DialogContentText>
          <Typography variant="body2" color="error.main" sx={{ mt: 2, fontWeight: "medium" }}>
            פעולה זו לא ניתנת לביטול ותמחק גם את כל החנויות הקשורות.
          </Typography>
        </DialogContent>
        <DialogActions sx={{ p: 3 }}>
          <Button
            onClick={() => setIsDeleteModalOpen(false)}
            variant="outlined"
            size="large"
          >
            ביטול
          </Button>
          <Button
            onClick={confirmDeleteStoreOwner}
            color="error"
            variant="contained"
            size="large"
            autoFocus
          >
            מחק
          </Button>
        </DialogActions>
      </Dialog>

      {/* Add Store Owner Modal */}
      <AddStoreOwner
        isOpen={isAddModalOpen}
        onClose={() => setIsAddModalOpen(false)}
      />

      {/* Edit Store Owner Dialog */}
      <Dialog open={isEditModalOpen} onClose={() => setIsEditModalOpen(false)} maxWidth="md" fullWidth>
        <DialogTitle sx={{ bgcolor: "warning.50", color: "warning.main", fontWeight: "bold" }}>
          <Box sx={{ display: "flex", alignItems: "center", gap: 1 }}>
            <Edit />
            עריכת בעל עסק
          </Box>
        </DialogTitle>
        <DialogContent sx={{ pt: 3 }}>
          <Typography variant="h6" gutterBottom>
            עריכת פרטי בעל העסק: {selectedStoreOwner?.name}
          </Typography>
          <Typography variant="body2" color="text.secondary">
            כאן תהיה הטופס לעריכת פרטי בעל העסק
          </Typography>
        </DialogContent>
        <DialogActions sx={{ p: 3 }}>
          <Button
            onClick={() => setIsEditModalOpen(false)}
            variant="outlined"
            size="large"
          >
            ביטול
          </Button>
          <Button
            variant="contained"
            size="large"
          >
            שמור
          </Button>
        </DialogActions>
      </Dialog>

      {/* Conversations Dialog */}
      {selectedStoreOwner && (
        <StoreOwnerConversations
          isOpen={isConversationsModalOpen}
          onClose={() => setIsConversationsModalOpen(false)}
          storeOwner={selectedStoreOwner}
        />
      )}
    </Container>
  );
});

export default StoreOwner;