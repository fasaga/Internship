using Internship.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.API.Services.Interfaces
{
    public interface IInternService
    {
        Intern Create(Intern intern);
        List<Intern> GetAll();
    }
}

