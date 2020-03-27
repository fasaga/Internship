using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Internship.API.Models;
using Internship.API.Services;
using Internship.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internship.API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [ApiController]
    public class InternsController : ControllerBase
    {
        private readonly IInternService _internService;
        
        public InternsController(IInternService internService)
        {
            _internService = internService;
        }
        
        [HttpPost]
        public ActionResult<InternDTO> Create(InternDTO intern)
        {
            
            return _internService.Create(intern);

        }
        [HttpPut]
        public string Update( Intern intern)
        {
            return "Successful";
        }

        /// <summary>
        /// Get Intern by spesific ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// returns a Intern
        /// </returns>
        [HttpGet("{id:length(24)}")]
        public ActionResult<InternDTO> GetInternById(string id)
        {
            try
            {
                var intern = _internService.GetInternById(id);
                if (intern == null)
                {
                    return BadRequest(new ApiError(404, "User not found", $"Id: {id}"));
                    
                }
                else
                {
                    return intern;

                }
            }
            catch (Exception e)
            {
                return BadRequest(new ApiError(400, "Request failed", e.Message));
            }

        }
        
    }
}