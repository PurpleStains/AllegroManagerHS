'use client'

import { Session } from "next-auth"
import { useEffect, useState } from "react"
import Header from "./Header";
import { MenuItems } from "./MenuLinks/MenuItems";
import { signOutUser } from "../lib/signout";
import { getCurrentUserSession } from "../app/api/auth/session";

const MainNav = () => {
    const [session, setSession] = useState<Session | null>();
    const title = "Integration Portal"
    
    const handleLogout = async () => {
        await signOutUser();
    };

    useEffect(() => {
  
      const loadSession = async () => {
        const result = await getCurrentUserSession();
        setSession(result);
      };
  
      loadSession();
    },[]);

    return (
        <Header
            title={title}
            links={MenuItems()}
            logoutAction={handleLogout} />
    )
}

export default MainNav