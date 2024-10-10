'use client';

import React from 'react';
import AllegroConnection from './allegro-connection';
import BaselinkerConnection from './baselinker-connection';

export default function IntegrationsPage() {

  return (
    <div className="container mx-auto p-4">
      <h1 className="text-2xl font-bold mb-4">Integrations</h1>
      <BaselinkerConnection />
      <AllegroConnection />
    </div>
  );
};
