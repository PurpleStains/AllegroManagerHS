import { useEffect, useState } from "react";
import './orders.css';

interface Order {
    id: string;
    email: string;
    firstName: string;
    lastName: string;
    login: string;
    totalToPay: string;
    status: string;
    allegroFee: number;
    margin: number;
    updatedAt: Date;
}

export default function Orders() {

    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState(null);
    const [orders, setOrders] = useState<Order[]>([]);

    useEffect(() => {
        getOrders()
    }, [])

    async function getOrders() {
        setIsLoading(true);
        setError(null);
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' }
        };
        await fetch(`http://localhost:5195/api/myallegro/Orders/orders?limit=${1}&offset=${2}`, requestOptions)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok ' + response.statusText);
                }
                return response.json();
            })
            .then(json => {

                const orders: Order[] = json.orders.map((order: any) => ({
                    ...order,
                    updatedAt: new Date(order.updatedAt) // Parse updatedAt as a Date object
                }));
                setOrders(orders);
            })
            .catch(error => {
                console.error('There has been a problem with your fetch operation:', error);
                setError(error)
            })
            .finally(() => setIsLoading(false));
    };

    return (
        <div className="orders-container">
            <button
                onClick={getOrders}>Get orders
            </button>
            {isLoading && <p>Loading...</p>}
            <table>
                <tr>
                    <th>Email</th>
                    <th>Name</th>
                    <th>Login</th>
                    <th>Total to Pay:</th>
                    <th>Status: </th>
                    <th>Allegro Fee</th>
                    <th>Margin</th>
                    <th>Updated At</th>
                </tr>
                {orders.length > 0 && orders.map(order => (
                    <tr key={order.id}>
                        <td>{order.email}</td>
                        <td>{order.firstName} {order.lastName}</td>
                        <td>{order.login}</td>
                        <td>{order.totalToPay}</td>
                        <td>{order.status}</td>
                        <td>{order.allegroFee}</td>
                        <td>{order.margin}</td>
                        <td>{order.updatedAt.toLocaleString()}</td>
                    </tr>))}
            </table>
        </div>
    );
}