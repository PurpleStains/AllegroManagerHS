import UserProfile from "../PortalUserProfile/UserProfile"
import { Button } from "../ui/Button"

import { LogOutIcon } from "lucide-react"

import { DropdownMenu,
    DropdownMenuContent,
    DropdownMenuItem,
    DropdownMenuLabel,
    DropdownMenuSeparator,
    DropdownMenuTrigger } 
    from "../ui/Dropdown-Menu"
import Avatar from "../Avatar/Avatar"

export interface User {
    fullName?: string,
    email?: string
}

export interface MenuItem {
    label: string,
    icon?: JSX.Element,
    onClick: () => void
}

export interface PortalMenuProps {
    user: User,
    menuItems?: MenuItem[]
    logout: () => void,
}

const PortalMenu = ({
    user,
    menuItems,
    logout
}: PortalMenuProps) => {

    const renderAvatar = (
        <Button variant="secondary" size="icon" className="rounded-full">
            <Avatar user={user} />
        </Button>)

    const renderUserDetails = (
        <DropdownMenuLabel>
            <UserProfile user={user} />
        </DropdownMenuLabel>)

    const renderMenuItems = menuItems !== undefined
        ? menuItems
            .map((item, index) => (
                <DropdownMenuItem key={index} onClick={item.onClick}>
                    {item.icon && <span className="mr-2">{item.icon}</span>}
                    <DropdownMenuLabel className="font-normal text-base">
                        {item.label}
                    </DropdownMenuLabel>
                </DropdownMenuItem>
            ))
        : <></>;

    const renderLogout = (
        <DropdownMenuItem onClick={logout}>
            <LogOutIcon />
            <DropdownMenuLabel className="font-normal text-base">
                Logout
            </DropdownMenuLabel>
        </DropdownMenuItem>)

    return (
        <DropdownMenu>
            <DropdownMenuTrigger asChild>
                {renderAvatar}
            </DropdownMenuTrigger>
            <DropdownMenuContent align="end" className="px-3 py-2 bg-white rounded-md shadow-xl">
                {renderUserDetails}
                <DropdownMenuSeparator />
                {renderMenuItems}
                <DropdownMenuSeparator />
                {renderLogout}
            </DropdownMenuContent>
        </DropdownMenu>
    )
}

export default PortalMenu