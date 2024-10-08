import { signOut } from "next-auth/react";
import { Button } from "./ui/Button";

export default async function Logout() {
  return <Button className="text-white" onClick={() => signOut()}>
    Logout
  </Button>
}