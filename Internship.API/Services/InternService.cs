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
        private readonly IMentorRepository _mentorRepository;
        private readonly IMapper _mapper;
        public InternService(IInternRepository internRepository, IUserRepository userRepository, IMentorRepository mentorRepository, IMapper mapper)
        {
            _internRepository = internRepository;
            _userRepository = userRepository;
            _mentorRepository = mentorRepository;
            _mapper = mapper;
        }

        public InternDTO Create(InternDTO internDTO)
        {
            Intern intern = new Intern();
            User user = _userRepository.GetById(internDTO.UserId);
            //Map all info from internDTO to intern
            intern = _mapper.Map<Intern>(internDTO);
            //Call create method to store the data, and assign the result in the intern variable
            intern = _internRepository.Create(intern);
            //Map all info from the result to userDTO
            internDTO = _mapper.Map<InternDTO>(intern);
            //load user info
            //internDTO.Load user Info(user);
            internDTO.LoadUserInfo(user);
            if (internDTO.MentorId != null)
            {
                User mentor = _userRepository.GetById(internDTO.MentorId);
                //load mentor info
                internDTO.LoadMentorInfo(mentor);
            }

            //return created intern of type InternDTO
            return internDTO;
        }

        public InternDTO GetInternById(string id)
        {
            //Map all info from userDTO to user
            Intern getIntern = _internRepository.GetInternById(id);
            //Map all info from the result to userDTO
            InternDTO internDTO = _mapper.Map<InternDTO>(getIntern);
            //return the user of type UserDTO
            if (internDTO.UserId != null)
            {
                User user = _userRepository.GetById(internDTO.UserId);
                //load mentor info
                //internDTO.Load menor Info(user);
                if (user != null)
                    internDTO.LoadUserInfo(user);
            }
            if (internDTO.MentorId != null)
            {
                User mentor = _userRepository.GetById(internDTO.MentorId);
                //load mentor info
                //internDTO.Load menor Info(user);
                if (mentor != null)
                    internDTO.LoadMentorInfo(mentor);
            }
            return internDTO;
        }
        public InternDTO Update(string id, InternDTO internIn)
        {
            User userinfo = _mapper.Map<User>(internIn);
            User user = _userRepository.Update(id, userinfo);
            Intern intern = _mapper.Map<Intern>(internIn);
            //Map all info from userDTO to user
            Intern getIntern = _internRepository.Update(id, intern);
            //Map all info from the result to userDTO
            InternDTO internDTO = _mapper.Map<InternDTO>(getIntern);
            //return the user of type UserDTO
            return internDTO;
        }
        /// <summary>
        ///  Get all interns registered in the app
        /// </summary>
        /// <returns>a list of all the interns registered in the application </returns>
        public List<InternDTO> GetAll()
        {
            //Retrieve all current interm in the database
            List<Intern> interns = _internRepository.GetAll();
            //Declare a new list that will contains the mapped intern
            List<InternDTO> response = new List<InternDTO>();
            foreach (Intern item in interns)
            {
                //Do the mapping
                InternDTO intern = _mapper.Map<InternDTO>(item);
                //Add the mapped inert to the response list
                User internInfo = _userRepository.GetById(intern.UserId);
                if (internInfo != null) 
                { 
                    if (!internInfo.Status.Equals("active")) continue;
                        intern.LoadUserInfo(internInfo);
                }
                User mentor = _userRepository.GetById(intern.MentorId);
                //load mentor info
                //internDTO.Load menor Info(user);
                if (mentor != null)
                    intern.LoadMentorInfo(mentor);
                response.Add(intern);
            }

            return response;
        }
        /// <summary>
        /// Remove user and interns data from the database 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(string id)
        {
            _internRepository.Remove(id);
        }
    }
}


