import NextAuth, { AuthOptions } from "next-auth";
import KeycloakProvider from "next-auth/providers/keycloak"

const authOptions: AuthOptions = {
  providers: [
    KeycloakProvider({
      clientId: process.env.NEXT_PUBLIC_KEYCLOAK_CLIENT_ID!,
      clientSecret: process.env.NEXT_PUBLIC_KEYCLOAK_CLIENT_SECRET!,
      issuer: process.env.NEXT_PUBLIC_KEYCLOAK_ISSUER!
    })
  ],
}
const handler = NextAuth(authOptions);
export { handler as GET, handler as POST }