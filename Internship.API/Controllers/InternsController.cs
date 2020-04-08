using Internship.API.Models;
using Internship.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Internship.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class InternsController : ControllerBase
    {
        private readonly IInternService _internService;

        public InternsController(IInternService internService, IMentorService mentorService)
        {
            _internService = internService;
        }

        /// <summary>
        /// Creates a new Intern in the application for an existing User.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/interns
        ///     {
        ///         "userId": "5e7a721921487c6b60743623",
        ///         "firstName": "humberto",
        ///         "lastName": "Del asdsd",
        ///         "email": "asdasd@hotmail.com",
        ///         "phone": "312-99-5487",
        ///         "startDate": "0001-01-01T00:00:00Z",
        ///         "endDate": "0001-01-01T00:00:00Z",
        ///         "activeTechnology": "net",
        ///         "status": "active",
        ///         "role": "intern",
        ///         "mentorId": "5e7a76db5fe004666c5e9702",
        ///         "comments": "Comments",
        ///         "technologies": ["net", "java"]
        ///     }
        ///     
        /// Sample error:
        ///     
        ///     {
        ///         "code": 400,
        ///         "description": "Validation failed",
        ///         "message": "The UserId field is required."
        ///     }
        /// </remarks>
        /// <param name="intern">Object of type Intern, contains all intern's information to be registered.</param>
        /// <returns>The created intern.</returns>
        /// <response code="200">Returns the created intern.</response>
        /// <response code="400">If the intern did not pass validation/ any other error</response>  
        [HttpPost]
        public ActionResult<InternDTO> Create(InternDTO intern)
        {
            try
            {
                var newIntern = _internService.Create(intern);
                if (newIntern == null)
                {
                    return NotFound(new ApiError(404, "User not found or already exist, $Verify the information"));

                }
                else if (newIntern != null && newIntern.MentorId != null) 
                {
                    return _internService.Create(newIntern);
                    //return BadRequest(new ApiError(200, "user was created successful"));
                }
                else if(newIntern != null && newIntern.MentorId == null)
                {
                    _internService.Create(newIntern);
                    return BadRequest(new ApiError(201, "User was created without mentorId"));
                
                }
                else 
                {
                    return BadRequest(new ApiError(404, "mentor not found", $"please verify the information"));
                }

                
            }
            catch (Exception e)
            {
                return BadRequest(new ApiError(400, "Request failed", e.Message));
            }

        }
        /// <summary>
        /// Get Intern by specific ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// returns a Intern
        /// </returns>
        [HttpGet("{id:length(24)}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult<InternDTO> GetInternById(string id)
        {
            try
            {
                var intern = _internService.GetInternById(id);
                if (intern == null)
                {
                    return NotFound(new ApiError(404, "User not found", $"Id: {id}"));

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
        /// <summary>
        /// Update a Intern in the application for an existing User.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/interns
        ///     {
        ///         "userId": "5e7a721921487c6b60743623",
        ///         "firstName": "humberto",
        ///         "lastName": "Del asdsd",
        ///         "email": "asdasd@hotmail.com",
        ///         "phone": "312-99-5487",
        ///         "startDate": "0001-01-01T00:00:00Z",
        ///         "endDate": "0001-01-01T00:00:00Z",
        ///         "activeTechnology": "net",
        ///         "status": "active",
        ///         "role": "intern",
        ///         "mentorId": "5e7a76db5fe004666c5e9702",
        ///         "comments": "Comments",
        ///         "technologies": ["net", "java"]
        ///     }
        ///     
        /// Sample error:
        ///     
        ///     {
        ///         "code": 400,
        ///         "description": "Validation failed",
        ///         "message": "The UserId field is required."
        ///     }
        /// </remarks>
        /// <param name="id">Interns id</param>
        /// <param name="internIn">Object of type Intern, Contains all intern's information to be update.</param>
        /// <returns>The updated intern.</returns>
        /// <response code="200">Returns the update intern.</response>
        /// <response code="400">If the intern did not pass validation/ any other error</response>  
        [HttpPut("{id:length(24)}")]
        public ActionResult<InternDTO> Update(string id, InternDTO internIn)
        {
            try
            {
                var intern = _internService.GetInternById(id);
                if (intern == null)
                {
                    return NotFound(new ApiError(404, "User not found", $"Id: {id}"));
                }
                else
                
                if (internIn.StartDate >= internIn.EndDate)
                {
                    return BadRequest(new ApiError(400, "The end date must be greater than the start date"));

                }
                else if (internIn.EndDate > internIn.StartDate.AddMonths(6))
                {
                    return BadRequest(new ApiError(400, "The EndDate Must not exceed 6 months"));
                }
                if (intern != null && intern.MentorId == null)
                {

                    BadRequest(new ApiError(201, "User was updated without mentorId"));

                }
                else if (internIn.EndDate == null)
                {
                    internIn.EndDate = internIn.StartDate.AddMonths(6);
                }
                

                _internService.Update(id, internIn);
                return _internService.GetInternById(id);

            }
            catch (Exception e)
            {
                return BadRequest(new ApiError(400, "Request failed", e.Message));
            }
        }
        /// <summary>
        /// Get all interns registered
        /// </summary>
        /// <returns>
        /// a list of all the interns registered in the application 
        /// </returns>
        [HttpGet]
        public List<InternDTO> GetAll()
        {
            return _internService.GetAll();
        }

    }
}