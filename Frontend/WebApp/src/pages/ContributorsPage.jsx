import { useState, useEffect } from "react"
import axios from "axios"
import { useNavigate } from "react-router-dom"
import { PulseLoader } from "react-spinners"

export default function ContributorsPage() {
  const [contributors, setContributors] = useState([])
  const [isLoading, setIsLoading] = useState(true)
  const navigate = useNavigate()

  useEffect(() => {
    const fetchContributors = async () => {
      const res = await axios.get("/contributors")
      setContributors(res.data)
      setIsLoading(false)
    }

    fetchContributors()
  }, [])

  const onContributorClicked = (contributor) => {
    navigate(`/tax-receipts/${contributor.rncIdentificationCard}`)
  }

  const printStatus = (status) => {
    if (status) {
      return "Activo"
    }
    else {
      return "Inactivo"
    }
  }

  const toTitleCase = (title) => {
    title = title.toLowerCase()
    const words = title.split(' ')
    for (let i = 0; i < words.length; i++) {
      words[i] = words[i].charAt(0).toUpperCase() + words[i].slice(1)
    }
    title = words.join(' ')
    return title
  }

  if (isLoading) {
    return (
      <div className="spinner">
        <PulseLoader size={25} color="#36d7b7" />
      </div>
    )
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
                <td>{contributor.rncIdentificationCard}</td>
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