using System;
using XML.Core;
using XML.Model;

namespace XML.Repository
{
    public class PostCollectionRepository : Repository<PostCollection> , IPostCollectionRepository
    {
        public PostCollectionRepository(XMLContext context) : base(context) { }
    }
}
