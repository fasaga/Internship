using Internship.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.API.Repositories.Interfaces
{
    public interface IInternRepository
    {
        Intern Create(Intern intern);
        Intern Get(string id);

        List<Intern> GetByMentorId(string mentorId);

        Intern GetInternById(string id);

        Intern Update(string id, Intern internIn);
    }
}
