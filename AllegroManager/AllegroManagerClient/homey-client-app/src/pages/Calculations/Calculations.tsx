import { useEffect, useState } from "react";
import OfferDetails from "../Offers/OfferDetails";

export default function Calculations() {

    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState(null);
    const [data, setData] = useState([]);

    useEffect(() => {
        getCalculations()
    }, [])

    async function getCalculations() {
        setIsLoading(true);
        setError(null);

        await fetch(`http://localhost:5195/api/myallegro/Sale/calculateFee?offerId=${15044779268}`)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok ' + response.statusText);
                }
                return response.json();
            })
            .then(json => {
                const calculationsArray = json.calculations;

                const dataWithIds = calculationsArray.map((item, index) => ({
                    id: index,
                    offerName: item.offerName,
                    productImage: item.productImage,
                    auctionId: item.auctionId,
                    EAN: item.productEAN,
                    auctionPrice: item.feeDetails.auctionPrice,
                    basisFee: item.feeDetails.basisFee,
                    packageFee: item.feeDetails.packageFee,
                    buyPrice: item.feeDetails.buyPrice,
                    income: item.feeDetails.income,
                    margin: item.feeDetails.margin
                }));

                console.log(calculationsArray)
                setData(dataWithIds);
            })
            .catch(error => {
                console.error('There has been a problem with your fetch operation:', error);
                setError(error)
            })
            .finally(() => setIsLoading(false));
    };

    return (
        <div className="calculations-container">
            <button
                onClick={getCalculations}>Get calculated offers fee
            </button>
            {data.length > 0 && <OfferDetails offer={data[0]} />}
        </div>
    );
}