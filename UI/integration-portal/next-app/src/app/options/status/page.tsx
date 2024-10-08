'use client';

import React from 'react';

export default function StatusPage() {
    // Mock data for statistics
    const allegroStats = {
        activeOffers: 120,
        offersCount: 200,
        notIntegratedOffers: 30,
        incompleteOffers: 10,
    };

    const baselinkerStats = {
        integratedProducts: 150,
    };

    return (
        <div className="container mx-auto p-4 space-y-6">
            {/* Allegro Container */}
            <div className="border rounded-lg p-4 shadow-sm">
                <h2 className="text-xl font-semibold mb-4">Allegro</h2>
                <div className="grid grid-cols-2 gap-4">
                    <div className="flex flex-col">
                        <span className="text-gray-500">Active Offers Count:</span>
                        <span className="text-lg font-bold">{allegroStats.activeOffers}</span>
                    </div>
                    <div className="flex flex-col">
                        <span className="text-gray-500">Offers Count:</span>
                        <span className="text-lg font-bold">{allegroStats.offersCount}</span>
                    </div>
                    <div className="flex flex-col">
                        <span className="text-gray-500">Not Integrated Offers:</span>
                        <span className="text-lg font-bold">{allegroStats.notIntegratedOffers}</span>
                    </div>
                    <div className="flex flex-col">
                        <span className="text-gray-500">Incomplete Offers Count:</span>
                        <span className="text-lg font-bold">{allegroStats.incompleteOffers}</span>
                    </div>
                </div>
            </div>

            {/* BaseLinker Container */}
            <div className="border rounded-lg p-4 shadow-sm">
                <h2 className="text-xl font-semibold mb-4">BaseLinker</h2>
                <div className="flex flex-col">
                    <span className="text-gray-500">Integrated Products:</span>
                    <span className="text-lg font-bold">{baselinkerStats.integratedProducts}</span>
                </div>
            </div>
        </div>
    );
}
