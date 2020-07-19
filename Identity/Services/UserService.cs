using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Models;
using Identity.Interfaces;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using Identity.Providers;

namespace Identity.Services
{
    public class UserService : IUserService
    {
        private IMongoCollection<User> _users;
        public UserService()
        {
            string entityName = "User";
            _users = DbProvider.getCollectionInstance<User>(entityName);
        }

        public User getUserById(string userId)
        {
            return _users.Find<User>(user => user.Id == userId).FirstOrDefault();
        }

        public bool insertUser(User user)
        {
            _users.InsertOne(user);
            return true;
        }
    }
}
