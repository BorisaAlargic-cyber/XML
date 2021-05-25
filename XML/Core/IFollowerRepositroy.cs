using System;
using XML.Model;

namespace XML.Core
{
    public interface IFollowerRepositroy : IRepository<Model.Follower>
    {
        public Follower isFollowing(int userFollowingId, int userFollowedId);
    }
}
