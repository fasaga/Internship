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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            _userService.Create(user);

            return user;
        }
        [HttpGet]
        public List<User> Get() 
        {
            return _userService.Get();
        }

        [HttpGet("{id}")]
        public ActionResult GetId(string id)
        {
            return _userService.GetId();
        }
    }
}