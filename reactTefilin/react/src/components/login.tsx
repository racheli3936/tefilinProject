import axios from "axios";
import { useContext, useEffect, useState, type FormEvent } from "react";
import { useNavigate } from "react-router-dom";
import { UserContext } from "../types/user";

const Login = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');
    const { user, setUser } = useContext(UserContext)
    const navigate = useNavigate();
useEffect(() => {
  console.log('User updated in context:', user);

}, [user]);

    const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        setError('');

        // בדיקה בסיסית אם שדות מלאים
        if (!email || !password) {
            setError('נא למלא את כל השדות');
            return;
        }
        const data = {
            email: email,
            password: password
        }
        try {
            const response = await axios.post('https://localhost:7179/api/Auth/login', data)
            localStorage.setItem('userToken', response.data.token)
            console.log('login sucess', response);
           
            console.log(response.data.user);

             setUser(response.data.user)
              navigate('/home');
           
        }
        catch (error: any) {
            if (error.status >= 400 && error.status < 500) {
                setError('פרטי ההתחברות שגויים, אנא נסה שוב');
                console.log('Login failed:', error);
            }
            else {
                console.error('Login failed:', error);
                setError('התחברות נכשלה, אנא נסה שוב');
            }
        }
        // כאן תוכל להוסיף שליחה לשרת (fetch / axios)
        console.log('Logging in with:', { email, password });

        // איפוס הטופס
        setEmail('');
        setPassword('');
    };

    return (
        <div style={{ maxWidth: '400px', margin: '0 auto' }}>
            <h2>התחברות</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>אימייל:</label>
                    <input
                        type="email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label>סיסמה:</label>
                    <input
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                    />
                </div>
                {error && <p style={{ color: 'red' }}>{error}</p>}
                <button type="submit">התחבר</button>
            </form>
        </div>
    );
}
export default Login;