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
        /// <summary>
        /// a list of all the interns registered in the application 
        /// </summary>
        /// <returns></returns>
        List<Intern> GetAll();
        /// <summary>
        /// Intern-type method of delete intern
        /// </summary>
        /// <param name="id"></param>
        void Remove(string id);
    }
}
