import { Outlet } from 'react-router-dom';
import './body.css'

export default function Body() {
    return (
        <div className="body-container">
            <Outlet />
        </div>
    );
}