import { Outlet } from "react-router-dom";
import Navbar from "./navbar";

const AppLayout=()=>
{
    return (
        <>
        <Navbar/>
          <div>applayout</div>
          <Outlet/>
        </>
    )
}
export default AppLayout;