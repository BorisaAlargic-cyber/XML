using System;
using System.Collections.Generic;
using XML.Model;

namespace XML.Core
{
    public interface IPostCommentRepository : IRepository<Model.PostComment>
    {
        public List<PostComment> GetCommentsForPostId(int id);
    }
}
