using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuthSystem.Application.DTOs
{

    public class ServiceResponse
    {
        public bool Successful { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public ServiceResponse()
        {
            Message = string.Empty; 
            Successful = false;
            StatusCode = (int)HttpStatusCode.BadRequest;
        }

        public ServiceResponse(string message, bool successful = false, int statusCode= (int)HttpStatusCode.BadRequest)
        {
            Message = message;
            Successful = successful;
            StatusCode = statusCode;
        }
    }

    public class ServiceResponse<T> : ServiceResponse
    {
        public T Response { get; set; }

        public ServiceResponse(string message, bool successful = false, int statusCode = (int)HttpStatusCode.BadRequest, T response = default)
            : base(message, successful, statusCode)
        {
            Response = response;
        }
    }

}
