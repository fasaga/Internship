using Internship.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.API.Services.Interfaces
{
    public interface IInternService
    {
        InternDTO Create(InternDTO intern);
        InternDTO GetInternById(string id);
        List<InternDTO> GetAll();
    }
}

