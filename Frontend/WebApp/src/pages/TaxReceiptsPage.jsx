import { useState, useEffect } from "react"
import axios from "axios"
import { Link, useParams } from "react-router-dom"

export default function TaxReceiptsPage() {
  const [receipts, setReceipts] = useState([])
  const {rnc} = useParams()

  useEffect(() => {
    const fetchReceipts = async () => {
      try {
        const res = await axios.get(`/tax-receipts/${rnc}`)
        setReceipts(res.data)
      } catch (err) {
        if (err.response.status === 404) {
          alert("rnc doesn't exist")
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

  return (
    <div className="p-12 md:p-24 lg:px-36 lg:pt-16 w-full">
      <div className="max-w-3xl w-full m-auto">
        <h2 className="text-3xl font-semibold mb-12">Comprobantes fiscales</h2>
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
                <td>{receipt.rncIdentificationCard}</td>
                <td>{receipt.ncf}</td>
                <td>{getAsCurrency(receipt.amount)}</td>
                <td>{getAsCurrency(receipt.itbis18)}</td>
              </tr>
            ))}
          </tbody>
        </table>
        <div className="flex mt-3 justify-between">
          <Link className="bg-gray-300 rounded-3xl p-2" to="/">
            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="w-7 h-7">
              <path strokeLinecap="round" strokeLinejoin="round" d="M10.5 19.5L3 12m0 0l7.5-7.5M3 12h18" />
            </svg>
          </Link>
          <div className="font-semibold text-xl pt-1 ">
            Total Itbis: {calculateTotal()}
          </div>
        </div>
      </div>
    </div>      
  )
}