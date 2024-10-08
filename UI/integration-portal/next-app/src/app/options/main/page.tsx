'use client'
import { useSession } from "next-auth/react";

export default function MainPage() {
    const { data: session, status } = useSession();
    return (
        <div>
            <h1 className="text-2xl font-bold">Welcome {session?.user?.name}</h1>
            <p>Email: {session?.user?.email}</p>
        </div>
    );
}
