import { useEffect, useRef, useState } from "react";
import { observer } from "mobx-react-lite";
import { TextField, Select, MenuItem, FormControl, InputLabel, Button, Checkbox, FormControlLabel, Box, Typography } from "@mui/material";
import StandStore from "../stores/standStore";
import userStore from "../stores/userStore";
import statusCallStore from "../stores/statusCallStore";
import ToDoStore from "../stores/toDoStore";
import storeOwnerConversationStore from "../stores/storeOwnerConversationStore";
import type { Stand } from "../types/stand";
import type { User } from "../types/user";
import type { StatusCall } from "../types/statusCall";
import type { ToDo } from "../types/todo";
import type { StoreOwnerConversation } from "../types/storeOwnerConversation";
import todoVisitStore from "../stores/todoVisitStore";
import type { ToDoVisit } from "../types/toDoVisit";

const AddStoreOwnerConversation = ({ ownerId }: { ownerId: number }) => {
    const conversationDate = useRef<HTMLInputElement>(null);
    const notes = useRef<HTMLInputElement>(null);
    const image = useRef<HTMLInputElement>(null);

    const [toDos, setToDos] = useState<ToDo[]>([]);
    const [stands, setStands] = useState<Stand[]>([]);
    const [users, setUsers] = useState<User[]>([]);
    const [statusesCall, setStatusesCall] = useState<StatusCall[]>([]);
    const [selectedStand, setSelectedStand] = useState('');
    const [selectedUser, setSelectedUser] = useState('');
    const [selectedStatusCall, setSelectedStatusCall] = useState('');
    const [selectedToDos, setSelectedToDos] = useState<{
        [toDoId: number]: {
            source: string;
            destination: string;
            description: string;
        };
    }>({});
    const [openForm, setOpenForm] = useState(false);

    useEffect(() => {
        const fetchStands = async () => {
            const data = await StandStore.getStandsByOwnerId(ownerId);
            if (data) setStands(data);
        };
        fetchStands();
    }, [ownerId]);

    useEffect(() => {
        const fetchAll = async () => {
            await userStore.getAllUsers();
            await statusCallStore.getAllStatusesCall();
            await ToDoStore.getAllToDo();

            setUsers(userStore.users);
            setStatusesCall(statusCallStore.statusesCall);
            setToDos(ToDoStore.toDos);
        };
        fetchAll();
    }, []);

    const handleToDoChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const id = parseInt(e.target.value);
        if (e.target.checked) {
            setSelectedToDos((prev) => ({
                ...prev,
                [id]: { source: "", destination: "", description: "" },
            }));
        } else {
            const updated = { ...selectedToDos };
            delete updated[id];
            setSelectedToDos(updated);
        }
    };

    const handleToDoInputChange = (
        id: number,
        field: "source" | "destination" | "description",
        value: string
    ) => {
        setSelectedToDos((prev) => ({
            ...prev,
            [id]: {
                ...prev[id],
                [field]: value,
            },
        }));
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        const data: Partial<StoreOwnerConversation> = {
            storeOwnerId: ownerId,
            storeStandId: Number(selectedStand),
            userId: Number(selectedUser),
            statusCallId: Number(selectedStatusCall),
            conversationDate: conversationDate.current?.value ? new Date(conversationDate.current.value) : undefined,
            notes: notes.current?.value,
            image: image.current?.value,
        };
        try {

            const newConversation = await storeOwnerConversationStore.addConversation(data);
            console.log("New conversation:", newConversation);

            const toDoVisitsData:Partial<ToDoVisit>[] = Object.entries(selectedToDos).map(([toDoId, fields]) => ({
                toDoId: Number(toDoId),
                storeOwnerConversationId: newConversation.id,
                description: fields.description,
                source: fields.source,
                destination: fields.destination,
            }));
            console.log("ToDoVisits++++++++++++++:", toDoVisitsData);
            console.log("++++++++++++++++++++++++++");
            try {

                todoVisitStore.addTodoVisitList(toDoVisitsData);
                console.log("ToDoVisits added successfully");

            }
            catch (error) {
                console.error("Error adding ToDoVisits:", error);


            }
        }
        catch (error) {
            console.error("Error adding conversation:", error);
        }

    };

    return (
        <>
            <Button variant="contained" onClick={() => setOpenForm(true)}>הוסף שיחה</Button>
            {openForm && (
                <Box component="form" onSubmit={handleSubmit} sx={{ mt: 2, display: 'flex', flexDirection: 'column', gap: 2, maxWidth: 600 }}>
                    <FormControl fullWidth>
                        <InputLabel>בחר דוכן</InputLabel>
                        <Select value={selectedStand} label="בחר דוכן" onChange={(e) => setSelectedStand(e.target.value)}>
                            {stands.map((stand) => (
                                <MenuItem key={stand.id} value={stand.id}>{stand.standId}</MenuItem>
                            ))}
                        </Select>
                    </FormControl>

                    <FormControl fullWidth>
                        <InputLabel>המפעיל המתקשר</InputLabel>
                        <Select value={selectedUser} label="המפעיל" onChange={(e) => setSelectedUser(e.target.value)}>
                            {users.map((user) => (
                                <MenuItem key={user.id} value={user.id}>
                                    {user.fullName} - {user.phone} - {user.email}
                                </MenuItem>
                            ))}
                        </Select>
                    </FormControl>

                    <FormControl fullWidth>
                        <InputLabel>סטטוס השיחה</InputLabel>
                        <Select value={selectedStatusCall} label="סטטוס" onChange={(e) => setSelectedStatusCall(e.target.value)}>
                            {statusesCall.map((status) => (
                                <MenuItem key={status.id} value={status.id}>
                                    {status.statusName}
                                </MenuItem>
                            ))}
                        </Select>
                    </FormControl>

                    <TextField inputRef={conversationDate} type="date" label="תאריך שיחה" InputLabelProps={{ shrink: true }} />
                    <TextField inputRef={notes} label="הערות" fullWidth />
                    <TextField inputRef={image} label="תמונה" fullWidth />

                    <Typography variant="h6">משימות</Typography>
                    {toDos.map((toDo) => (
                        <Box key={toDo.id} sx={{ border: '1px solid #ccc', borderRadius: 1, p: 2, mb: 1 }}>
                            <FormControlLabel
                                control={
                                    <Checkbox
                                        value={toDo.id}
                                        checked={selectedToDos.hasOwnProperty(toDo.id)}
                                        onChange={handleToDoChange}
                                    />
                                }
                                label={toDo.toDoName}
                            />
                            <Box sx={{ display: 'flex', gap: 1, mt: 1 }}>
                                <TextField
                                    label="מקור"
                                    value={selectedToDos[toDo.id]?.source || ""}
                                    onChange={(e) => handleToDoInputChange(toDo.id, "source", e.target.value)}
                                    disabled={!selectedToDos[toDo.id]}
                                    fullWidth
                                />
                                <TextField
                                    label="יעד"
                                    value={selectedToDos[toDo.id]?.destination || ""}
                                    onChange={(e) => handleToDoInputChange(toDo.id, "destination", e.target.value)}
                                    disabled={!selectedToDos[toDo.id]}
                                    fullWidth
                                />
                                <TextField
                                    label="תיאור"
                                    value={selectedToDos[toDo.id]?.description || ""}
                                    onChange={(e) => handleToDoInputChange(toDo.id, "description", e.target.value)}
                                    disabled={!selectedToDos[toDo.id]}
                                    fullWidth
                                />
                            </Box>
                        </Box>
                    ))}

                    <Button type="submit" variant="contained" color="primary">שלח</Button>
                </Box>
            )}
        </>
    );
};

export default observer(AddStoreOwnerConversation);
