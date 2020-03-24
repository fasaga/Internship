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
                return _userService.Create(user);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiError(400, "Request failed", e.Message));
            }

        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        public List<User> GetAll()
        {
            return _userService.GetAll();
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<User> GetById(string id)
        {
            try
            {
                var user = _userService.GetById(id);
                if (user == null) {
                    return BadRequest(new ApiError(404, "User not found", $"Id: {id}"));
                }
                return user;
            }
            catch (Exception e)
            {
                return BadRequest(new ApiError(400, "Request failed", e.Message));
            }
        }
    }
}