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
        /// Get All active users with mentor role in the application 
        /// </summary>
        /// <returns>
        /// returns list with all registered mentors(only active users with mentor role)
        /// </returns>
        /// <response code="200">Returns all active mentors.</response>
        [HttpGet]
        public List<MentorDTO> Get()
        {
            return _mentorService.Get();
        }
        /// <summary>
        /// Get all active interns assigned to the mentor 
        /// </summary>
        /// <param name="id">Mentor's id</param>
        /// <returns>The list of interns(onlly active interns)</returns>
        /// <response code="200">Returns the list of active interns</response>
        [HttpGet("{id:length(24)}/interns")]
        public ActionResult<List<InternDTO>> GetInternsByMentorId(string id)
        {
            try
            {
                var interns = _mentorService.GetInternsByMentorId(id);
                if (interns == null)
                {
                    return NotFound(new ApiError(404, "The mentor does not exist", $"Id: {id}"));

                }
                else
                {
                    return interns;
                }
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
                if (mentor == null)
                {
                    return NotFound(new ApiError(404, "Mentor not found", $"Id: {id}"));
                }
                else
                {
                    return mentor;
                }
            }
            catch (Exception e)
            {
                return BadRequest(new ApiError(400, "Request failed", e.Message));
            }
        }
    }
}