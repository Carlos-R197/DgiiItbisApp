import './App.css'
import ContributorsPage from "./pages/ContributorsPage"
import Header from "./components/Header"
import axios from "axios"

axios.defaults.baseURL = "https://localhost:7210"

function App() {
  return (
    <>
      <Header />
      <ContributorsPage />
    </>
  )
}

export default App
