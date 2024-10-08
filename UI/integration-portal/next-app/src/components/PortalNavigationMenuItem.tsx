"use client"

import Link from "next/link"
import { usePathname } from "next/navigation"
import { NavigationMenuContent, NavigationMenuItem, NavigationMenuLink, NavigationMenuTrigger } from "./ui/Navigation-Menu"

export interface NavigationLink {
    href?: string,
    title: string,
    isActive?: Boolean,
    children?: NavigationLinkChild[]
}

export interface NavigationLinkChild {
    href?: string,
    title: string,
    isActive?: Boolean,
}

export interface NavigationItemProps {
    item: NavigationLink
}

const MenuItemStyles = `
    py-1
    px-3
    rounded-[40px]
    font-bold
    text-base
    text-white
`
const TriggerStyles = `
    h-8
    font-bold
    text-base
    text-white
    rounded-[40px]
    hover:text-white
    data-[active]:text-white
    data-[state=closed]:text-white
`
const MenuContentItemStyles = `
    p-4
    cursor-pointer
    flex
    items-center
    font-bold
    text-base
    text-white
    transition-colors
`
const activeStyle = `bg-portal-highlight hover:bg-portal-highlight data-[state=open]:bg-portal-highlight `
const unactiveStyle = `bg-transparent hover:bg-accent/50 data-[state=open]:bg-accent/50`

const PortalNavigationMenuItem = ({ item }: NavigationItemProps) => {
    const pathname = usePathname()

    const hasToHighlightTrigger = (link: NavigationLink) => {
    
        const anyChildrenActive = link.children?.some(c => c.isActive === true || pathname === c.href)
    
        const isParentActive = link.isActive === true || pathname === link.href;
    
        return anyChildrenActive || isParentActive ? activeStyle : unactiveStyle;
    };

    return item.children === undefined || item.children.length === 0 ?
        <NavigationMenuItem
            className={`${item.isActive ?? pathname === item.href ? activeStyle : unactiveStyle} ${MenuItemStyles}`}
        >
            <Link href={item.href ?? ''} legacyBehavior passHref>
                <NavigationMenuLink>
                    {item.title}
                </NavigationMenuLink>
            </Link>
        </NavigationMenuItem>
        :
        <NavigationMenuItem >
            <NavigationMenuTrigger
                className={`${hasToHighlightTrigger(item)} ${TriggerStyles}`}
            >
                <Link href={item.href ?? ''} legacyBehavior passHref>
                    <span className="text-white">{item.title}</span>
                </Link>
            </NavigationMenuTrigger>
            <NavigationMenuContent className="bg-[#1A2957]">
                <ul className="grid md:w-[200px] lg:w-[300px] border-[#1A2957]">
                    {item.children.map((child, index) => {
                        return (<li key={index}
                            className={`${child.isActive ?? pathname === child.href ? activeStyle : unactiveStyle} 
                            ${index == 0 ? "mt-0" : 'mt-1'}
                            ${MenuContentItemStyles}`}
                        >
                            <Link href={child.href ?? ''} legacyBehavior passHref>
                                <span>{child.title}</span>
                            </Link>
                        </li>)
                    })}
                </ul>
            </NavigationMenuContent>
        </NavigationMenuItem>
}

export default PortalNavigationMenuItem
