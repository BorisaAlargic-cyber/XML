using System;
using System.Collections.Generic;
using XML.Model;

namespace XML.Core
{
    public interface IUserRepository : IRepository<Model.User>
    {

        public User GetUserWithEmail(string email);

        public User GetUserWithUsername(string username);

        public User GetUserWithUsernameAndPassword(string username, string password);

        public List<User> GetPublicProfiles(string search);

        
    }
}
