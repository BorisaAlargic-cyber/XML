using System;
using XML.Core;
using XML.Model;

namespace XML.Repository
{
    public class PostCommentRepository : Repository<PostComment> , IPostCommentRepository
    {
        public PostCommentRepository(XMLContext context) : base(context) { }
    }
}
