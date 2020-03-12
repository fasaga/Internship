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
         List<Mentor> Get();
         Mentor Get(String mentor);
    }
}
