using System;
using System.Collections.Generic;
using System.Linq;
using XML.Core;
using XML.Model;

namespace XML.Repository
{
    public class PostRepository : Repository<Post> , IPostRepository
    {
        public PostRepository(XMLContext context) : base(context) { }

        public List<Post> GetPostWithLocation(string name)
        {
            return XMLContext.Posts.Where(x => x.Location.Name == name).ToList();
        }
    }

    
}
