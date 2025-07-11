import { Link, useNavigate } from "react-router-dom";
import { useContext } from "react";
import { UserContext } from "../types/user";

const Navbar = () => {
  const { user, setUser } = useContext(UserContext);
  const navigate = useNavigate();

  const handleLogout = () => {
    localStorage.removeItem("userToken");
    setUser(null);
    navigate("/login");
  };

  return (
    <nav style={{ backgroundColor: "#f2f2f2", padding: "10px" }}>
      <Link to="/home" style={{ marginRight: "10px" }}>
        דף הבית
      </Link>
      <Link to="/storeOwner" style={{ marginRight: "10px" }}>
        בעלי עסקים
      </Link>
      <Link to="/donors" style={{ marginRight: "10px" }}>
        תורמים
        </Link>
      {user?.id!=0 ? (
        <>
          <span style={{ marginRight: "10px" }}>
            שלום, {user?.fullName}
          </span>
          <button onClick={handleLogout}>התנתק</button>
        </>
      ) : (
        <Link to="/login">התחבר</Link>
      )}
    </nav>
  );
};

export default Navbar;
