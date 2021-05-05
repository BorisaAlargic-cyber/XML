using System;
namespace XML.Model
{
    public class CloseFriends : BaseModel
    {
        public User Owner { get; set; }
        public User CloseFriend { get; set; }
        public bool IsCloseFriend { get; set; }
    }
}
