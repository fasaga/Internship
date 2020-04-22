using Internship.API.Models;
using Internship.API.Repositories.Interfaces;
using Intership.API.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Internship.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(ISourceSCDatabaseSettings settings)
        {
            try
            {
                var client = new MongoClient(settings.ConnectionString);
                var database = client.GetDatabase(settings.DatabaseName);

                _users = database.GetCollection<User>(settings.UsersCollectionName);
            }
            catch (Exception e)
            {

                throw new Exception("Database config is invalid.");
            }
        }
        /// <summary>
        /// User-type method of bringing in all Users list
        /// </summary>
        public List<User> GetAll() =>
           _users.Find(user => true && user.Status.Equals("active")).ToList();

        public User Get(string id) =>
            _users.Find<User>(user => user.UserId == id).FirstOrDefault();
        /// <summary>
        /// User-type method to create a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        /// the new user
        /// </returns>
        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }
        /// <summary>
        /// User-type method to Update a user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userIn"></param>
        /// <returns>
        /// reurns a user update 
        /// </returns>
        public User Update(string id, User userIn)
        {
            _users.ReplaceOne(user => user.UserId == id, userIn);
            return userIn;
        }

        public void Remove(User userIn) =>
        _users.DeleteOne(user => user.UserId == userIn.UserId);

        public User GetById(string id) {
            if (id == null || id.Trim().Equals("")) return null;
            try
            {
                return _users.Find<User>(user => user.UserId == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                return null;
            }
        }
       
        public void Remove(string id)
        {
            _users.DeleteOne(user => user.UserId == id);
        }

        public Boolean GetId(String userId)
        {

            return _users.Find(user => user.UserId == userId).FirstOrDefault() != null;
        }
    }
}
