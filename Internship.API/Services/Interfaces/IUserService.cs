using Internship.API.Models;
using System.Collections.Generic;

namespace Internship.API.Services.Interfaces
{
    public interface IUserService
    {
        UserDTO Create(UserDTO user);
        /// <summary>
        /// User-type method of bringing in User list
        /// </summary>
        List<UserDTO> GetAll();
        UserDTO GetById(string userId);
        /// <summary>
        /// method of update of User 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userIn"></param>
        /// <returns></returns>
        UserDTO Update(string id, UserDTO userIn);
        /// <summary>
        /// User-type method of delete User
        /// </summary>
        /// <param name="id"></param>
        void Remove(string id);
    }
}


