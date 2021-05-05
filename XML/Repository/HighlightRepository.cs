using System;
using XML.Core;
using XML.Model;

namespace XML.Repository
{
    public class HighlightRepository : Repository<Highlight> , IHighlightRepository
    {
        public HighlightRepository(XMLContext context) : base(context) { }
    }
}
