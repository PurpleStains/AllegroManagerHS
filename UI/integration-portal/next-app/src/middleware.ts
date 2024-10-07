import { NextRequest, NextResponse } from "next/server";
import { getToken } from "next-auth/jwt";

export async function middleware(req: NextRequest) {
    const token = await getToken({ req, secret: process.env.NEXTAUTH_SECRET });
    console.log("Token "+ token);
    if (!token) {
      // If no token, redirect to the login page
      return NextResponse.redirect(new URL("/", req.url));
    }
  
    // If token exists, continue to the requested page
    return NextResponse.next();
  }
  
export const config = {
  matcher: ["/import"], // Add paths that require authentication
};
