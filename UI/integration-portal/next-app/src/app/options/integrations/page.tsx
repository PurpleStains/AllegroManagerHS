'use client';

import React, { useState } from 'react';
import { Button } from '../../../components/ui/Button';

export default function IntegrationsPage() {
  const [baseLinkerStatus, setBaselinker] = useState<'connected' | 'not connected'>('not connected');
  const [allegroStatus, setAllegro] = useState<'connected' | 'not connected'>('not connected');

  const handleBaseLinkerConnect = () => {
    console.log('BaseLinker connect method called');
    setBaselinker(baseLinkerStatus === 'connected' ? 'not connected' : 'connected');
    // Add API call logic here
  };

  const handleAllegroConnect = () => {
    console.log('Allegro connect method called');
    setAllegro(allegroStatus === 'connected' ? "not connected" : "connected");
    // Add API call logic here
  };

  const getStatusClass = (status: 'connected' | 'not connected') =>
    status === 'connected' ? 'text-green-500' : 'text-red-500';

  return (
    <div className="container mx-auto p-4">
      <h1 className="text-2xl font-bold mb-4">Integrations</h1>
      
      <div className="mb-6 border rounded-lg p-4 shadow-sm">
        <h2 className="text-lg font-semibold mb-2">BaseLinker</h2>
        <p className={`mb-4 ${getStatusClass(baseLinkerStatus)}`}>
          {baseLinkerStatus === 'connected' ? 'Connected' : 'Not Connected'}
        </p>
        <Button onClick={handleBaseLinkerConnect}>
          Connect
        </Button>
      </div>

      <div className="mb-6 border rounded-lg p-4 shadow-sm">
        <h2 className="text-lg font-semibold mb-2">Allegro</h2>
        <p className={`mb-4 ${getStatusClass(allegroStatus)}`}>
          {allegroStatus === 'connected' ? 'Connected' : 'Not Connected'}
        </p>
        <Button onClick={handleAllegroConnect}>
          Connect
        </Button>
      </div>
    </div>
  );
};
