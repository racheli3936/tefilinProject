import { useState, useEffect } from "react";
import storeOwnerStore from "../stores/storeOwnerStore";
import { observer } from "mobx-react-lite";
import StoreOwnerStores from "./storeOwneStores";
import type { storeOwner } from "../types/storeOwner";
import AddStoreOwner from "./addStoreOwner";
import StoreOwnerConversations from "./storeOwnerConversations"; 
import { Box, Paper, Typography, Button, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, 
 Avatar, Chip, Container, Card, CardContent, Stack } from '@mui/material';
import { Add, Store, Email, Phone, LocationOn, Person } from '@mui/icons-material';
import TableCellInput from "../styleComponents/tableCellInput";

const StoreOwner = observer(() => {
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [selectedStoreOwnerForStores, setSelectedStoreOwnerForStores] = useState<storeOwner | null>(null);
  const [selectedStoreOwnerForConversations, setSelectedStoreOwnerForConversations] = useState<storeOwner | null>(null);
  const [isConversationsModalOpen, setIsConversationsModalOpen] = useState(false);

  useEffect(() => {
    storeOwnerStore.GetAllStoreOwners();
  }, []);

  const handleOpenModal = () => {
    setIsModalOpen(true);
  };

  const handleCloseModal = () => {
    setIsModalOpen(false);
  };

  const handleStoreOwnerClick = (storeOwner: storeOwner) => {
    setSelectedStoreOwnerForStores(storeOwner);
  };

  const handleOpenConversationsModal = (storeOwner: storeOwner) => {
    console.log(storeOwner);
    
    //const conversations = storeOwner.conversations || []; // נניח שיש שיחות בבעל העסק
   // setSelectedConversations(conversations);
   setSelectedStoreOwnerForConversations(storeOwner);
   console.log(selectedStoreOwnerForConversations);
   
    setIsConversationsModalOpen(true);
  };
  return (
    <>
      {selectedStoreOwnerForStores ? (
        <StoreOwnerStores
          storeOwner={selectedStoreOwnerForStores}
          onClose={() => setSelectedStoreOwnerForStores(null)}
        />
      ) : (
        <Container maxWidth="xl" sx={{ py: 3 }}>
          {/* Header */}
          <Card sx={{ mb: 3 }}>
            <CardContent>
              <Box
                sx={{
                  display: "flex",
                  justifyContent: "space-between",
                  alignItems: "center",
                  direction: "rtl",
                }}
              >
                <Box>
                  <Typography
                    variant="h6"
                    component="h6"
                    gutterBottom
                    sx={{ fontWeight: "bold" }}
                  >
                    בעלי חנויות
                  </Typography>
                  <Typography variant="body1" color="text.secondary">
                    ניהול ומעקב אחר בעלי החנויות במערכת
                  </Typography>
                </Box>
                <Button
                  variant="contained"
                  startIcon={<Add />}
                  onClick={handleOpenModal}
                  size="large"
                  sx={{ px: 3 }}
                >
                  הוסף בעל חנות
                </Button>
              </Box>
            </CardContent>
          </Card>

          {/* Table */}
          <Paper elevation={2}>
            {storeOwnerStore.storeOwners.length === 0 ? (
              <Box sx={{ textAlign: "center", py: 8 }}>
                <Avatar
                  sx={{
                    mx: "auto",
                    mb: 2,
                    bgcolor: "grey.100",
                    width: 64,
                    height: 64,
                  }}
                >
                  <Person sx={{ fontSize: 32, color: "grey.400" }} />
                </Avatar>
                <Typography variant="h6" color="text.primary" gutterBottom>
                  אין בעלי חנויות
                </Typography>
                <Typography variant="body2" color="text.secondary">
                  התחל בהוספת בעל חנות ראשון
                </Typography>
              </Box>
            ) : (
              <TableContainer>
                <Table>
                  <TableHead>
                    <TableRow sx={{ bgcolor: "grey.50" }}>
                      <TableCellInput text={"שם"} />
                      <TableCellInput text={"מייל"} />
                      <TableCellInput text={"כתובת"} />
                      <TableCellInput text={"טלפון"} />
                      <TableCellInput text={"חנויות"} />
                      <TableCellInput text={"שיחות"} /> {/* הוספת כותרת לשיחות */}
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    {storeOwnerStore.storeOwners.map((storeOwner) => (
                      <TableRow
                        key={storeOwner.id}
                        hover
                        sx={{
                          "&:nth-of-type(odd)": { bgcolor: "grey.50" },
                          cursor: "pointer",
                        }}
                      >
                        <TableCell align="right">
                          <Box sx={{ display: "flex", alignItems: "center", gap: 2 }}>
                            <Avatar sx={{ bgcolor: "primary.main", width: 40, height: 40 }}>
                              {storeOwner.name?.charAt(0).toUpperCase() || "U"}
                            </Avatar>
                            <Button
                              variant="text"
                              onClick={() => handleStoreOwnerClick(storeOwner)}
                              sx={{
                                textTransform: "none",
                                fontWeight: "medium",
                                color: "text.primary",
                                "&:hover": { color: "primary.main" },
                              }}
                            >
                              {storeOwner.name}
                            </Button>
                          </Box>
                        </TableCell>
                        <TableCell align="right">
                          <Box sx={{ display: "flex", alignItems: "center", gap: 1 }}>
                            <Email sx={{ fontSize: 16, color: "text.secondary" }} />
                            <Typography variant="body2">{storeOwner.email}</Typography>
                          </Box>
                        </TableCell>
                        <TableCell align="right">
                          <Box sx={{ display: "flex", alignItems: "center", gap: 1 }}>
                            <LocationOn sx={{ fontSize: 16, color: "text.secondary" }} />
                            <Typography variant="body2">{storeOwner.address}</Typography>
                          </Box>
                        </TableCell>
                        <TableCell align="right">
                          <Box sx={{ display: "flex", alignItems: "center", gap: 1 }}>
                            <Phone sx={{ fontSize: 16, color: "text.secondary" }} />
                            <Typography variant="body2" sx={{ fontFamily: "monospace" }}>
                              {storeOwner.phone}
                            </Typography>
                          </Box>
                        </TableCell>
                        <TableCell align="right">
                          {storeOwner.stores && storeOwner.stores.length > 0 ? (
                            <Stack direction="row" spacing={1} sx={{ justifyContent: "flex-end" }}>
                              {storeOwner.stores.slice(0, 2).map((store, index) => (
                                <Chip
                                  key={store.id || index}
                                  label={store.storeName || `חנות ${store.id}`}
                                  size="small"
                                  variant="outlined"
                                  color="primary"
                                  icon={<Store />}
                                />
                              ))}
                              {storeOwner.stores.length > 2 && (
                                <Chip
                                  label={`+${storeOwner.stores.length - 2}`}
                                  size="small"
                                  variant="outlined"
                                  color="default"
                                />
                              )}
                            </Stack>
                          ) : (
                            <Typography
                              variant="body2"
                              color="text.secondary"
                              sx={{ fontStyle: "italic" }}
                            >
                              אין חנויות
                            </Typography>
                          )}
                        </TableCell>
                        <TableCell align="right">
                          <Button
                            variant="outlined"
                            size="small"
                            onClick={() => handleOpenConversationsModal(storeOwner)}
                          >
                            שיחות
                          </Button>
                        </TableCell>
                      </TableRow>
                    ))}
                  </TableBody>
                </Table>
              </TableContainer>
            )}
          </Paper>

          {/* Stats Footer */}
          <Card sx={{ mt: 3 }}>
            <CardContent>
              <Box sx={{ display: "flex", justifyContent: "space-between", alignItems: "center" }}>
                <Typography variant="body2" color="text.secondary">
                  סך הכל: {storeOwnerStore.storeOwners.length} בעלי חנויות
                </Typography>
                <Typography variant="body2" color="text.secondary">
                  עודכן לאחרונה: {new Date().toLocaleDateString("he-IL")}
                </Typography>
              </Box>
            </CardContent>
          </Card>

          <AddStoreOwner isOpen={isModalOpen} onClose={handleCloseModal} />
          <StoreOwnerConversations 
            isOpen={isConversationsModalOpen}
            onClose={() => setIsConversationsModalOpen(false)}
            storeOwner={selectedStoreOwnerForConversations}
            //conversations={selectedConversations}
          />
        </Container>
      )}
    </>
  );
});

export default StoreOwner;
