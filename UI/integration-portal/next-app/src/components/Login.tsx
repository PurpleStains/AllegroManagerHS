"use client"
import { signIn } from "next-auth/react";
import { Button } from "./ui/Button";

export default function Login() {
  return <Button className="text-white"  onClick={() => signIn("keycloak")}>
    Signin
  </Button>
}