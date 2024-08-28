import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import 'bootstrap/dist/css/bootstrap.min.css';
import { Home } from './pages/Pessoa/Home.tsx'
import {createBrowserRouter,RouterProvider,} from "react-router-dom";
import { Sorteio } from './pages/Sorteio/Index.tsx';

const router = createBrowserRouter([
  {
    path: "/",
    element: <Home />,
    
  },
  {
    path: "/sorteio",
    element: <Sorteio />,
    
  },
]);

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <RouterProvider router={router} />
  </StrictMode>,
)
