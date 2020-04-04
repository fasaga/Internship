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
    public class InternsController : ControllerBase
    {
        private readonly IInternService _internService;

        public InternsController(IInternService internService)
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

            return _internService.Create(intern);

        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        public string Update(Intern intern)
        {
            return "Successful";
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
                if (intern.EndDate >= intern.StartDate.AddMonths(6))
                {
                    return BadRequest(new ApiError(400, "the end date must be greater than the start date"));

                }else if (intern.EndDate == null)
                {
                    intern.EndDate = intern.StartDate.AddMonths(6);
                }
                {
                    _internService.Update(id, internIn);
                    return _internService.GetInternById(id);
                }
            }
            catch (Exception e)
            {
                return BadRequest(new ApiError(400, "Request failed", e.Message));
            }
        }
    }
}