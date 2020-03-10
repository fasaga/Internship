using Internship.API.Models;
using Internship.API.Repositories.Interfaces;
using Intership.API.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.API.Repositories
{
    public class MentorRepository : IMentorRepository
    {
        private readonly IMongoCollection<Mentor> _mentors;

        public MentorRepository(ISourceSCDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _mentors = database.GetCollection<Mentor>(settings.UsersCollectionName);
        }
        public List<Mentor> Get()
        {
            var mentors= _mentors.Find(user => user.Role.Equals("mentor")).ToList();
            return mentors;
        }
    }
}
