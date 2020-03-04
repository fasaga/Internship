using Internship.API.Models;
using Internship.API.Services.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.API.Services
{
    public class UsersService 
    {
        private readonly IMongoCollection<User> _user;

        public UsersService(IUsersService settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _user = database.GetCollection<User>(settings.UsersCollectionName);
        }

        public List<User> Get() =>
            _user.Find(user => true).ToList();

        public User Get(int id) =>
            _user.Find<User>(user => user.UserId == id).FirstOrDefault();

        public User Create(User user)
        {
            _user.InsertOne(user);
            return user;
        }

        //public void Update(string id, User userIn) =>
        //    _user.ReplaceOne(user => user.UserId == id, userIn);

        //public void Remove(User userIn) =>
            //_user.DeleteOne(user => user.UserId == userIn.Id);

        //public void Remove(string id) => 
          //  _user.DeleteOne(user => user.UserId == id);
    }
    
}
