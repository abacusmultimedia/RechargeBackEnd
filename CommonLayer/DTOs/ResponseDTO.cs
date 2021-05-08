using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
    public class ResponseDTO<T> where T : class
    {
        public ResponseDTO()
        {
            statusCode = 200;
            message = string.Empty;
            isSuccessfull = true;
            messageType = "Success";
            errorMessage = string.Empty;
            errorStackTrace = string.Empty;
        }

        public int statusCode { get; set; }
        public string message { get; set; }
        public bool isSuccessfull { get; set; }
        public string errorMessage { get; set; }
        public string errorStackTrace { get; set; }
        public string messageType { get; set; }
        public dynamic dynamicResult { get; set; }
    }
}
