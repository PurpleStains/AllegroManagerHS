"use client"

import {Inter} from "next/font/google";
import "../styles/globals.css";
import {SessionProvider} from "next-auth/react";
import { cn } from "../lib/Utils";
import MainNav from "../components/MainNav";

const fontSans = Inter({subsets: ["latin"], variable: "--font-sans"});

export default function RootLayout({
                                       children,
                                   }: Readonly<{
    children: React.ReactNode;
}>) {
    return (
        <html lang="en" suppressHydrationWarning>        
        <body className={cn(
            "min-h-screen bg-background font-sans antialiased",
            fontSans.variable
        )}>
        <SessionProvider>
            <MainNav></MainNav>
            <main>
                {children}
            </main>
            {/* <MainFooter></MainFooter> */}
        </SessionProvider>
        </body>
        </html>
    );
}
