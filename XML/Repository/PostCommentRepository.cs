using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using XML.Core;
using XML.Model;

namespace XML.Repository
{
    public class PostCommentRepository : Repository<PostComment> , IPostCommentRepository
    {
        public PostCommentRepository(XMLContext context) : base(context) { }

        public List<PostComment> GetCommentsForPostId(int id)
        {
            return XMLContext.PostComments.Include(x => x.User).Where(x => x.Post.Id == id).ToList();
        }
    }
}
