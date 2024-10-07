'use client'

import { NavigationLink } from "../PortalNavigationMenuItem";


export function MenuItems() {

    const links: NavigationLink[] = [
        { href: '/dashboard',  title: "Dashboard" },
        { href: '/import',  title: "Import" },
    ]

    return links;
}