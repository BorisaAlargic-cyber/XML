using System;
using XML.Core;
using XML.Model;

namespace XML.Repository
{
    public class CloseFriendsRepository : Repository<CloseFriends> , ICloseFriendsRepository
    {
        public CloseFriendsRepository(XMLContext context) : base(context) { }
    }
}
