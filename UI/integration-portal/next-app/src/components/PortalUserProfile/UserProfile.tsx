import React from 'react';
import { User } from '../PortalMenu/PortalMenu';
import Avatar from '../Avatar/Avatar';

export interface UserProfileProps {
    user: User
}

const UserProfile = ({ user }: UserProfileProps) => {

    return (
        <div className="flex items-center py-2 mr-5">
            <Avatar user={user} />
            <div className="ml-4">
                <div className="text-sm font-bold text-[#00002E]">{user.fullName}</div>
            </div>
        </div>
    );
};

export default UserProfile;
