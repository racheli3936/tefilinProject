import { Link, useNavigate } from "react-router-dom";
import { useContext } from "react";
import { UserContext } from "../types/user";

const Sidebar = () => {
  const { user, setUser } = useContext(UserContext);
  const navigate = useNavigate();

  const handleLogout = () => {
    localStorage.removeItem("userToken");
    setUser(null);
    navigate("/login");
  };

  return (
    <>
      {/* Sidebar - Always visible */}
      <nav
        style={{
          position: "fixed",
          top: 0,
          left: 0,
          width: "320px",
          height: "100vh",
          backgroundColor: "#ffffff",
          boxShadow: "2px 0 10px rgba(0, 0, 0, 0.1)",
          zIndex: 1000,
          padding: "20px 0",
          direction: "rtl",
          borderRight: "1px solid #e5e7eb",
          overflowY: "auto"
        }}
      >
        {/* Header */}
        <div style={{
          padding: "0 24px 32px 24px",
          borderBottom: "1px solid #e5e7eb"
        }}>
          <h2 style={{
            margin: 0,
            fontSize: "24px",
            fontWeight: "bold",
            color: "#1f2937",
            textAlign: "center"
          }}>
            תפריט ניווט
          </h2>
        </div>

        {/* Navigation Links */}
        <div style={{ padding: "24px 0" }}>
          <Link
            to="/home"
            style={{
              display: "block",
              padding: "16px 24px",
              textDecoration: "none",
              color: "#374151",
              fontSize: "16px",
              fontWeight: "500",
              borderBottom: "1px solid #f3f4f6",
              transition: "all 0.2s ease",
              position: "relative"
            }}
            onMouseEnter={(e) => {
              (e.target as HTMLElement).style.backgroundColor = "#f8fafc";
              (e.target as HTMLElement).style.color = "#2563eb";
              (e.target as HTMLElement).style.paddingRight = "32px";
            }}
            onMouseLeave={(e) => {
              (e.target as HTMLElement).style.backgroundColor = "transparent";
              (e.target as HTMLElement).style.color = "#374151";
              (e.target as HTMLElement).style.paddingRight = "24px";
            }}
          >
            🏠 דף הבית
          </Link>

          <Link
            to="/storeOwner"
            style={{
              display: "block",
              padding: "16px 24px",
              textDecoration: "none",
              color: "#374151",
              fontSize: "16px",
              fontWeight: "500",
              borderBottom: "1px solid #f3f4f6",
              transition: "all 0.2s ease"
            }}
            onMouseEnter={(e) => {
              (e.target as HTMLElement).style .backgroundColor = "#f8fafc";
              (e.target as HTMLElement).style.color = "#2563eb";
              (e.target as HTMLElement).style.paddingRight = "32px";
            }}
            onMouseLeave={(e) => {
              (e.target as HTMLElement).style.backgroundColor = "transparent";
              (e.target as HTMLElement).style.color = "#374151";
              (e.target as HTMLElement).style.paddingRight = "24px";
            }}
          >
            🏪 בעלי עסקים
          </Link>

          <Link
            to="/donors"
            style={{
              display: "block",
              padding: "16px 24px",
              textDecoration: "none",
              color: "#374151",
              fontSize: "16px",
              fontWeight: "500",
              borderBottom: "1px solid #f3f4f6",
              transition: "all 0.2s ease"
            }}
            onMouseEnter={(e) => {
              (e.target as HTMLElement).style.backgroundColor = "#f8fafc";
              (e.target as HTMLElement).style.color = "#2563eb";
              (e.target as HTMLElement).style.paddingRight = "32px";
            }}
            onMouseLeave={(e) => {
              (e.target as HTMLElement).style.backgroundColor = "transparent";
              (e.target as HTMLElement).style.color = "#374151";
              (e.target as HTMLElement).style.paddingRight = "24px";
            }}
          >
            💝 תורמים
          </Link>
        </div>

        {/* User Section */}
        <div style={{
          marginTop: "auto",
          padding: "24px",
          borderTop: "1px solid #e5e7eb",
          backgroundColor: "#f8fafc"
        }}>
          {user?.id != 0 ? (
            <>
              <div style={{
                display: "flex",
                alignItems: "center",
                marginBottom: "16px",
                padding: "12px",
                backgroundColor: "#ffffff",
                borderRadius: "8px",
                boxShadow: "0 1px 3px rgba(0, 0, 0, 0.1)"
              }}>
                <div style={{
                  width: "40px",
                  height: "40px",
                  backgroundColor: "#2563eb",
                  borderRadius: "50%",
                  display: "flex",
                  alignItems: "center",
                  justifyContent: "center",
                  color: "white",
                  fontWeight: "bold",
                  fontSize: "16px",
                  marginLeft: "12px"
                }}>
                  {user?.fullName?.charAt(0)}
                </div>
                <div>
                  <div style={{
                    fontSize: "14px",
                    color: "#6b7280",
                    marginBottom: "2px"
                  }}>
                    שלום,
                  </div>
                  <div style={{
                    fontSize: "16px",
                    fontWeight: "600",
                    color: "#1f2937"
                  }}>
                    {user?.fullName}
                  </div>
                </div>
              </div>
             
              <button
                onClick={handleLogout}
                style={{
                  width: "100%",
                  padding: "12px 16px",
                  backgroundColor: "#dc2626",
                  color: "white",
                  border: "none",
                  borderRadius: "8px",
                  fontSize: "14px",
                  fontWeight: "500",
                  cursor: "pointer",
                  transition: "all 0.2s ease",
                  boxShadow: "0 2px 4px rgba(0, 0, 0, 0.1)"
                }}
                onMouseEnter={(e) => {
                  (e.target as HTMLElement).style.backgroundColor = "#b91c1c";
                  (e.target as HTMLElement).style.transform = "translateY(-1px)";
                }}
                onMouseLeave={(e) => {
                  (e.target as HTMLElement).style.backgroundColor = "#dc2626";
                  (e.target as HTMLElement).style.transform = "translateY(0)";
                }}
              >
                🚪 התנתק
              </button>
            </>
          ) : (
            <Link
              to="/login"
              style={{
                display: "block",
                width: "100%",
                padding: "12px 16px",
                backgroundColor: "#2563eb",
                color: "white",
                textDecoration: "none",
                borderRadius: "8px",
                fontSize: "14px",
                fontWeight: "500",
                textAlign: "center",
                transition: "all 0.2s ease",
                boxShadow: "0 2px 4px rgba(0, 0, 0, 0.1)",
                boxSizing: "border-box"
              }}
              onMouseEnter={(e) => {
                (e.target as HTMLElement).style.backgroundColor = "#1d4ed8";
                (e.target as HTMLElement).style.transform = "translateY(-1px)";
              }}
              onMouseLeave={(e) => {
                (e.target as HTMLElement).style.backgroundColor = "#2563eb";
                (e.target as HTMLElement).style.transform = "translateY(0)";
              }}
            >
              🔐 התחבר
            </Link>
          )}
        </div>
      </nav>
    </>
  );
};

export default Sidebar;