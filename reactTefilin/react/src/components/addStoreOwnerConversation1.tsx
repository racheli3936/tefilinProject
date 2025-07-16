// import { useEffect, useState } from 'react';
// import { Button, TextField, Box, MenuItem, Select, InputLabel, FormControl } from '@mui/material';
// import storeOwnerConversationStore from '../stores/storeOwnerConversationStore';
// import type { StoreOwnerConversation } from '../types/storeOwnerConversation';
// import standStore from '../stores/standStore';
// import type { Stand } from '../types/stand';
// {/* :אני צריכה שיהיה בטופס:
//         אפשרות לבחירת עמדה מתוך העמדות ששיכות לבעל העסק הזה
// אפשרות לבחירת המפעיל שהתקשר לבעל העסק
//         אפשרות לבחירת תאריך ושעה של השיחה
//         אפשרות לבחירת סטטוס של השיחה והוספת סטטוס חדש
//         אפשרות להוספת תמונה לשיחה
//         אפשרות להוספת הערות לשיחה
//         (אפשרות לבחירה מרובה שיאסף לנתונים בתוך רשימה וכן להוספת משימה חדשה) אפשרות להוספת משימות לביצוע מתוך המשימות הקימות */}
// const AddConversationForm = ({ storeOwnerId }: { storeOwnerId: number }) => {

//     const [newConversation, setNewConversation] = useState<Partial<StoreOwnerConversation>>({
//  storeOwnerId:-1,
//  storeStandId:-1,
//  userId:-1,
//  conversionDate:new Date(),
//  statusCall:{id:-1,statusName:''},
//  notes:'',
//  toDoVisits:[],
//  image:''
//     });
//     const [isFormVisible, setIsFormVisible] = useState(false);
//     const [selectedStore, setSelectedStore] = useState<string>('');
//     const [stands, setStands] = useState<Stand[]>([]);
//     useEffect(() => {
//         const fetchStands = async () => {
//             try {
//                 const result = await standStore.getStandsByOwnerId(1);
//                 setStands(result); // הנחה ש-result הוא מערך
//             } catch (error) {
//                 console.error('Error fetching stands:', error);
//             }
//         };

//         fetchStands();
//     }, []);

//     const handleAddConversation = () => {
//         storeOwnerConversationStore.addConversation(newConversation);
//         setNewConversation({ notes: '', toDoVisits: '', userId: '' }); // Reset form
//         setIsFormVisible(false); // Hide form after adding
//     };

//     const handleImageChange = (event) => {
//         setNewConversation({ ...newConversation, image: event.target.files[0] });
//     };

//     return (
//         <>
//             <Box sx={{ mt: 2 }}>
//                 <Button onClick={() => setIsFormVisible(true)} color="primary" variant="contained">
//                     הוספת משימה
//                 </Button>
//                 {isFormVisible && (
//                     <Box component="form" noValidate autoComplete="off" sx={{ mt: 2 }}>
//                         <FormControl fullWidth margin="normal">
//                             <InputLabel>עמדה</InputLabel>
//                             <Select
//                                 value={newConversation.storeOwnerId}
//                                 onChange={(e) => setSelectedStore(String(e.target.value))}
//                             >
//                                 {stands.map((stand) => (
//                                     <MenuItem key={stand.standId} value={stand.standId}>
//                                         {stand.standId}
//                                     </MenuItem>
//                                 ))}
//                             </Select>
//                         </FormControl>

//                         <FormControl fullWidth margin="normal">
//                             <InputLabel>מפעיל</InputLabel>
//                             <Select
//                                 value={newConversation.operator}
//                                 onChange={(e) => setNewConversation({ ...newConversation, operator: e.target.value })}
//                             >
//                                 {/* כאן תוסיף את המפעילים מתוך הסטור */}
//                                 <MenuItem value="operator1">מפעיל 1</MenuItem>
//                                 <MenuItem value="operator2">מפעיל 2</MenuItem>
//                                 {/* הוסף עוד מפעילים לפי הצורך */}
//                             </Select>
//                         </FormControl>

//                         <TextField
//                             label="תאריך ושעה"
//                             type="datetime-local"
//                             value={newConversation.conversationDate}
//                             onChange={(e) => setNewConversation({ ...newConversation, conversationDate: e.target.value })}
//                             fullWidth
//                             margin="normal"
//                         />

//                         <FormControl fullWidth margin="normal">
//                             <InputLabel>סטטוס</InputLabel>
//                             <Select
//                                 value={newConversation.status}
//                                 onChange={(e) => setNewConversation({ ...newConversation, status: e.target.value })}
//                             >
//                                 {/* כאן תוסיף את הסטטוסים */}
//                                 <MenuItem value="status1">סטטוס 1</MenuItem>
//                                 <MenuItem value="status2">סטטוס 2</MenuItem>
//                                 {/* הוסף עוד סטטוסים לפי הצורך */}
//                             </Select>
//                         </FormControl>

//                         <input
//                             accept="image/*"
//                             type="file"
//                             onChange={handleImageChange}
//                         />

//                         <TextField
//                             label="הערות"
//                             value={newConversation.notes}
//                             onChange={(e) => setNewConversation({ ...newConversation, notes: e.target.value })}
//                             fullWidth
//                             margin="normal"
//                         />

//                         <TextField
//                             label="משימות לביצוע"
//                             value={newConversation.toDoVisits}
//                             onChange={(e) => setNewConversation({ ...newConversation, toDoVisits: e.target.value })}
//                             fullWidth
//                             margin="normal"
//                         />

//                         <Button onClick={handleAddConversation} color="primary" variant="contained">שמור</Button>
//                     </Box>
//                 )}
//             </Box>
//         </>
//     );
// };

// export default AddConversationForm;
