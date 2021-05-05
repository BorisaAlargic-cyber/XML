using System;
using XML.Core;
using XML.Model;

namespace XML.Repository
{
    public class ContentRepository : Repository<Content> , IContentRepositroy
    {
       public ContentRepository(XMLContext context) : base(context) { }
    }
}
