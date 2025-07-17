import { createBrowserRouter } from "react-router-dom";
import AppLayout from "./components/appLayout";
import Login from "./components/login";
import Home from "./components/home";
import AuthGuard from "./components/authGuard";

import Donors from "./components/donors";
import StoreOwner from "./components/storeOwner";
import StoreOwnerConversations from "./components/storeOwnerConversations";
import StoreOwnerStores from "./components/storeOwneStores";

const Router = createBrowserRouter([
    {
        path: '/login',
        element: <Login />,
        errorElement: 'main error',
        
    },
    {
        path: '/',
        element: <AuthGuard><AppLayout/></AuthGuard>,
       children: [
            {
                path: 'home',
                element: <Home />
            },
            {
                path: 'storeOwner',
                 element: <StoreOwner/>

            },
            {
                path:'donors',
                element: <Donors/>

            },
            {
                path:'storeOwnerConversations/:id',
                element:<StoreOwnerConversations/>
            },
            {
                path: 'stores/:id/:name',
                element: <StoreOwnerStores storeOwner={{
                    id: 0,
                    name: "",
                    address: "",
                    phone: "",
                    email: "",
                    stores: []
                }} onClose={function (): void {
                    throw new Error("Function not implemented.");
                } } />
            },
            {
                path: '*',
                element: <div>Page not found</div>

            }
        ]
    }
]);
export default Router;