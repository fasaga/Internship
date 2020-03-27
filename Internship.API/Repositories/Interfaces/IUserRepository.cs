using Internship.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User Create(User user);
        Boolean GetId(String userId);
        /// <summary>
        /// User-type method of bringing in User list
        /// </summary>
        List<User> GetAll();
        User GetById(string userId);
        
    }
}
