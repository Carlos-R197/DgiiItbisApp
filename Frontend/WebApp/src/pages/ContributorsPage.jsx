import { useState, useEffect } from "react"
import axios from "axios"
import { useNavigate } from "react-router-dom"
import { PulseLoader } from "react-spinners"
import LoadingIndicator from "../components/LoadingIndicator"
import { formatIdCard, toTitleCase } from "../utils/utils"

export default function ContributorsPage() {
  const [contributors, setContributors] = useState([])
  const [isLoading, setIsLoading] = useState(true)
  const navigate = useNavigate()

  useEffect(() => {
    const fetchContributors = async () => {
      try {
        const res = await axios.get("/contributors")
        setContributors(res.data)
        setIsLoading(false)
      } catch (err) {
        logger.logError(err.message, err.stack)
        if (err.response.status >= 500) {
          navigate("/server-error")
        }
      }
    }

    fetchContributors()
  }, [])

  const onContributorClicked = (contributor) => {
    const options = { state: { contributorName: contributor.name }}
    navigate(`/tax-receipts/${contributor.rncIdentificationCard}`, options )
  }

  const printStatus = (status) => {
    if (status) {
      return "Activo"
    }
    else {
      return "Inactivo"
    }
  }

  if (isLoading) {
    return <LoadingIndicator/>
  }

  return (
    <div className="p-12 md:p-24 lg:px-36 lg:pt-16 w-full">
      <div className="max-w-3xl w-full m-auto">
        <h2 className="text-3xl font-semibold mb-12">Contribuyentes</h2>
        <table className="styled-table m-auto w-full">
          <thead>
            <tr>
              <th>RncCédula</th>
              <th>Nombre</th>
              <th>Tipo</th>
              <th>Estado</th>
            </tr>
          </thead>
          <tbody>
            {contributors.length > 0 && contributors.map((contributor, index) => (
              <tr className="clickable-row" key={index} onClick={() => onContributorClicked(contributor)}>
                <td>{formatIdCard(contributor.rncIdentificationCard)}</td>
                <td>{toTitleCase(contributor.name)}</td>
                <td>{toTitleCase(contributor.type)}</td>
                <td>{printStatus(contributor.active)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>      
  )
}