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
    [Route("api/[controller]")]
    [ApiController]
    public class InternController : ControllerBase
    {
        private readonly IInternService _internService;

        public InternController(IInternService internService)
        {
            _internService = internService;
        }
        
        [HttpPost]
        public ActionResult<Intern> Create(Intern intern)
        {
            Intern test = new Intern();
            test =_internService.Create(intern);
            if (test == null)
            {
                Console.WriteLine("Test");
            }
            return test;

        }
        [HttpPut]
        public string Update( Intern intern)
        {
            return "Successful";
        }
    }
}