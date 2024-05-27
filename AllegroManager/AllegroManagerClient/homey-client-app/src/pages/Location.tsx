import { useEffect, useState } from 'react';
import { useLocation } from 'react-router-dom';
import './location.css'

export default function Location() {
    const location = useLocation();
    const [path, setPath] = useState("");

    useEffect(() => {
        const handleUrlChange = () => {

            setPath(location.pathname.replace("/", ">"))
        };

        handleUrlChange();
    }, [location]);

    return (<div className="location">
        {path}
    </div>);
}