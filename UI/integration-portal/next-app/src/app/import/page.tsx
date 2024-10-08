'use client';

import { useState } from 'react';
import { importIdentifiers } from '../../services/saleService';
import { Button } from '../../components/ui/Button';

export default function ImportPage() {
    const [identifiers, setIdentifiers] = useState<string>('');
    const [error, setError] = useState<string | null>(null);
    const [success, setSuccess] = useState<string | null>(null);

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        setError(null);
        setSuccess(null);

        const idArray = identifiers.split(/\s+|,/).filter(Boolean);  // Split by space or comma
        const numericIds = idArray.map(id => Number(id));

        const isValid = numericIds.every(id => !isNaN(id) && id.toString().length === 11);

        if (!isValid) {
            setError('Please enter only valid 11-digit numeric identifiers.');
            return;
        }

        const result = await importIdentifiers(idArray);

        if (result.success) {
            setSuccess(result.message);
            setIdentifiers('');
        } else {
            setError(result.message);
        }
    };

    return (
        <div className="container mx-auto p-6">
            <h1 className="text-2xl mb-4">Import Identifiers</h1>
            <form onSubmit={handleSubmit} className="flex flex-col space-y-4">
                <textarea
                    value={identifiers}
                    onChange={(e) => setIdentifiers(e.target.value)}
                    placeholder="Enter 11-digit numeric identifiers (comma or newline separated)"
                    rows={5}
                    className="border p-2 rounded"
                />
                {error && <p className="text-red-500">{error}</p>}
                {success && <p className="text-green-500">{success}</p>}
                <Button type="submit" className="py-2 px-4 rounded">
                    Submit
                </Button>
            </form>
        </div>
    );
};