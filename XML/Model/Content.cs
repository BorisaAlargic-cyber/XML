using System;
namespace XML.Model
{
    public class Content : BaseModel
    {
        public Post ContentPost { get; set; }
        public string FileContent { get; set; }
        public Album AlbumContent { get; set; }
    }
}
