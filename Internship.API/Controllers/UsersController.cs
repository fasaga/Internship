using Internship.API.Models;
using Internship.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;

namespace Internship.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMentorService _mentorService;
        private readonly IInternService _internService;

        public UsersController(IUserService userService, IMentorService mentorService, IInternService internService)
        {
            _userService = userService;
            _mentorService = mentorService;
            _internService = internService;
        }

        /// <summary>
        /// Creates a new User in the application.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/users
        ///     {
        ///         "userId": null,
        ///         "firstName": "Juan",
        ///         "lastName": "Sandoval",
        ///         "email": "jaun@mail.com",
        ///         "phone": "312312312",
        ///         "startDate": "2020-03-12T17:57:19.526Z",
        ///         "endDate": "2021-03-12T17:57:19.526Z",
        ///         "activeTechnology": "java",
        ///         "status": "active",
        ///         "role": "intern"
        ///     }
        ///     
        /// Sample error:
        ///     
        ///     {
        ///         "code": 400,
        ///         "description": "Validation failed",
        ///         "message": "The FirstName field is required."
        ///     }
        /// </remarks>
        /// <param name="user">Object of type User, contains all user's information to be registered.</param>
        /// <returns>The created user.</returns>
        /// <response code="200">Returns the created user.</response>
        /// <response code="400">If the user did not pass validation/ any other error</response>   
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
        public ActionResult<UserDTO> Create(UserDTO user)
        {
            try
            {
                ///change to lowercase
                user.Status = user.Status.ToLower();
                user.Role = user.Role.ToLower();
                ///Valid only active or inactive
                if (user.Status != "active" && user.Status != "inactive")
                {
                    return BadRequest(new ApiError(400, "the status must be active or inactive"));

                }

                if (user.StartDate >= user.EndDate)
                {
                    return BadRequest(new ApiError(400, "The end date must be greater than the start date"));

                }
                else if (user.Role == "intern" && user.EndDate == null)
                {
                    user.EndDate = user.StartDate.AddMonths(6);
                }
                else if (user.EndDate > user.StartDate.AddMonths(6))
                {
                    return BadRequest(new ApiError(400, "The EndDate Must not exceed 6 months"));
                }
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status201Created,_userService.Create(user));
               
            }
            catch (Exception e)
            {
                return BadRequest(new ApiError(400, "Request failed", e.Message));
            }

        }

        /// <summary>
        /// Get All active users in the application 
        /// </summary>
        /// <returns>
        /// returns list with all registered users(only active users)
        /// </returns>
        /// <response code="200">Returns all active users.</response>
        [HttpGet] 
        public List<UserDTO> GetAll()
        {
            return _userService.GetAll();
        }

        /// <summary>
        /// Get User by specific ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// returns a User
        /// </returns>
        /// <response code="200">Returns a user.</response>
        [HttpGet("{id:length(24)}")]
        public ActionResult<UserDTO> GetById(string id)
        {
            try
            {
                var user = _userService.GetById(id);
                if (user == null)
                {
                    return BadRequest(new ApiError(404, "User not found", $"Id: {id}"));
                }
                return user;
            }
            catch (Exception e)
            {
                return BadRequest(new ApiError(400, "Request failed", e.Message));
            }
        }
        /// <summary>
        /// Update User by specific ID
        /// </summary>
        ///         /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/users
        ///     {
        ///         	"userId": "5e73d8c697c01f208467265b",
        ///             "firstName": "Juanita",
        ///             "lastName": "Ruiz",
        ///             "email": "Pedro.ruiz@hotmail.com",
        ///             "status": "inactive"
        ///     }
        ///     
        /// Sample error:
        ///     
        ///     {
        ///         "code": 400,
        ///         "description": ""User not found",
        ///     }
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>
        /// returns a User
        /// </returns>
        /// <response code="200">Returns the user update.</response>
        /// <response code="400">User not found</response>   
        [HttpPut("{id:length(24)}")]
        public ActionResult<UserDTO> Update(string id, UserDTO userIn)
        {
            try
            {
                var user = _userService.GetById(id);

                if (user == null)
                {
                    return BadRequest(new ApiError(404, "User not found", $"Id: {id}"));
                }
                else
                ///change to lowercase
                userIn.Status = userIn.Status.ToLower();
                userIn.Role = userIn.Role.ToLower();
                ///Valid only active or inactive
                if (userIn.Status != "active" && userIn.Status != "inactive")
                {
                    return BadRequest(new ApiError(400, "the status must be active or inactive"));

                }
                if (userIn.EndDate == null && userIn.Role == "intern")
                {
                    userIn.EndDate = userIn.StartDate.AddMonths(6);
                }
                else if (userIn.StartDate >= userIn.EndDate)
                {
                    return BadRequest(new ApiError(400, "The end date must be greater than the start date"));

                }
                else if (userIn.EndDate > userIn.StartDate.AddMonths(6))
                {
                    return BadRequest(new ApiError(400, "The EndDate Must not exceed 6 months"));
                }


                _userService.Update(id, userIn);
                return _userService.GetById(id);


            }
            catch (Exception e)
            {
                return BadRequest(new ApiError(400, "Request failed", e.Message));
            }
        }

        /// <summary>
        /// Delete User by specific ID
        /// </summary>
        ///         /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/users/"userid"
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>
        /// Delete a User
        /// return NoContent
        /// </returns>
        /// <response code="204">Returns no content.</response>
        /// <response code="400">Cannot delete this User</response>   
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            //Call Get user by id service
            var user= _userService.GetById(id);
            //Validate if the user exists 
            if (user == null)
            {
                return NotFound();
            }
            //validate if the user is not an intern
            if (user.Role == "intern")
            {
                return BadRequest(new ApiError(400, "Cannot delete this User", $"the user is a Intern try using inten / delete"));
            }
            //Validate if the user is a mentor
            if (user.Role == "mentor")
            {
                //call Get interns by mentor id service
                List<InternDTO> interns = _mentorService.GetInternsByMentorId(id);
                //validate if the mentor does not have interns assigned
                if (interns.Count > 0)
                {
                    return BadRequest(new ApiError(400, "Cannot delete this User", $"the user is a mentor with assigned interns"));
                    
                }
            }
            //Delete the user
            _userService.Remove(user.UserId);

            return NoContent();
        }
    }
}