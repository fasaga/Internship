using System.Collections.Generic;
using Internship.API.Models;
using Internship.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Internship.API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [ApiController]
    public class MentorsController : ControllerBase
    {
        private readonly IMentorService _mentorService;

        public MentorsController(IMentorService mentorService)
        {
            _mentorService = mentorService;
        }
        /// <summary>
        /// Get Controller to get list of mentors.
        /// </summary>
        [HttpGet]
        public List<Mentor> Get()
        {
            return _mentorService.Get();
        }
    }
}
