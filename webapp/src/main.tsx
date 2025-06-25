import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import AppDotPokeNET from './Model/AppDotPokeNET.tsx'


createRoot(document.getElementById('root')!).render(
    <StrictMode>
        <AppDotPokeNET />
    </StrictMode>,
)
