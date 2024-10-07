"use server"

import { getServerSession } from "next-auth";

// Function to get session on the server side
export const getCurrentUserSession = async () => {
    const session = await getServerSession();
    return session;
};