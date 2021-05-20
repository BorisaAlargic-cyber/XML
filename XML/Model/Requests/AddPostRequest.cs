using System;
namespace XML.Model.Requests
{
    public class AddPostRequest
    {
        public string Description { get; set; }
        public string FileContent { get; set; }
        public string Location { get; set; }
        public string Tags { get; set; }
        public PostType PostType { get; set; }
        public bool OnlyCloseFirends { get; set; }
    }
}
