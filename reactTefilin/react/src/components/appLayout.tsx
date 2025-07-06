import { Outlet } from "react-router-dom";
import Navbar from "./navbar";

const AppLayout=()=>
{
    return (
        <>
        <Navbar/>
          <h1>applayout</h1>
          <Outlet/>
        </>
    )
}
export default AppLayout;