using System;
namespace XML.Model
{
    public class Follower : BaseModel
    {
       public User UserFollowing { get; set; }
       public User UserFollowed { get; set; }
       public bool? AcceptedFollow { get; set; }
       public bool isedFollowing { get; set; }

    }
}
