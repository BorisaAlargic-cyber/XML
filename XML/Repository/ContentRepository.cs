using System;
using System.Linq;
using XML.Core;
using XML.Model;

namespace XML.Repository
{
    public class ContentRepository : Repository<Content> , IContentRepositroy
    {
       public ContentRepository(XMLContext context) : base(context) { }

        public Content GetContentByPostId(int id)
        {
            return XMLContext.Contents.Where(x => x.ContentPost.Id == id).SingleOrDefault();
        }
    }
}
