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
        private readonly IMongoCollection<User> _mentors;

        public MentorRepository(ISourceSCDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _mentors = database.GetCollection<User>(settings.UsersCollectionName);
        }
        public List<User> Get()
        {
            var mentors= _mentors.Find(user => user.Role.Equals("mentor") && user.Status.Equals("active")).ToList().ToList();
            return mentors;
        }

        public User GetById(string id) =>
            _mentors.Find<User>(user => user.UserId == id && user.Role.Equals("mentor")).FirstOrDefault();


    }
}
