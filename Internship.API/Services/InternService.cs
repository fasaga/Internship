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
    public class InternService : IInternService
    {
        private readonly IInternRepository _internRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public InternService(IInternRepository internRepository, IUserRepository userRepository, IMapper mapper)
        {
            _internRepository = internRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }



        public InternDTO Create(InternDTO internDTO)
        {
            Intern intern = new Intern();
            User user = _userRepository.GetById(internDTO.UserId);
            if (user != null && _internRepository.Get(internDTO.UserId) == null)
            {
                intern = _mapper.Map<Intern>(internDTO);
                intern = _internRepository.Create(intern);
                internDTO = _mapper.Map<InternDTO>(intern);
                internDTO.LoadUserInfo(user);
                //load mentor info
                //internDTO.LoadInternInfo(user);
                return internDTO;
            }
            else
            {
                internDTO = null;
            }
            return internDTO;
        }
        /// <summary>
        /// Method for returning a list of interns to the repository
        /// </summary>
        public List<InternDTO> GetAll()
        {
            List<Intern> interns = _internRepository.GetAll();
            //Declare a new list that will contains the mapped mentors
            List<InternDTO> response = new List<InternDTO>();
            return response;
        }
    }


}


