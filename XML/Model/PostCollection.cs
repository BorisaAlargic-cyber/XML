using System;
namespace XML.Model
{
    public class PostCollection : BaseModel
    {
        public User User { get; set; }
        public Post Post { get; set; }
        public string Name { get; set; }
        
    }
}
