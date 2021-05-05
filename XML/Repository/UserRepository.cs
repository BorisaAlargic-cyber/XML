using System;
using System.Linq;
using XML.Core;
using XML.Model;

namespace XML.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(XMLContext context) : base(context) { }

        public User GetUserWithEmail(string email)
        {
            return XMLContext.Users.Where(x => x.Email == email).FirstOrDefault();
        }

        public User GetUserWithEmailAndPassword(string email, string password)
        {
            return XMLContext.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
        }

        public override PageResponse<User> GetPage(Pager pager)
        {
            var query = XMLContext.Users.Where(x => (x.Deleted == false)).OrderBy(x => x.Id);

            return new PageResponse<User>(query.Skip(pager.Page).Take(pager.PerPage).ToList(), query.Count());
        }
    }
}