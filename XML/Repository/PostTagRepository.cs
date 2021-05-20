using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using XML.Core;
using XML.Model;

namespace XML.Repository
{
    public class PostTagRepository : Repository<PostTag> , IPostTagRepository
    {
        public PostTagRepository(XMLContext context) : base(context) { }

        public List<PostTag> GetPostsWithTags(int id)
        {
            return XMLContext.PostTags.Include(x => x.Post)
                .Include(x => x.Hashtag).Where(x => x.Post.Id == id)
                .ToList();
        }
    }
}
