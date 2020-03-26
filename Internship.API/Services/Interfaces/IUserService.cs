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
        UserDTO GetById(string userId);
        List<UserDTO> GetAll();
    }
}


