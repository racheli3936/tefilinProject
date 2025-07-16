import { Dialog, DialogTitle, DialogContent, DialogActions, Button, Typography } from '@mui/material';
import { useEffect, useState } from 'react';
import storeOwnerConversationStore from '../stores/storeOwnerConversationStore';
import type { StoreOwnerConversation } from '../types/storeOwnerConversation';
import type { storeOwner } from '../types/storeOwner';
import AddStoreOwnerConversation from './addStoreOwnerConversation';
const StoreOwnerConversations = ({ isOpen, onClose, storeOwner }: { isOpen: boolean, onClose: any, storeOwner: storeOwner }) => {
    const [conversations, setConversations] = useState<StoreOwnerConversation[]>([]);

    useEffect(() => {
        if (!storeOwner) return; // בדוק אם storeOwner קיים

        const getConversations = async () => {
            await storeOwnerConversationStore.getConversationsByStoreOwnerId(storeOwner.id);
            setConversations(storeOwnerConversationStore.conversationsByStoreOwnerId);
        };

        getConversations();
    }, [storeOwner]); // הוספת תלות

    return (
        <Dialog open={isOpen} onClose={onClose}>
            <DialogTitle>שיחות עם בעל העסק</DialogTitle>
           <AddStoreOwnerConversation ownerId={storeOwner?.id}/>
            <DialogContent>
                {conversations.length === 0 ? (
                    <Typography variant="body2" color="text.secondary">
                        אין שיחות זמינות
                    </Typography>
                ) : (
                    conversations.map((conversation, index) => (
                        <div key={index}>
                            <Typography variant="body2">
                                {conversation.conversionDate?.toLocaleString() || 'תאריך לא זמין'}
                            </Typography>
                            <span>בעל העסק: {conversation.storeOwnerId}</span>
                            <span>עמדה: {conversation.storeStandId}</span>
                            <span>הערות: {conversation.notes}</span>
                            <span>משימות לביצוע: {conversation.toDoVisits.join(", ")}</span>
                            <span>המפעיל שדיבר: {conversation.userId}</span>
                            <span>סטטוס שיחה: {conversation.statusCall?.statusName || 'סטטוס לא זמין'}</span>
                            <span>תמונה: {conversation.image}</span>
                        </div>
                    ))
                )}
            </DialogContent>
            <DialogActions>
                <Button onClick={onClose} color="primary">
                    סגור
                </Button>
            </DialogActions>
        </Dialog>
    );
};
export default StoreOwnerConversations;