"use server"

import { getServerSession } from "next-auth";
import { authOptions } from "./[...nextauth]/route";

// Function to get session on the server side
export const getCurrentUserSession = async () => {
    const session = await getServerSession(authOptions);
    return session;
};