import { useEffect, useRef, useState } from "react"
import StandStore from "../stores/standStore";
import type { Stand } from "../types/stand";
import type { User } from "../types/user";
import userStore from "../stores/userStore";
import { observer } from "mobx-react-lite";
import type { StatusCall } from "../types/statusCall";
import ToDoStore from "../stores/toDoStore";
import statusCallStore from "../stores/statusCallStore";
import type { ToDo } from "../types/todo";

const AddStoreOwnerConversation = ({ ownerId }: { ownerId: number }) => {
    const storeOwnerId = useRef<HTMLInputElement>(null)

    const conversationDate = useRef<HTMLInputElement>(null)

    const notes = useRef<HTMLInputElement>(null)
    const [toDos,setToDos] = useState<ToDo[]>([]);
    const image = useRef<HTMLInputElement>(null)
    const [stands, setStands] = useState<Stand[]>([]);
    const [users, setUsers] = useState<User[]>([]);
    const [statusesCall, setstatusesCall] = useState<StatusCall[]>([]);
    const [selectedStand, setSelectedStand] = useState('');
    const [selectedUser, setSelectedUser] = useState('');
    const [selectedStatusCall, setSelectedStatusCall] = useState('');
    const [selectedToDos, setSelectedToDos] = useState<number[]>([]); 
    const [openForm, setOpenForm] = useState(false);
    useEffect(() => {
        const fetchStands = async () => {
            const data = await StandStore.getStandsByOwnerId(ownerId);
            if (data) {
                setStands(data); // עדכון המצב עם הנתונים שהתקבלו
            }
        };
        fetchStands();
    }, [ownerId]);
    
    useEffect(() => {
        const fetchUsers = async () => {
            await userStore.getAllUsers();
            setUsers(userStore.users); // עדכון ה-state לאחר קריאת המשתמשים
        };
        const fetchStatuses = async () => {
            await statusCallStore.getAllStatusesCall()
            setstatusesCall(statusCallStore.statusesCall)
        }
        const fetchToDos = async () => {
        await ToDoStore.getAllToDo();
        setToDos(ToDoStore.toDos); // עדכון ה-state עם המשימות שהתקבלו
    };
        fetchUsers();
        fetchStatuses();
        fetchToDos();
    }, []);
    const handleStandChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
        setSelectedStand(e.target.value);
    };
    const handleUserChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
        setSelectedUser(e.target.value);
    };
    const handleStatusCallChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
        setSelectedStatusCall(e.target.value);
    };
    const handleToDoChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const value = parseInt(e.target.value);
    if (e.target.checked) {
        setSelectedToDos([...selectedToDos, value]); // הוסף את המשימה למערך
    } else {
        setSelectedToDos(selectedToDos.filter(id => id !== value)); // הסר את המשימה מהמערך
    }
};
    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault()
        const data = {
            ownerId: ownerId,
            standId: selectedStand,
            userId: selectedUser,
            statusCallId: selectedStatusCall,
            conversationDate: conversationDate.current?.value,
            notes: notes.current?.value,
            image: image.current?.value,
            selectedToDos: selectedToDos,
        };

        console.log("Data submitted:", data);
        console.log("handleSubmit called to add store owner conversation");
    }

    return (
        <>
            <button onClick={() => setOpenForm(true)}>הוסף שיחה</button>
            {openForm && (<form onSubmit={handleSubmit}>
                <label htmlFor="stands">בחר דוכן:</label>
                <select id="stands" value={selectedStand} onChange={handleStandChange}>
                    <option value="" disabled>בחר...</option>
                    {stands && stands.length > 0 ? (
                        stands.map((stand) => (
                            <option key={stand?.id} value={stand?.id}>
                                {stand?.standId}
                            </option>
                        ))
                    ) : (
                        <option disabled>אין דוכנים זמינים</option>
                    )}
                </select>
                <label htmlFor="stands">המפעיל המתקשר</label>
                <select id="users" value={selectedUser} onChange={handleUserChange}>
                    <option value="" disabled>בחר...</option>
                    {users && users.length > 0 ? (
                        users.map((user) => (
                            <option key={user?.id} value={user?.id}>
                                {user.fullName}-{user?.phone}-{user?.email}
                            </option>

                        ))
                    ) : (
                        <option disabled>אין מפעילים זמינים</option>
                    )}
                </select>


                <label htmlFor="stands">סטטוס השיחה </label>
                <select id="statuses" value={selectedStatusCall} onChange={handleStatusCallChange}>
                    <option value="" disabled>בחר...</option>
                    {statusesCall && statusesCall.length > 0 ? (
                        statusesCall.map((status) => (
                            <option key={status?.id} value={status?.id}>
                                {status.statusName}
                            </option>
                        ))
                    ) : (
                        <option disabled>אין סטטוסים זמינים</option>
                    )}
                </select>
                <input type="date" placeholder="תאריך השיחה" ref={conversationDate} />
                <input type="text" placeholder=" הערות נוספות" ref={notes} />
                <input type="text" placeholder="תמונה " ref={image} />

                <label>בחר משימות:</label>
                <div>
                    {toDos && toDos.length > 0 ? (
                        toDos.map((toDo) => (
                            <div key={toDo.id}>
                                <input
                                    type="checkbox"
                                    value={toDo.id}
                                    onChange={handleToDoChange}
                                />
                                {toDo.toDoName} {/* הנח ש-`taskName` הוא השם של המשימה */}
                            </div>
                        ))
                    ) : (
                        <p>אין משימות זמינות</p>
                    )}
                </div>

                <button type="submit">שלח</button> {/* כפתור לשליחת הטופס */}
            </form>)}

        </>
    )
}
export default observer(AddStoreOwnerConversation);