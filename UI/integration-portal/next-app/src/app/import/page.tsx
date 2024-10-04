'use client';

import { useState } from 'react';

const ImportPage = () => {
    const [identifiers, setIdentifiers] = useState<string>('');
    const [error, setError] = useState<string | null>(null);
    const [success, setSuccess] = useState<string | null>(null);

    // Function to handle form submission
    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        setError(null);
        setSuccess(null);

        // Split input by newlines or commas to get array of identifiers
        const idArray = identifiers.split(/\s+|,/).filter(Boolean);  // Split by space or comma
        const numericIds = idArray.map(id => Number(id));

        // Check if all identifiers are valid 13-digit numbers
        const isValid = numericIds.every(id => !isNaN(id) && id.toString().length === 11);

        if (!isValid) {
            setError('Please enter only valid 11-digit numeric identifiers.');
            return;
        }

        try {
            // Send POST request to the API
            const response = await fetch('http://localhost:8081/api/myallegro/sale/import', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ Offers: idArray }),
            });

            if (!response.ok) {
                throw new Error('Failed to import identifiers.');
            }

            setSuccess('Identifiers successfully imported!');
            setIdentifiers('');  // Clear the input field after success
        } catch (err) {
            setError((err as Error).message);
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
                <button type="submit" className="bg-blue-500 text-white py-2 px-4 rounded">
                    Submit
                </button>
            </form>
        </div>
    );
};

export default ImportPage;
