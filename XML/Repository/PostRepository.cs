using System;
using XML.Core;
using XML.Model;

namespace XML.Repository
{
    public class PostRepository : Repository<Post> , IPostRepository
    {
        public PostRepository(XMLContext context) : base(context) { }
    }
}
