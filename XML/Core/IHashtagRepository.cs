using System;
using XML.Model;

namespace XML.Core
{
    public interface IHashtagRepository : IRepository<Model.Hashtag>
    {
        public Hashtag GetTagWithName(string name);
    }
}
