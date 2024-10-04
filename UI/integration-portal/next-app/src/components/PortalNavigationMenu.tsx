"use client"

import PortalNavigationMenuItem, { NavigationLink } from "./PortalNavigationMenuItem"
import { NavigationMenu, NavigationMenuList } from "./ui/Navigation-Menu"

export interface NavigationMenuProps {
    items: NavigationLink[]
}

const PortalNavigationMenu = ({ items }: NavigationMenuProps) => {

    return (<>
        <NavigationMenu>
            <NavigationMenuList>
                {items.map((item, key) => {
                    return (<PortalNavigationMenuItem key={key} item={item} />)
                })}
            </NavigationMenuList>
        </NavigationMenu>
    </>
    )
}

export default PortalNavigationMenu