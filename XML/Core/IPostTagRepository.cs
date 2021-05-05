using System;
using System.Collections.Generic;
using XML.Model;

namespace XML.Core
{
    public interface IPostTagRepository : IRepository<Model.PostTag>
    {
        public List<PostTag> GetPostsWithTags(int id);
    }
}
