import './App.css'
import ContributorsPage from "./pages/ContributorsPage"
import TaxReceiptsPage from "./pages/TaxReceiptsPage"
import Header from "./components/Header"
import Layout from "./components/Layout"
import axios from "axios"
import { Route, Routes } from "react-router-dom"
import NotFoundPage from "./pages/NotFoundPage"

axios.defaults.baseURL = "https://localhost:7210"

function App() {
  return (
    <Routes>
      <Route path="/" Component={Layout}>
        <Route index Component={ContributorsPage}/>
        <Route path="/tax-receipts/:rnc" Component={TaxReceiptsPage}/>
        <Route path="*" Component={NotFoundPage}/>
      </Route>
    </Routes>
  )
}

export default App
