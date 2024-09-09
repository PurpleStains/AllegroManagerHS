import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.css'
import { createBrowserRouter, RouterProvider } from 'react-router-dom'
import Calculations from './pages/Calculations/Calculations.tsx'
import NotFoundPage from './pages/NotFoundPage.tsx'
import HomePage from './pages/HomePage.tsx'
import Orders from './pages/Orders/Orders.tsx'
import AllegroAuth from './pages/AllegroAuthentication/AllegroAuth.tsx'
import 'bootstrap/dist/css/bootstrap.css';

const router = createBrowserRouter([
  {
    path: '/',
    element: <HomePage />,
    errorElement: <NotFoundPage />,
    children: [
      {
        path: 'calculations',
        element: <Calculations />
      },
      {
        path: 'orders',
        element: <Orders />
      },
      {
        path: 'authentication',
        element: <AllegroAuth />
      }
    ]
  },
])


ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode >,
)
