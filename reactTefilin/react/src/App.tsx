import './App.css'
import Router from './router'
import { RouterProvider } from 'react-router-dom'
import { UserContext, type User } from './types/user'
import { useState } from 'react';

function App() {
  const initialUser: User = {
    id: 0,
    fullName: '',
    phone: '',
    address: '',
    email: '',
    password: '',
    roleId: 0
  };
  const [user, setUser] = useState<User | null>(initialUser);

  return (
    <>
      <UserContext value={{ user, setUser}}>
        <RouterProvider router={Router} />
      </UserContext>
    </>
  )
}

export default App
