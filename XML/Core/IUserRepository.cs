using System;
using XML.Model;

namespace XML.Core
{
    public interface IUserRepository : IRepository<Model.User>
    {

        public User GetUserWithEmail(string email);

        public User GetUserWithEmailAndPassword(string email, string password);
    }
}
