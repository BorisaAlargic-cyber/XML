using System;
namespace XML.Model
{
    public class Post : BaseModel
    {
        public string Description { get; set; }
        public PostType PostType { get; set; }
        public DateTime DateCreated { get; set; }
        public bool OnlyCloseFriend { get; set; }
        public User User { get; set; }
        public Location Location { get; set; }

    }
}
