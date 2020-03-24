using Internship.API.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.API.Repositories.Interfaces
{
    public interface IMentorRepository
    {
        /// <summary>
        /// Mentor-type method of bringing in mentor list
        /// </summary>
        List<Mentor> Get();
    }
}
