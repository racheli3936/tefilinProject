import { useContext, type ReactNode } from "react";
import { Navigate } from "react-router-dom";
import { UserContext } from "../types/user";

const AuthGuard = ({ children }:{children:ReactNode}) => {
//כאן עשיתי בדיקה האם קיים USER בCONTEXT, 
//אבל אולי באמיתי כדאי לבדוק לפי הTOKEN כדי שיוכל להתחבר מיד בלי סיסמא כל עוד הTOKEN בתוקף
  const {user} = useContext(UserContext);
   let isLoggedIn = false // או כל לוגיקה אחרת
  if (user&&user.id!=0) 
    {
      console.log('there is a user');
      
      isLoggedIn = true; // אם יש משתמש מחובר, נחשב את המשתמש כמחובר
    }
  if (!isLoggedIn) 
  {
    console.log('not login');
    return <Navigate to="/login" replace />;
  }
  return children;
};
export default AuthGuard;
