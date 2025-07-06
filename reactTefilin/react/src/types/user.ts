import { createContext } from "react";

export type User = {
    id: number;
    fullName: string;
    phone: string;
    address: string;
    email: string;
    password: string;
    roleId: number;
}
export type UserContextType = {
    user: User | null;
    setUser: (user: User | null) => void;
}
export const UserContext=createContext<UserContextType>(
    {
        user: null,
        setUser: () => {}
    }
)