using Internship.API.Models;
using Internship.API.Controllers;
using Internship.API.Repositories.Interfaces;
using Internship.API.Services.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.API.Services
{
    public class MentorService : IMentorService
    {
        private readonly IMentorRepository _mentorRepository;

        public MentorService(IMentorRepository mentorRepository)
        {
            _mentorRepository = mentorRepository;
        }
        public List<Mentor> Get()
        {
            return _mentorRepository.Get();
        }
    }
}

