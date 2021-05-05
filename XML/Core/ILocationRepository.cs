using System;
using XML.Model;

namespace XML.Core
{
    public interface ILocationRepository : IRepository<Model.Location>
    {
        public Location GetLocationWithName(string name);
    }
}
