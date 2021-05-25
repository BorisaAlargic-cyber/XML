using System;
using System.Linq;
using XML.Core;
using XML.Model;

namespace XML.Repository
{
    public class FollowersRepository : Repository<Follower> , IFollowerRepositroy
    {
        public FollowersRepository(XMLContext context) : base(context) { }

        public Follower isFollowing(int userFollowingId, int userFollowedId)
        {
            return XMLContext.Followers.Where(x => x.UserFollowing.Id == userFollowingId && x.UserFollowed.Id == userFollowedId).SingleOrDefault();
        }
    }

    
}
