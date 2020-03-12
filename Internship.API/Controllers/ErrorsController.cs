using System.Net;
using Internship.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Internship.API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("/errors")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        [Route("{code}")]
        public IActionResult Error(int code)
        {
            HttpStatusCode parsedCode = (HttpStatusCode)code;
            ApiError error = new ApiError(code, parsedCode.ToString());
            switch (code)
            {
                case 500:
                    error.Description = "Internal Server Error";
                    error.Message = "Please, contact administrator.";
                    break;
                case 404:
                    error.Description = "Resource Not Found";
                    error.Message = "The requested resource does not exist.";
                    break;
                default:
                    break;
            }
            return BadRequest(error);
        }
    }
}