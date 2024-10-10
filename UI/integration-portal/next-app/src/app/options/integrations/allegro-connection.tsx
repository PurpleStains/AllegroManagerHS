import { useState, useEffect } from "react";
import axios from "axios";
import { Button } from "../../../components/ui/Button";

export default function AllegroConnection() {
    const [allegroStatus, setAllegro] = useState(false);
    const [loading, setLoading] = useState(false);

    const getStatusClass = (status) =>
        status ? 'text-green-500' : 'text-red-500';

    useEffect(() => {
        const checkAuthorizationStatus = async () => {
            try {
                const response = await axios.get('http://localhost:5195/api/myallegro/authorization/is-authorized');
                if (response.data) {
                    const { isAuthorized } = response.data;
                    setAllegro(isAuthorized);
                }
            } catch (error) {
                console.error("Failed to check Allegro authorization status", error);
            }
        };
        checkAuthorizationStatus();
    }, []);

    const handleConnect = async () => {
        setLoading(true);
        try {
            const response = await axios.get('http://localhost:5195/api/myallegro/AllegroAuthorization/GetCode');
            if (response.data) {
                const { deviceCode, verificationUriComplete } = response.data;

                window.open("verificationUriComplete", "_blank");
            }
        } catch (error) {
            console.error("Failed to initiate Allegro authorization", error);
        } finally {
            setLoading(false);
        }
    };

    return (
        <div className="mb-6 border rounded-lg p-4 shadow-sm">
            <h2 className="text-lg font-semibold mb-2">Allegro</h2>
            <p className={`mb-4 ${getStatusClass(allegroStatus)}`}>
                {allegroStatus ? 'Connected' : 'Not Connected'}
            </p>
            {!allegroStatus && (
                <Button onClick={handleConnect} disabled={loading}>
                    {loading ? 'Connecting...' : 'Connect'}
                </Button>
            )}
        </div>
    );
}