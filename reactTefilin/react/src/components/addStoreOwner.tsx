import { useState } from "react";
import storeOwnerStore from "../stores/storeOwnerStore";
import { observer } from "mobx-react-lite";
import {Dialog, DialogTitle, DialogContent, DialogActions, TextField, Button, IconButton, Box, Typography,
    Stack,Alert} from '@mui/material';
import { Close, Person, LocationOn, Phone, Email, Save } from '@mui/icons-material';

interface AddStoreOwnerProps {
    isOpen: boolean;
    onClose: () => void;
}

const AddStoreOwner = 
observer(
    ({ isOpen, onClose }: AddStoreOwnerProps) => {
    const [formData, setFormData] = useState({
        name: "",
        address: "",
        phone: "",
        email: ""
    });

    const [isSubmitting, setIsSubmitting] = useState(false);
    const [error, setError] = useState("");

    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setFormData(prev => ({
            ...prev,
            [name]: value
        }));
        // Clear error when user starts typing
        if (error) setError("");
    };

    const handleSubmit = async () => {
        if (!formData.name || !formData.address || !formData.phone || !formData.email) {
            setError("יש למלא את כל השדות");
            return;
        }

        setIsSubmitting(true);
        setError("");

        try {
            await storeOwnerStore.AddStoreOwner(formData);
            
            // Reset form
            setFormData({
                name: "",
                address: "",
                phone: "",
                email: ""
            });
            
            // Close modal
            onClose();
        } catch (error) {
            console.error("Error adding store owner:", error);
            setError("אירעה שגיאה בהוספת בעל החנות");
        } finally {
            setIsSubmitting(false);
        }
    };

    const resetForm = () => {
        setFormData({
            name: "",
            address: "",
            phone: "",
            email: ""
        });
        setError("");
    };

    const handleClose = () => {
        resetForm();
        onClose();
    };

    return (
        <Dialog 
            open={isOpen} 
            onClose={handleClose}
            maxWidth="sm"
            fullWidth
            PaperProps={{
                sx: { borderRadius: 2 }
            }}
        >
            <DialogTitle>
                <Box sx={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}>
                    <Box sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
                        <Person color="primary" />
                        <Typography variant="h6" component="div">
                            הוספת בעל חנות
                        </Typography>
                    </Box>
                    <IconButton 
                        onClick={handleClose}
                        size="small"
                        sx={{ color: 'grey.500' }}
                    >
                        <Close />
                    </IconButton>
                </Box>
            </DialogTitle>

            <DialogContent sx={{ pb: 2 }}>
                <Stack spacing={3} sx={{ mt: 1 }}>
                    {error && (
                        <Alert severity="error" sx={{ mb: 2 }}>
                            {error}
                        </Alert>
                    )}

                    <TextField
                        fullWidth
                        label="שם מלא"
                        name="name"
                        value={formData.name}
                        onChange={handleInputChange}
                        placeholder="הכנס שם מלא"
                        variant="outlined"
                        InputProps={{
                            startAdornment: <Person sx={{ color: 'grey.500', mr: 1 }} />
                        }}
                        required
                    />

                    <TextField
                        fullWidth
                        label="כתובת"
                        name="address"
                        value={formData.address}
                        onChange={handleInputChange}
                        placeholder="הכנס כתובת"
                        variant="outlined"
                        InputProps={{
                            startAdornment: <LocationOn sx={{ color: 'grey.500', mr: 1 }} />
                        }}
                        required
                    />

                    <TextField
                        fullWidth
                        label="טלפון"
                        name="phone"
                        type="tel"
                        value={formData.phone}
                        onChange={handleInputChange}
                        placeholder="הכנס מספר טלפון"
                        variant="outlined"
                        InputProps={{
                            startAdornment: <Phone sx={{ color: 'grey.500', mr: 1 }} />
                        }}
                        required
                    />

                    <TextField
                        fullWidth
                        label="אימייל"
                        name="email"
                        type="email"
                        value={formData.email}
                        onChange={handleInputChange}
                        placeholder="הכנס כתובת אימייל"
                        variant="outlined"
                        InputProps={{
                            startAdornment: <Email sx={{ color: 'grey.500', mr: 1 }} />
                        }}
                        required
                    />
                </Stack>
            </DialogContent>

            <DialogActions sx={{ px: 3, pb: 3 }}>
                <Stack direction="row" spacing={2} sx={{ width: '100%', justifyContent: 'flex-end' }}>
                    <Button
                        onClick={handleClose}
                        variant="outlined"
                        color="inherit"
                        disabled={isSubmitting}
                    >
                        ביטול
                    </Button>
                    <Button
                        onClick={handleSubmit}
                        variant="contained"
                        disabled={isSubmitting}
                        startIcon={isSubmitting ? null : <Save />}
                        sx={{ minWidth: 120 }}
                    >
                        {isSubmitting ? "מוסיף..." : "הוסף בעל חנות"}
                    </Button>
                </Stack>
            </DialogActions>
        </Dialog>
    );
}
);

export default AddStoreOwner;