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
        public InternService(IInternRepository internRepository)
        {
            _internRepository = internRepository;
        }
        public Intern Create(Intern intern)
        {
            return _internRepository.Create(intern);
        }
    }

}
