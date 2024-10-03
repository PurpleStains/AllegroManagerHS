import { Session } from 'next-auth'
import Login from '../components/Login'
import Logout from '../components/Logout'
import { useEffect, useState } from 'react'
import { getSession } from 'next-auth/react'

export default function Home() {
  const [session, setSession] = useState<Session | null>();

  useEffect(() => {

    const loadSession = async () => {
      const result = await getSession();
      setSession(result);
    };

    loadSession();
  },[]);

  if (session) {
    return <div>
      <div>Your name is {session.user?.name}</div>
      <div><Logout /> </div>
    </div>
  }
  return (
    <div>
      <Login />
    </div>
  );
}