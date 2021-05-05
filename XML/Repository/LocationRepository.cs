using System;
using System.Linq;
using XML.Core;
using XML.Model;

namespace XML.Repository
{
    public class LocationRepository : Repository<Location> , ILocationRepository
    {
        public LocationRepository(XMLContext context) : base(context) { }

        public Location GetLocationWithName(string name)
        {
            return XMLContext.Locations.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
