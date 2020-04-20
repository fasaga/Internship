using Internship.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.API.Services.Interfaces
{
    public interface IMentorService
    {
         List<MentorDTO> Get();
        List<InternDTO> GetInternsByMentorId(string mentorId);
        MentorDTO GetByMentorId(string mentorId);
        public void Remove(string id);
    }
}
