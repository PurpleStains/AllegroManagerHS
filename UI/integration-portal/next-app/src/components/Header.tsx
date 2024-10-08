'use client'

import React from "react"
import PortalNavigationMenu from "./PortalNavigationMenu"
import { NavigationLink } from "./PortalNavigationMenuItem"
import Login from "./Login"
import { signOut, useSession } from "next-auth/react"
import PortalMenu, { MenuItem, User } from "./PortalMenu/PortalMenu"

export interface HeaderProps {
    title: string,
    links?: NavigationLink[]
    menuItems?: MenuItem[]
}

const Header = ({ title, links, menuItems }: HeaderProps) => {
    const { data: session, status } = useSession();

    const navigation = links !== undefined
        ? (
            <PortalNavigationMenu items={links} />
        )
        : <></>;
    
    const user: User = {
        fullName: session?.user?.name!,
        email: session?.user?.email!
    }


    return (
        <header className="sticky top-0 flex h-16 items-center gap-2 border-b shadow bg-portal px-4 md:px-2">
            <span className="hidden md:flex font-semibold text-xl text-foreground mr-8">{title}</span>
            <nav className="hidden md:flex flex-col gap-6 text-lg font-medium md:flex md:flex-row md:items-center md:gap-1 md:text-sm lg:gap-2">
                {navigation}
            </nav>
            <div className="flex-col ml-auto mr-2">
                <span className="ml-auto sticky mr-2 text-secondary-foreground">{session?.user?.name}</span>
                {session?.user
                    ? <PortalMenu user={user} menuItems={menuItems} logout={signOut} />
                    : <Login />
                }
            </div>
        </header>
    )
}

export default Header