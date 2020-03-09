using Internship.API.Models;
using Internship.API.Repositories.Interfaces;
using Internship.API.Services.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.API.Services
{
    public class MentorsService
    {
        private readonly IMongoCollection<Mentor> _mentor;

        public MentorsService(IMentorsService settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _mentor = database.GetCollection<Mentor>(settings.UsersCollectionName);
        }
        public List<Mentor> Get() =>
           _mentor.Find(mentor => true).ToList();

        //public Mentor Get(int id) =>
        //    _mentor.Find<Mentor>(mentor => mentor.MentorId == id).FirstOrDefault();
    }
}
