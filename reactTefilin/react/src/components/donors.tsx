
import { useEffect, useState } from "react";
import { observer } from "mobx-react-lite";
import donorStore from "../stores/donorStore";
import type { Donor } from "../types/donor";
import {
  Avatar,
  Box,
  Button,
  Card,
  CardContent,
  Container,
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
  IconButton,
  InputAdornment,
  Stack,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  TextField,
  Tooltip,
  Typography
} from "@mui/material";
import {
  Add,
  Delete,
  Edit,
  Email,
  Phone,
  LocationOn,
  Person,
  Search,
  Clear
} from "@mui/icons-material";

const Donors = observer(() => {
  const [searchTerm, setSearchTerm] = useState("");
  const [isDeleteDialogOpen, setIsDeleteDialogOpen] = useState(false);
  const [selectedDonor, setSelectedDonor] = useState<Donor | null>(null);

  useEffect(() => {
    donorStore.GetAllDonors();
  }, []);

  const handleDeleteClick = (donor: Donor) => {
    setSelectedDonor(donor);
    setIsDeleteDialogOpen(true);
  };

  const confirmDelete = async () => {
    // כאן שים את הקריאה למחיקה אם קיימת
    setIsDeleteDialogOpen(false);
    setSelectedDonor(null);
  };

  const filteredDonors = donorStore.donors.filter(d =>
    [d.name, d.email, d.phone, d.address, d.city?.cityName]
      .some(val => val?.toLowerCase().includes(searchTerm.toLowerCase()))
  );

  return (
    <Container maxWidth="xl" sx={{ py: 3, direction: 'rtl' }}>
      <Card sx={{ mb: 3 }}>
        <CardContent>
          <Box sx={{ display: "flex", justifyContent: "space-between", alignItems: "center", mb: 3 }}>
            <Box>
              <Typography variant="h4" component="h1" gutterBottom sx={{ fontWeight: "bold", color: "primary.main" }}>
                תורמים
              </Typography>
              <Typography variant="body1" color="text.secondary">
                ניהול ומעקב אחר תורמים במערכת
              </Typography>
            </Box>
            <Button
              variant="contained"
              startIcon={<Add />}
              size="large"
              sx={{
                px: 4,
                py: 1.5,
                borderRadius: 2,
                boxShadow: 2,
                '&:hover': { boxShadow: 4 }
              }}
            >
              הוסף תורם
            </Button>
          </Box>

          {/* Search Bar */}
          <Box sx={{ width: '100%', maxWidth: 600 }}>
            <TextField
              fullWidth
              placeholder="חיפוש לפי שם, אימייל, טלפון, כתובת או עיר..."
              value={searchTerm}
              onChange={(e) => setSearchTerm(e.target.value)}
              variant="outlined"
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
      <Card>
        {filteredDonors.length === 0 ? (
          <Box sx={{ textAlign: "center", py: 8 }}>
            <Avatar sx={{ mx: "auto", mb: 3, bgcolor: "primary.50", width: 80, height: 80 }}>
              <Person sx={{ fontSize: 40, color: "primary.main" }} />
            </Avatar>
            <Typography variant="h5" gutterBottom>
              {searchTerm ? 'לא נמצאו תוצאות' : 'אין תורמים'}
            </Typography>
            <Typography variant="body1" color="text.secondary" sx={{ mb: 3 }}>
              {searchTerm ? 'נסה מונח אחר' : 'התחל בהוספת תורם'}
            </Typography>
          </Box>
        ) : (
          <TableContainer>
            <Table>
              <TableHead>
                <TableRow sx={{ bgcolor: "primary.50" }}>
                  <TableCell align="right" sx={{ fontWeight: "bold" }}>שם</TableCell>
                  <TableCell align="right" sx={{ fontWeight: "bold" }}>פרטי קשר</TableCell>
                  <TableCell align="right" sx={{ fontWeight: "bold" }}>עיר</TableCell>
                  <TableCell align="right" sx={{ fontWeight: "bold" }}>פעולות</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {filteredDonors.map((donor, index) => (
                  <TableRow
                    key={donor.id}
                    sx={{
                      "&:hover": {
                        bgcolor: "action.hover",
                        transform: "translateY(-1px)",
                        boxShadow: 1
                      },
                      transition: "all 0.2s ease-in-out"
                    }}
                  >
                    <TableCell align="right">
                      <Box sx={{ display: "flex", alignItems: "center", gap: 2 }}>
                        <Avatar sx={{
                          bgcolor: `hsl(${index * 137.5 % 360}, 70%, 50%)`,
                          width: 48,
                          height: 48
                        }}>
                          {donor.name?.charAt(0).toUpperCase()}
                        </Avatar>
                        <Typography variant="body1" fontWeight="medium">{donor.name}</Typography>
                      </Box>
                    </TableCell>
                    <TableCell align="right">
                      <Stack spacing={1}>
                        <Box sx={{ display: "flex", alignItems: "center", gap: 1 }}>
                          <Email fontSize="small" color="primary" />
                          <Typography variant="body2">{donor.email}</Typography>
                        </Box>
                        <Box sx={{ display: "flex", alignItems: "center", gap: 1 }}>
                          <Phone fontSize="small" color="success" />
                          <Typography variant="body2" fontFamily="monospace">{donor.phone}</Typography>
                        </Box>
                        <Box sx={{ display: "flex", alignItems: "center", gap: 1 }}>
                          <LocationOn fontSize="small" color="error" />
                          <Typography variant="body2">{donor.address}</Typography>
                        </Box>
                      </Stack>
                    </TableCell>
                    <TableCell align="right">
                      <Typography variant="body2">{donor.city?.cityName || "לא צוין"}</Typography>
                    </TableCell>
                    <TableCell align="right">
                      <Stack direction="row" spacing={1}>
                        <Tooltip title="ערוך">
                          <IconButton size="small" color="primary">
                            <Edit />
                          </IconButton>
                        </Tooltip>
                        <Tooltip title="מחק">
                          <IconButton size="small" color="error" onClick={() => handleDeleteClick(donor)}>
                            <Delete />
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

      {/* Stats */}
      <Card sx={{ mt: 3, bgcolor: "grey.50" }}>
        <CardContent>
          <Box sx={{ display: "flex", justifyContent: "space-between" }}>
            <Typography variant="body1" color="text.secondary">
              {searchTerm ?
                `נמצאו ${filteredDonors.length} מתוך ${donorStore.donors.length}` :
                `סה"כ: ${donorStore.donors.length} תורמים`
              }
            </Typography>
            <Typography variant="body1" color="text.secondary">
              עודכן: {new Date().toLocaleDateString("he-IL")}
            </Typography>
          </Box>
        </CardContent>
      </Card>

      {/* Delete Confirmation Dialog */}
      <Dialog
        open={isDeleteDialogOpen}
        onClose={() => setIsDeleteDialogOpen(false)}
        maxWidth="sm"
        fullWidth
      >
        <DialogTitle sx={{ bgcolor: "error.50", color: "error.main", fontWeight: "bold" }}>
          <Box sx={{ display: "flex", alignItems: "center", gap: 1 }}>
            <Delete />
            מחיקת תורם
          </Box>
        </DialogTitle>
        <DialogContent>
          <DialogContentText>
            האם למחוק את התורם <strong>{selectedDonor?.name}</strong>? פעולה זו לא ניתנת לביטול.
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setIsDeleteDialogOpen(false)}>ביטול</Button>
          <Button onClick={confirmDelete} color="error" variant="contained">מחק</Button>
        </DialogActions>
      </Dialog>
    </Container>
  );
});

export default Donors;

