using System;
using XML.Core;
using XML.Model;

namespace XML.Repository
{
    public class ReactionRepository : Repository<Reaction> , IReactionRepository
    {
        public ReactionRepository(XMLContext context) : base(context) { }
    }
}
