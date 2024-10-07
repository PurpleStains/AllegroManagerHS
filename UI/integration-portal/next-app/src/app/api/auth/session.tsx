"use server"

import { getServerSession } from "next-auth";
import KeycloakProvider from "next-auth/providers/keycloak";

const authOptions = {
    providers: [
      KeycloakProvider({
        clientId: process.env.NEXT_PUBLIC_KEYCLOAK_CLIENT_ID!,
        clientSecret: process.env.NEXT_PUBLIC_KEYCLOAK_CLIENT_SECRET!,
        issuer: process.env.NEXT_PUBLIC_KEYCLOAK_ISSUER!,
      }),
    ],
  };
  
// Function to get session on the server side
export const getAuthSession = async () => {
    const session = await getServerSession(authOptions);
    return session;
};