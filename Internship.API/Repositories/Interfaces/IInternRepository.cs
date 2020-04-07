using Internship.API.Models;
using System.Collections.Generic;

namespace Internship.API.Repositories.Interfaces
{
    public interface IInternRepository
    {
        Intern Create(Intern intern);
        Intern Get(string id);

        List<Intern> GetByMentorId(string mentorId);

        Intern GetInternById(string id);

        Intern Update(string id, Intern internIn);

        List<Intern> GetAll();
    }
}
