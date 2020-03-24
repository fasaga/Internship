using Internship.API.Models;
using Internship.API.Repositories.Interfaces;
using Internship.API.Services.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User Create(User user)
        {
            return _userRepository.Create(user);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }
        public User GetById(string id)
        {
            return _userRepository.GetById(id);
        }

        public User GetInternById(string id, string role)
        {
            User getIntern;
            if (role == "Intern" && id != null)
            {

                getIntern = _userRepository.GetInternById(id, role);
            }
            else
            {
                getIntern = null;
            }
            return getIntern;
        }
    }
    

}
