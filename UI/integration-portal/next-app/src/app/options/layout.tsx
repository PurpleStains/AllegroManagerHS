'use client';

import React from 'react';
import Link from 'next/link';
import { usePathname } from 'next/navigation';

const activeStyle = 'bg-portal-highlight text-white';
const unactiveStyle = 'bg-transparent text-accent hover:bg-accent/50';

export default function OptionsLayout({
    children,
}: {
    children: React.ReactNode;
}) {
    const pathname = usePathname();

    const links = [
        { href: '/options/main', title: 'Main' },
        { href: '/options/integrations', title: 'Integrations' },
        { href: '/options/status', title: 'Status' },
    ];

    return (
        <div className="container mx-auto p-4 flex">
            {/* Navigation Column */}
            <nav className="w-1/4 border-r pr-4">
                <ul className="space-y-2">
                    {links.map((link, index) => {
                        const isActive = pathname === link.href;
                        return (
                            <li key={index}>
                                <Link href={link.href} className={`block py-2 px-4 rounded-md font-bold ${isActive ? activeStyle : unactiveStyle}`}>
                                        {link.title}
                                </Link>
                            </li>
                        );
                    })}
                </ul>
            </nav>

            {/* Content Column */}
            <main className="w-3/4 pl-4">
                {children}
            </main>
        </div>
    );
}
