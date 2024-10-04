"use server"

import { signOut } from "next-auth/react"


export async function signOutUser() {
	return await signOut({ })
}