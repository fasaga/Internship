﻿using Internship.API.Models;
using Internship.API.Controllers;
using Internship.API.Repositories.Interfaces;
using Internship.API.Services.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Internship.API.Services
{
    public class MentorService : IMentorService
    {
        private readonly IMapper _mapper;
        private readonly IMentorRepository _mentorRepository;
        private readonly IInternRepository _internRepository;
        private readonly IUserRepository _userRepository;

        public MentorService(IMentorRepository mentorRepository, IUserRepository userRepository, IInternRepository internRepository, IMapper mapper)
        {
            _mentorRepository = mentorRepository;
            _internRepository = internRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public List<MentorDTO> Get()
        {
            //Retrieve all current mentors in the database
            List<User> mentors = _mentorRepository.Get();
            //Declare a new list that will contains the mapped mentors
            List<MentorDTO> response = new List<MentorDTO>();
            //Iterate over mentors list and map each mentor to a MentorDTO type
            foreach (User item in mentors)
            {
                //Do the mapping
                MentorDTO mentor = _mapper.Map<MentorDTO>(item);
                //Retrieve all interns related to the mentor
                List<Intern> interns = _internRepository.GetByMentorId(mentor.UserId);
                List<InternDTO> internsDTO = new List<InternDTO>();
                foreach (var intern in interns)
                {
                    InternDTO internDTO = _mapper.Map<InternDTO>(intern);
                    User internInfo = _userRepository.GetById(internDTO.UserId);
                    if (internInfo == null) continue;
                    if (internInfo != null)
                        internDTO.LoadUserInfo(internInfo);
                    internsDTO.Add(internDTO);
                }
                mentor.Interns = internsDTO;
                //Add the mapped mentor to the response list
                response.Add(mentor);
            }
            //Return the list of mentors of type MentorDTO
            return response;
        }
        public List<InternDTO> GetInternsByMentorId(string mentorId)
        {
            //Retrieve all interns related to the mentor
            List<Intern> interns = _internRepository.GetByMentorId(mentorId);
            List<InternDTO> internsDTO = new List<InternDTO>();
            foreach (var intern in interns)
            {
                InternDTO internDTO = _mapper.Map<InternDTO>(intern);
                User internInfo = _userRepository.GetById(internDTO.UserId);
                if (internInfo != null)
                { 
                    if (!internInfo.Status.Equals("active")) continue;
                        internDTO.LoadUserInfo(internInfo); 
                }
                internsDTO.Add(internDTO);
            }
            return internsDTO;
        }
       
        public MentorDTO GetByMentorId(string id)
        {
            User mentorDB = _mentorRepository.GetById(id);
            if (mentorDB == null)
            {
                return null; 
            }
            //Do the mapping
            MentorDTO mentor = _mapper.Map<MentorDTO>(mentorDB);
            //Retrieve all interns related to the mentor
            List<Intern> interns = _internRepository.GetByMentorId(mentor.UserId);
            List<InternDTO> internsDTO = new List<InternDTO>();
            foreach (var intern in interns)
            {
                InternDTO internDTO = _mapper.Map<InternDTO>(intern);
                User internInfo = _userRepository.GetById(internDTO.UserId);
                if (internInfo != null)
                {
                    if (!internInfo.Status.Equals("active")) continue;
                        internDTO.LoadUserInfo(internInfo);
                }
                internsDTO.Add(internDTO);
            }
            mentor.Interns = internsDTO;
            //Add the mapped mentor to the response list
            return mentor;
        }
        public void Remove(string id)
        {
            _mentorRepository.Remove(id);
        }


    }
}


