import { Link } from "react-router-dom";

export default function NotFoundPage() {
  return (
    <div className="w-full h-full text-center py-36">
      <h1 className="text-3xl font-semibold mb-4">404 Página no encontrada</h1>
      <div className="text-md">
        Esta página no existe. Presiona <Link className="text-blue-600 underline" to="/">aqui</Link> para volver
      </div>    
    </div>
  )
}