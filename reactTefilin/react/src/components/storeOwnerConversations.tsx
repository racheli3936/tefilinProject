import { 
    Dialog, 
    DialogTitle, 
    DialogContent, 
    DialogActions, 
    Button, 
    Typography, 
    Box, 
    Card, 
    CardContent, 
    Chip, 
    Avatar, 
    Divider,
    Stack
} from '@mui/material';
import { useEffect, useState } from 'react';
import { 
    CalendarToday, 
    Person, 
    Store, 
    Notes, 
    Assignment, 
    Phone, 
    Image as ImageIcon 
} from '@mui/icons-material';
import storeOwnerConversationStore from '../stores/storeOwnerConversationStore';
import type { StoreOwnerConversation } from '../types/storeOwnerConversation';
import type { storeOwner } from '../types/storeOwner';
import AddStoreOwnerConversation from './addStoreOwnerConversation';
import { useNavigate, useParams } from 'react-router-dom';

const StoreOwnerConversations = ({ 
//     isOpen, 
//     onClose, 
//     storeOwner 
// }: { 
//     isOpen: boolean, 
//     onClose: any, 
//     storeOwner: storeOwner 
}) => {
    const [conversations, setConversations] = useState<StoreOwnerConversation[]>([]);
    const [loading, setLoading] = useState(false);

    const navigate = useNavigate();
     const {id}=useParams();
    useEffect(() => {
        if (!id) return;

        const getConversations = async () => {
            setLoading(true);
            try {
                await storeOwnerConversationStore.getConversationsByStoreOwnerId(Number(id));
                // מיון השיחות לפי תאריך - הכי חדש קודם
                const sortedConversations = storeOwnerConversationStore.conversationsByStoreOwnerId.sort((a, b) => {
                    const dateA = a.conversationDate ? new Date(a.conversationDate).getTime() : 0;
                    const dateB = b.conversationDate ? new Date(b.conversationDate).getTime() : 0;
                    return dateB - dateA; // מיון יורד - הכי חדש קודם
                });
                setConversations(sortedConversations);
            } catch (error) {
                console.error('Error fetching conversations:', error);
            } finally {
                setLoading(false);
            }
        };

        getConversations();
    }, [id]);

   const ConversationCard = ({ conversation }: { conversation: StoreOwnerConversation }) => (
    <Card 
        variant="outlined" 
        sx={{ 
            mb: 2, 
            borderRadius: 2,
            direction: 'rtl',
            '&:hover': {
                boxShadow: 3,
                transform: 'translateY(-2px)',
                transition: 'all 0.2s ease-in-out'
            }
        }}
    >
        <CardContent>
            <Stack spacing={2}>
                {/* תאריך ושעה */}
                <Box display="flex" alignItems="center" gap={1}>
                    <CalendarToday fontSize="small" color="primary" />
                    <Typography variant="subtitle1" fontWeight="bold">
                        {conversation.conversationDate?.toLocaleString() || 'תאריך לא זמין'}
                    </Typography>
                </Box>

                <Divider />

                {/* פרטי השיחה */}
                <Stack spacing={1.5}>
                    <Box display="flex" alignItems="center" gap={2}>
                        <Box display="flex" alignItems="center" gap={1}>
                            <Person fontSize="small" color="action" />
                            <Typography variant="body2" color="text.secondary">בעל העסק:</Typography>
                            <Typography variant="body2" fontWeight="medium">{conversation.storeOwnerId}</Typography>
                        </Box>

                        <Box display="flex" alignItems="center" gap={1}>
                            <Store fontSize="small" color="action" />
                            <Typography variant="body2" color="text.secondary">עמדה:</Typography>
                            <Typography variant="body2" fontWeight="medium">{conversation.storeStandId}</Typography>
                        </Box>

                        <Box display="flex" alignItems="center" gap={1}>
                            <Person fontSize="small" color="action" />
                            <Typography variant="body2" color="text.secondary">המפעיל שדיבר:</Typography>
                            <Typography variant="body2" fontWeight="medium">{conversation.userId}</Typography>
                        </Box>

                        <Box display="flex" alignItems="center" gap={1}>
                            <Phone fontSize="small" color="action" />
                            <Typography variant="body2" color="text.secondary">סטטוס שיחה:</Typography>
                            <Chip 
                                label={conversation.statusCall?.statusName || 'סטטוס לא זמין'} 
                                size="small" 
                                color="primary" 
                                variant="outlined"
                            />
                        </Box>
                    </Box>
                </Stack>

                {/* הערות */}
                {conversation.notes && (
                    <Box>
                        <Box display="flex" alignItems="center" gap={1} mb={1}>
                            <Notes fontSize="small" color="action" />
                            <Typography variant="body2" color="text.secondary" fontWeight="medium">הערות:</Typography>
                        </Box>
                        <Typography 
                            variant="body2" 
                            sx={{ 
                                backgroundColor: 'grey.50', 
                                p: 1.5, 
                                borderRadius: 1,
                                fontStyle: 'italic'
                            }}
                        >
                            {conversation.notes}
                        </Typography>
                    </Box>
                )}

                {/* משימות לביצוע */}
                {conversation.toDoVisits && conversation.toDoVisits.length > 0 && (
                    <Box>
                        <Box display="flex" alignItems="center" gap={1} mb={1}>
                            <Assignment fontSize="small" color="action" />
                            <Typography variant="body2" color="text.secondary" fontWeight="medium">משימות לביצוע:</Typography>
                        </Box>
                        <Stack direction="row" spacing={1} flexWrap="wrap" sx={{ direction: 'rtl' }}>
                            {conversation.toDoVisits.map((task, index) => (
                                <Chip 
                                    key={index} 
                                    label={task.description} 
                                    size="small" 
                                    color="secondary" 
                                    variant="outlined"
                                />
                            ))}
                        </Stack>
                    </Box>
                )}

                {/* תמונה */}
                {conversation.image && (
                    <Box display="flex" alignItems="center" gap={1}>
                        <ImageIcon fontSize="small" color="action" />
                        <Typography variant="body2" color="text.secondary">תמונה מצורפת</Typography>
                        <Avatar 
                            src={conversation.image} 
                            sx={{ width: 40, height: 40 }}
                            variant="rounded"
                        />
                    </Box>
                )}
            </Stack>
        </CardContent>
    </Card>
);


    return (
       <Box sx={{ p: 3, minHeight: '100vh' }}>
         
            <Typography variant="h4" sx={{ textAlign: 'center', mb: 2 }}>
                שיחות עם בעל העסק
            </Typography>
            <div>
                  <Button 
            onClick={() => navigate(-1)} 
            color="primary" 
            variant="contained" 
            sx={{ 
                direction: 'rtl',
                mt: 3, 
                position: 'sticky', // מיקום דבק
                zIndex: 10 // מבטיח שהכפתור יהיה מעל תוכן אחר
            }}
        >
            חזרה
        </Button>

            </div>
            <AddStoreOwnerConversation ownerId={Number(id)} />

            {loading ? (
                <Typography variant="body2" color="text.secondary">
                    טוען שיחות...
                </Typography>
            ) : conversations.length === 0 ? (
                <Typography variant="body2" color="text.secondary">
                    אין שיחות זמינות
                </Typography>
            ) : (
                <Stack spacing={2}>
                    {conversations.map((conversation, index) => (
                        <ConversationCard key={index} conversation={conversation} />
                    ))}
                </Stack>
            )}

          
        </Box>
    );
};

export default StoreOwnerConversations;