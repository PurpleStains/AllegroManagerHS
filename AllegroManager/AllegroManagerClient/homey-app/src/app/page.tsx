"use client";

import { AppBar, Box, Button, Container, IconButton, Toolbar, Typography } from "@mui/material";
import MenuIcon from '@mui/icons-material/Menu';
import Calculations from "../../components/OffersCalculation";
import { ThemeProvider, createTheme } from '@mui/material/styles';

const darkTheme = createTheme({
  palette: {
    mode: 'dark',
  },
});

function LandingPage() {
  return (
    <ThemeProvider theme={darkTheme}>
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static">
        <Toolbar>
          <IconButton
            size="large"
            edge="start"
            color="inherit"
            aria-label="menu"
            sx={{ mr: 2 }}
          >
            <MenuIcon />
          </IconButton>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            Homey&Style
          </Typography>
          <Button color="inherit">Kalkulator</Button>
          <Button color="inherit">Menu</Button>
        </Toolbar>
      </AppBar>
     <Container maxWidth="sx">
        <Calculations/>
    </Container> 
    </Box>
    </ThemeProvider>
  );
}

export default LandingPage;
