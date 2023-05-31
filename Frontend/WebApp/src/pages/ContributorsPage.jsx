import { useState, useEffect } from "react"
import axios from "axios"
import "./ContributorsPage.css"

export default function ContributorsPage() {
  const [contributors, setContributors] = useState([])

  useEffect(() => {
    const fetchContributors = async () => {
      const res = await axios.get("/contributors")
      setContributors(res.data)
    }

    fetchContributors()
  }, [])

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

  return (
    <div className="p-12 md:p-24 lg:px-36 lg:pt-16 w-full">
      <div className="max-w-3xl w-full m-auto">
        <h2 className="text-3xl font-semibold mb-12">Contribuyentes</h2>
        <table className="styled-table m-auto w-full">
          <thead>
            <tr>
              <th>RncCedula</th>
              <th>Nombre</th>
              <th>Tipo</th>
              <th>Estado</th>
            </tr>
          </thead>
          <tbody>
            {contributors.length > 0 && contributors.map((item, index) => (
              <tr key={index}>
                <td>{item.rncIdentificationCard}</td>
                <td>{toTitleCase(item.name)}</td>
                <td>{toTitleCase(item.type)}</td>
                <td>{printStatus(item.active)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>      
  )
}