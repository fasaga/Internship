using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.API.Services.Interfaces
{
    public interface IUsersService
    {
        string UsersCollectionName { get; }
        string DatabaseName { get; set; }
    }
}
