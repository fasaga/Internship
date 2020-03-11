using Internship.API.Models;
using Internship.API.Repositories.Interfaces;
using Intership.API.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.API.Repositories
{
    public class InternRepository : IInternRepository
    {
        private readonly IMongoCollection<Intern> _interns;

        public InternRepository(ISourceSCDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _interns = database.GetCollection<Intern>(settings.InternsCollectionName);
        }

        public List<Intern> Get() =>
            _interns.Find(intern => true).ToList();

        public Intern Get(string id)=>

            _interns.Find<Intern>(intern => intern.UserId == id).FirstOrDefault();


        public Intern Create(Intern intern)
        {
            _interns.InsertOne(intern);
            return intern;
        }

        public void Update(string id, Intern internIn) =>
            _interns.ReplaceOne(intern => intern.UserId == id, internIn);

        public void Remove(Intern internIn) =>
        _interns.DeleteOne(intern => intern.UserId == internIn.UserId);

        public void Remove(string id) =>
          _interns.DeleteOne(intern => intern.UserId == id);
    }
}