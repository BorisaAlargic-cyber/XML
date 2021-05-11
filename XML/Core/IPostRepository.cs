using System;
using System.Collections.Generic;
using XML.Model;

namespace XML.Core
{
    public interface IPostRepository : IRepository<Model.Post>
    {
        public List<Post> GetPostWithLocation(string name);
    }
}
