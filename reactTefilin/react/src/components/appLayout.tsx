import { Outlet } from "react-router-dom";
import Sidebar from "./sidebar";

const AppLayout=()=>
{
    return (
        <>
        <Sidebar/>
          <div>applayout</div>
          <Outlet/>
        </>
    )
}
export default AppLayout;