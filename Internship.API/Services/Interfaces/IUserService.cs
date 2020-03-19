using Internship.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.API.Services.Interfaces
{
    public interface IUserService
    {
        User Create(User user);
        List<User> GetAll();
        User GetById(string userId);
    }
}


