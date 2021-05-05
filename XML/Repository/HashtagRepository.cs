using System;
using System.Linq;
using XML.Core;
using XML.Model;

namespace XML.Repository
{
    public class HashtagRepository : Repository<Hashtag> , IHashtagRepository
    {
        public HashtagRepository(XMLContext context) : base(context) { }


        public Hashtag GetTagWithName(string name)
        {
            return XMLContext.Hashtags.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
