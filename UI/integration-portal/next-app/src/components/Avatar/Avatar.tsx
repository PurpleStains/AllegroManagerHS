import { User } from "../PortalMenu/PortalMenu";

export interface AvatarProps {
    user: User
}

const Avatar = (({ user }: AvatarProps) => {

    const Initials = (name: string) => {
        const splitName = name.trim().split(' ');
        if (splitName.length === 1) {
            return splitName[0][0];
        }

        return `${splitName[0][0]}${splitName[splitName.length - 1][0]}`;
    }

    return (
        <div className="relative inline-block">
            <div className="w-10 h-10 rounded-full bg-[#BDBDBD] flex justify-center items-center">
                <span className="text-lg font-normal text-[#485184]">{user.fullName!.length > 0 ? Initials(user.fullName!) : ''}</span>
            </div>
        </div>
    )
})

export default Avatar