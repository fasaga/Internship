using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Internship.API.Models;
using Internship.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Internship.API.Controllers
{
    [ApiController]
    [Route("api/mentors")]
    public class MentorsController : ControllerBase
    {
        private readonly MentorsService _mentorService;

        public MentorsController(MentorsService mentorService)
        {
            _mentorService = mentorService;
        }
        [HttpGet]
        public ActionResult<List<Mentor>> Get() =>
           _mentorService.Get();

        [HttpGet("{id:length(24)}", Name = "GetMentor")]
        public ActionResult<Mentor> Get(int id)
        {
            var mentor = _mentorService.Get(id);

            if (mentor == null)
            {
                return NotFound();
            }

            return mentor;
        }



    }
}
