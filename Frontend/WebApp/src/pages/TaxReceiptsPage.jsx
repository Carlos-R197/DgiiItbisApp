import { useState, useEffect } from "react"
import axios, { AxiosError } from "axios"
import { Link, useParams, useNavigate, useLocation } from "react-router-dom"
import { PulseLoader } from "react-spinners"
import { format } from "date-fns"
import logger from "../services/logService"
import LoadingIndicator from "../components/LoadingIndicator"
import { formatIdCard, toTitleCase } from "../utils/utils"

export default function TaxReceiptsPage() {
  const [receipts, setReceipts] = useState([])
  const [isLoading, setIsLoading] = useState(true)
  const {rnc} = useParams()
  const location = useLocation()
  const navigate = useNavigate()

  useEffect(() => {
    const fetchReceipts = async () => {
      try {
        const res = await axios.get(`/tax-receipts/${rnc}`)
        setReceipts(res.data)
        setIsLoading(false)
      } catch (err) {
        logger.logError(err.message, err.stack)
        if (err.response.status === 404) {
          navigate("/not-found")
        } else if (err.response.status >= 500) {
          navigate("/server-error")
        }
      }
    }

    fetchReceipts()
  }, [])

  const getAsCurrency = (amount) => {
    const options = {
      style: "currency",
      currency: "DOP",
      minimumFractionDigits: 2
    }
    const formatter = new Intl.NumberFormat("es-DO", options)
    return formatter.format(amount)
  }

  const calculateTotal = () => {
    let sum = 0
    receipts.forEach(receipt => {
      sum += receipt.itbis18
    })
    return getAsCurrency(sum)
  }

  if (isLoading) {
    return <LoadingIndicator/>
  }
  
  return (
    <div className="p-12 md:p-24 lg:px-36 lg:pt-16 w-full">
      <div className="max-w-3xl w-full m-auto">
        <h2 className="text-3xl font-semibold mb-12">Comprobantes fiscales de {toTitleCase(location.state.contributorName)}</h2>
        <table className="styled-table m-auto w-full">
          <thead>
            <tr>
              <th>RncCédula</th>
              <th>NCF</th>
              <th>Cantidad</th>
              <th>Itbis18</th>
            </tr>
          </thead>
          <tbody>
            {receipts.length > 0 && receipts.map((receipt, index) => (
              <tr key={index}>
                <td>{formatIdCard(receipt.rncIdentificationCard)}</td>
                <td>{receipt.ncf}</td>
                <td>{getAsCurrency(receipt.amount)}</td>
                <td>{getAsCurrency(receipt.itbis18)}</td>
              </tr>
            ))}
          </tbody>
        </table>
        {receipts.length === 0 && !isLoading && (
          <div className="text-center">No existen comprobantes para este contribuyente</div>
        )}
        <div className="flex mt-3 justify-between">
          <Link className="bg-gray-300 rounded-3xl p-2" to="/">
            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="w-7 h-7">
              <path strokeLinecap="round" strokeLinejoin="round" d="M10.5 19.5L3 12m0 0l7.5-7.5M3 12h18" />
            </svg>
          </Link>
          {receipts.length > 0 && (
            <div className="font-semibold text-xl pt-1 font-serif">
              Total Itbis: {calculateTotal()}
            </div>
          )}
        </div>
      </div>
    </div>      
  )
}