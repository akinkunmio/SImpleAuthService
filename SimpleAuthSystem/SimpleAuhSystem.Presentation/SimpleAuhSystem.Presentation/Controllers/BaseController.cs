using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleAuthSystem.Application.DTOs;
using System.Net;

namespace SimpleAuhSystem.Presentation.Controllers
{
    [Route("api/[controller]"), ApiController]
    public abstract class BaseController : ControllerBase
    {
        [NonAction] public IActionResult ServiceResponse<T>(ServiceResponse<T> serviceResponse) => Response(serviceResponse);

        [NonAction] public IActionResult ServiceResponse(ServiceResponse serviceResponse) => Response(serviceResponse);

        [NonAction]
        private new IActionResult Response(ServiceResponse serviceResponse)
        {
            // Fix: Add a StatusCode property to ServiceResponse class  
            var result = serviceResponse.StatusCode switch
            {
                (int)HttpStatusCode.OK => Ok(serviceResponse),
                (int)HttpStatusCode.Created => StatusCode(StatusCodes.Status201Created, serviceResponse),
                (int)HttpStatusCode.BadRequest => BadRequest(serviceResponse),
                (int)HttpStatusCode.Unauthorized => StatusCode(StatusCodes.Status401Unauthorized, serviceResponse),
                (int)HttpStatusCode.NotFound => StatusCode(StatusCodes.Status404NotFound, serviceResponse),
                (int)HttpStatusCode.Forbidden => StatusCode(StatusCodes.Status403Forbidden, serviceResponse),
                _ => StatusCode(StatusCodes.Status500InternalServerError, serviceResponse)
            };

            return result;
        }
    }
}