import { Link } from "react-router-dom"

export default function ServerErrorPage() {
  return (
    <div className="w-full h-full text-center py-36">
      <div className="flex justify-between">
        <div className= "m-auto">
          <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="var(--primary)" className="w-36 h-36">
            <path strokeLinecap="round" strokeLinejoin="round" d="M12 9v3.75m-9.303 3.376c-.866 1.5.217 3.374 1.948 3.374h14.71c1.73 0 2.813-1.874 1.948-3.374L13.949 3.378c-.866-1.5-3.032-1.5-3.898 0L2.697 16.126zM12 15.75h.007v.008H12v-.008z" />
          </svg>
        </div>
      </div>
      <h1 className="text-3xl font-semibold mb-4">Error de servidor</h1>
      <div className="text-lg">
        A ocurrido un error en la aplicación <Link className="text-blue-600 underline" to="/">aqui</Link> para volver
      </div>    
    </div>
  )
}