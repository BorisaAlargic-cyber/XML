using System;
using XML.Model;
using XML.Repository;

namespace XML.Service
{
    public class LocationService
    {
        public LocationService()
        {
        }

        public Location CreateLocation(string Name)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    Location dbLocation = unitOfWork.Locations.GetLocationWithName(Name);

                    if(dbLocation != null)
                    {
                        return dbLocation;
                    }

                    dbLocation = new Location();

                    dbLocation.Name = Name;
                    dbLocation.Deleted = false;

                    unitOfWork.Locations.Add(dbLocation);
                    unitOfWork.Complete();

                    return dbLocation;
                }

            }catch(Exception ee)
            {
                return null;
            }
        }
    }
}
