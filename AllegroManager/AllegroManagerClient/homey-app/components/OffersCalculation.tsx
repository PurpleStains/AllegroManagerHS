import { Button, Container, CircularProgress } from "@mui/material";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import { useState } from "react";

const columns: GridColDef[] = [
  { field: 'offerName', headerName: 'Offer Name', width: 400, resizable: true },
  { field: 'auctionId', headerName: 'Acution Id', width: 150, resizable: true},
  { field: 'auctionPrice', headerName: 'Auction Price', },
  { field: 'basisFee', headerName: 'Basis Fee', 
  renderCell: (params) => (
    <span style={{ color: '#ff5722' }}>
      {params.value} PLN
    </span> 
  )},
  { field: 'packageFee', headerName: 'Package Fee',
   renderCell: (params) => (
    <span style={{ color: '#ff5722' }}>
      {params.value} PLN
    </span>
  )},
  { field: 'buyPrice', headerName: 'Buy Price Gross', width: 150},
  { field: 'income', headerName: 'Income',
  renderCell: (params) => (
    <span style={{ color: 'green' }}>
      {params.value.toFixed(2)} PLN
    </span>
  )},
  { field: 'margin', headerName: 'Margin',
  renderCell: (params) => (
    <span style={{ color: 'orange' }}>
      {params.value.toFixed(2)}%
    </span>
  )}
  ];

export default function Calculations() {

  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [data, setData] = useState([]);

  
  const getCalculations = async () => {
    setIsLoading(true);
    setError(null);
    
    await fetch('http://localhost:5195/api/myallegro/Sale/calculateFee'+"?offerId=1")
          .then(response => {
            if (!response.ok) {
              throw new Error('Network response was not ok ' + response.statusText);
            }
            return response.json();
          })
          .then(json => {
            // Assuming 'calculations' is the key in the JSON response that contains the data
            const calculationsArray = json.calculations;
      
            // Add a unique 'id' property to each item if it doesn't already have one
            const dataWithIds = calculationsArray.map((item, index) => ({
              id: index, // Use auctionId or index as a fallback
              offerName: item.offerName,
              auctionId: item.auctionId,
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
      <Container>
        <Button   
          onClick={getCalculations}
          color="secondary"
          variant="contained">Get calculated offers fee
          <CircularProgress 
            size={20}
            color="inherit"
            variant={ isLoading ? 'indeterminate' : 'determinate' }></CircularProgress>
          </Button>
        <DataGrid
        rows={data}
        columns={columns}
        initialState={{
          pagination: {
            paginationModel: {
              pageSize: 20,
            }
          },
        }}
        pageSizeOptions={[20]}
        disableRowSelectionOnClick />
      </Container>
    );
}