import '../../pages/AllegroAuthentication/allegroAuth.css';
import { useEffect, useState } from 'react';
import React from 'react';

interface CodeAuthResponse {
    deviceCode: string;
    verificationUriComplete: string;
}
export default function AllegroAuth() {
    const [isAuthenticated, setAuthenticated] = useState(false);

    useEffect(() => { checkAllegroConnection() }, [])

    async function getCode() {

        await fetch(`http://localhost:5195/api/myallegro/AllegroAuthorization/GetCode`)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok ' + response.statusText);
                }
                return response.json();
            })
            .then(async json => {
                console.log(json)
                window.open(json.verificationUriComplete, "_blank")

                // Call authorize with the authenticationCode received from getCode
                await authorize(json.deviceCode);
                setAuthenticated(true);
            })
    };

    async function authorize(code: string) {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ interval: 0, deviceCode: code })
        };

        await fetch(`http://localhost:5195/api/myallegro/AllegroAuthorization/Authorize`, requestOptions)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok ' + response.statusText);
                }
                return response.json();
            })
    };

    async function checkAllegroConnection() {

        await fetch(`http://localhost:5195/api/myallegro/AllegroAuthorization/is-authorized`)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok ' + response.statusText);
                }
                return response.json();
            })
            .then(json => {
                setAuthenticated(json.isAuthorized);
            })
    };

    const authIconStyle = {
        backgroundColor: isAuthenticated ? 'green' : 'red', // Change 'green' and 'red' to desired colors
    };

    return (<div className='container'>
        <table className='table'>
            <thead>
                <tr>
                    <th scope='col'>Service</th>
                    <th scope='col'>State</th>
                    <th scope='col'>Action</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <th>
                        <span >Allegro connection status</span>
                    </th>
                    <th>
                        <div className='authenticated' style={authIconStyle}></div>
                    </th>
                    <th>
                        <button className="button-5" onClick={getCode}>Authorize</button>
                    </th>
                </tr>
            </tbody>
        </table>
    </div>)
}