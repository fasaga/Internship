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
        /// <summary>
        /// Mentor-type method of bringing in mentor list
        /// </summary>
        List<Mentor> Get();
    }
}
