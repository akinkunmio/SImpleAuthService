using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuthSystem.Application.DTOs
{
  
        public class ServiceResponse
        {
            public bool Successful { get; set; }
            public string Message { get; set; }
            public ServiceResponse()
            {
                Message = string.Empty; // Default value for Message
                Successful = false; // Default value for Successful
            }

            public ServiceResponse(string message, bool successful = false)
            {
                Message = message;
                Successful = successful;
            }
        }

        public class ServiceResponse<T> : ServiceResponse
        {
            public T Response { get; set; }

            public ServiceResponse(string message, bool successful = false, T response = default)
                : base(message, successful)
            {
                Response = response;
            }
        }
    
}
