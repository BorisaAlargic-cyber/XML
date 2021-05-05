using System;
namespace XML.Model
{
    public class PostComment : BaseModel
    {
       public User User { get; set; }
       public Post Post { get; set; }
       public string Comment { get; set; }
    }
}
