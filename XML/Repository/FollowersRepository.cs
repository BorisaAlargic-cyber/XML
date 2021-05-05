using System;
using XML.Core;
using XML.Model;

namespace XML.Repository
{
    public class FollowersRepository : Repository<Follower> , IFollowerRepositroy
    {
        public FollowersRepository(XMLContext context) : base(context) { }
       
    }
}
