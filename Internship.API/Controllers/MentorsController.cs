using System.Collections.Generic;
using Internship.API.Models;
using Internship.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Internship.API.Controllers
{
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
        /// Get a list of all users with a mentor role
        /// </summary>
        [HttpGet]
        public List<MentorDTO> Get()
        {
            return _mentorService.Get();
        }
    }
}