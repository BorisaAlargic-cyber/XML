using System;
namespace XML.Model
{
    public class Reaction : BaseModel
    {
        public User User { get; set; }
        public Post Post { get; set; }
        public ReactionType ReactionType { get; set; }

    }
}
