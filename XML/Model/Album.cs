using System;
namespace XML.Model
{
    public class Album : BaseModel
    {
        public User Owner { get; set; }
        public string Name { get; set; }
    }
}
