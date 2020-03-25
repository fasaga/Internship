using Internship.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.API.Services.Interfaces
{
    public interface IUserService
    {
        UserDTO Create(UserDTO user);
        /// <summary>
        /// User-type method of bringing in User list
        /// </summary>
        List<UserDTO> GetAll();
        User GetById(string userId);
    }
}


