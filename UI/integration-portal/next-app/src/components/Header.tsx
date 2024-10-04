'use client'

import React from "react"
import PortalNavigationMenu from "./PortalNavigationMenu"
import { NavigationLink } from "./PortalNavigationMenuItem"
import Logout from "./Logout"
import Login from "./Login"
import { useSession } from "next-auth/react"

export interface HeaderProps {
    title: string,
    links?: NavigationLink[],
    logoutAction: () => void
}

const Header = ({ title, links, logoutAction }: HeaderProps) => {
    const { data: session, status } = useSession();

    const navigation = links !== undefined
        ? (
            <PortalNavigationMenu items={links} />
        )
        : <></>;

    return (
        <header className="sticky top-0 flex h-16 items-center gap-2 border-b shadow bg-[#1A2957] px-4 md:px-2">
            <span className="hidden md:flex font-semibold text-xl text-[#FFFFFF] mr-8">{title}</span>
            <nav className="hidden md:flex flex-col gap-6 text-lg font-medium md:flex md:flex-row md:items-center md:gap-1 md:text-sm lg:gap-2">
                {navigation}
            </nav>
            <div className="flex-col ml-auto mr-2">
                <span className="ml-auto sticky mr-2 text-orange-500">{session?.user?.name}</span>
                {session?.user
                    ? <Logout />
                    : <Login />
                }
            </div>
        </header>
    )
}

export default Header