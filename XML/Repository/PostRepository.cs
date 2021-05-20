using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public List<Post> GetAllStories()
        {
            return XMLContext.Posts.Where(x => x.PostType == PostType.Story && x.DateCreated > DateTime.Now.AddDays(-1))
                .Include(x => x.User).ToList();
        }
        public List<Post> GetAllPosts()
        {
            return XMLContext.Posts.Where(x => x.PostType == PostType.Post )
                .Include(x => x.Location)
                .Include(x => x.User).ToList();
        }

        public List<Post> GetAllPostsWithUserId(User user)
        {
            return XMLContext.Posts.Where(x => x.User == user ).Include(x => x.User).ToList();
        }
    }

    
}
