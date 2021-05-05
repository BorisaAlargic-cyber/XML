using System;
namespace XML.Model
{
    public class PostTag : BaseModel
    {
        public Post Post { get; set; }
        public  Hashtag Hashtag { get; set; }
    }
}
