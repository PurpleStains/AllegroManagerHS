import './navbar.css'
import { NavLink } from "react-router-dom";

export default function Navbar() {
    return (
        <div className="navbar">
            <NavLink to="">Home</NavLink>
            <NavLink to="calculations">Calculations</NavLink>
            <NavLink to="orders">Orders</NavLink>
            <NavLink to="authentication">Allegro Authencitaction</NavLink>
        </div>
    );
}