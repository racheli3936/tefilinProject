import { createBrowserRouter } from "react-router-dom";
import AppLayout from "./components/appLayout";
import Login from "./components/login";
import Home from "./components/home";
import AuthGuard from "./components/authGuard";
import StoreOwner from "./components/storeOwner";
import Donors from "./components/donors";

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
                path: '*',
                element: <div>Page not found</div>

            }
        ]
    }
]);
export default Router;