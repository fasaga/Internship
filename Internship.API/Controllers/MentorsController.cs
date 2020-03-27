using System;
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
        /// <summary>
        /// Get all interns assigned to the mentor 
        /// </summary>
        /// <param name="id">Mentor's id</param>
        /// <returns>The list of interns</returns>
        /// <response code="200">Returns the list of interns</response>
        [HttpGet("{id:length(24)}/interns")]
        public ActionResult<List<InternDTO>> GetInternsByMentorId(string id)
        {
            try
            {
                var interns = _mentorService.GetInternsByMentorId(id);
                return interns;
            }
            catch (Exception e)
            {
                return BadRequest(new ApiError(400, "Request failed", e.Message));
            }
        }

        /// <summary>
        /// Get Mentor´s information  
        /// </summary>
        /// <param name="id">Mentor's id</param>
        /// <returns>The Mentor</returns>
        /// <response code="200">Returns The Mentor </response>
        [HttpGet("{id:length(24)}")]
        public ActionResult<MentorDTO> GetByMentorId(string id)
        {
            try
            {
                var mentor = _mentorService.GetByMentorId(id);
                return mentor;
            }
            catch (Exception e)
            {
                return BadRequest(new ApiError(400, "Request failed", e.Message));
            }
        }
    }
}