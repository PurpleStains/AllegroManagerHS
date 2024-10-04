'use client'

import { NavigationLink } from "../PortalNavigationMenuItem";


export function MenuItems() {

    const links: NavigationLink[] = [
        { href: '/',  title: "Dashboard" },
        { href: '/import',  title: "Import" },
    ]

    return links;
}