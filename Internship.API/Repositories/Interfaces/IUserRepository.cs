using Internship.API.Models;
using System;
using System.Collections.Generic;

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
        /// <summary>
        /// method of update of User 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userIn"></param>
        /// <returns></returns>
        User Update(string id, User userIn);
    }
}
