using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public UserDTO Create(UserDTO userDTO)
        {
            //Map all info from userDTO to user
            User user = _mapper.Map<User>(userDTO);
            //Call create method to store the data, and assign the result in the user variable
            user = _userRepository.Create(user);
            //Map all info from the result to userDTO
            userDTO = _mapper.Map<UserDTO>(user);
            //return created user of type UserDTO
            return userDTO;
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }
        public UserDTO GetById(string id)
        {
            //Map all info from userDTO to user
            User user = _userRepository.GetById(id);
            //Map all info from the result to userDTO
            UserDTO userDTO = _mapper.Map<UserDTO>(user);
            //return the user of type UserDTO
            return userDTO;
        }
    }
    

}
