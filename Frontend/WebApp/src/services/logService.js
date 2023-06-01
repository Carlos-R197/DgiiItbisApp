import axios from "axios";
import { format } from "date-fns";

const logger = {}
logger.logError = (message, stackTrace) => {
  const logData = {
    dateTime: format(new Date(), "yyyy-MM-dd'T'HH:mm:ss"),
    msg: message,
    stackTrace: stackTrace
  }
  axios.post("/error-logs", logData)
}

export default logger