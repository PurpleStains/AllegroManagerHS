import { useState } from "react";
import { Button } from "../../../components/ui/Button";

export default function BaselinkerConnection(){
    const [baselinkerStatus, setBaselinker] = useState<'connected' | 'not connected'>('not connected');

    const getStatusClass = (status: 'connected' | 'not connected') =>
        status === 'connected' ? 'text-green-500' : 'text-red-500';

    return (<div className="mb-6 border rounded-lg p-4 shadow-sm">
        <h2 className="text-lg font-semibold mb-2">Allegro</h2>
        <p className={`mb-4 ${getStatusClass(baselinkerStatus)}`}>
          {baselinkerStatus === 'connected' ? 'Connected' : 'Not Connected'}
        </p>
        <Button>
          Connect
        </Button>
      </div>);
}