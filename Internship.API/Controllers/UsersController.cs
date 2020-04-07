using Internship.API.Models;
using Internship.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public UsersController(IUserService userService)
        {
            _userService = userService;
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
                return _userService.Create(user);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiError(400, "Request failed", e.Message));
            }

        }

        [ApiExplorerSettings(IgnoreApi = true)]

        [HttpGet]
        ///Get All Users in the application   
        public List<User> GetAll()
        {
            return _userService.GetAll();
        }
        /// <summary>
        /// Get User by spesific ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// returns a User
        /// </returns>
        [HttpGet("{id:length(24)}")]
        public ActionResult<User> GetById(string id)
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
        /// Update User by spesific ID
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
        public ActionResult<User> Update(string id, UserDTO userIn)
        {
            try
            {
                var user = _userService.GetById(id);

                if (user == null)
                {
                    return BadRequest(new ApiError(404, "User not found", $"Id: {id}"));
                }
                else
                {

                    _userService.Update(id, userIn);
                    return _userService.GetById(id);
                }
               
            }
            catch (Exception e)
            {
                return BadRequest(new ApiError(400, "Request failed", e.Message));
            }
        }
    }
}