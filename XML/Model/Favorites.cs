using System;
namespace XML.Model
{
    public class Favorites : BaseModel
    {
        public User User { get; set; }
        public Post FavouritedPost { get; set; }
        public bool Favourited { get; set; }
    }
}
