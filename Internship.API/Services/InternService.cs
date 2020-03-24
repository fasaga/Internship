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
    public class InternService : IInternService
    {
        private readonly IInternRepository _internRepository;
        private readonly IUserRepository _userRepository;
        public InternService(IInternRepository internRepository, IUserRepository userRepository)
        {
            _internRepository = internRepository;
            _userRepository = userRepository;
        }



        public Intern Create(Intern intern)
        {
            Intern returnIntern = new Intern();
            if (_userRepository.GetId(intern.UserId))
            {
                returnIntern = _internRepository.Create(intern);
            }
            else
            {
                 returnIntern = null;
            }
            return returnIntern;
        }
        /// <summary>
        /// Method for returning a list of interns to the repository
        /// </summary>
        public List<Intern> GetAll()
        {
            return _internRepository.GetAll();
        }
    }
        
        
}


