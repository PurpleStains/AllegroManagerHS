import './offerDetails.css'

export default function OfferDetails(props: any) {
    return (
        <div className="offer-details">
            <h2>{props?.offer?.offerName}</h2>
            <img src={props?.offer.productImage} alt="Not found" width={200} height={200} />
            <p>OfferID: {props?.offer?.auctionId}</p>
            <p>EAN: {props?.offer?.EAN}</p>
            <p>Auction Price Gross: {props.offer.auctionPrice}</p>
            <p>Basis Fee: {props.offer.basisFee}</p>
            <p>Buy price Gross: {props.offer.buyPrice}</p>
            <p>Income: {props.offer.income}</p>
            <p>Margin: {props.offer.margin}</p>
            <p>Package Fee: {props.offer.packageFee}</p>
        </div>
    );
}