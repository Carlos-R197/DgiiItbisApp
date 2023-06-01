import { PulseLoader } from "react-spinners"

export default function LoadingIndicator() {
  return (
    <div className="spinner">
      <PulseLoader size={25} color="var(--secondary)" />
    </div>
  )
}