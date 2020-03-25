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
        /// Get Controller to get list of Interns.
        /// </summary>
        [HttpGet]
        public List<InternDTO> GetAll()
        {
            return _internService.GetAll();
        }
    }
}