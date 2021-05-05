using System;
using XML.Core;
using XML.Model;

namespace XML.Repository
{
    public class FavoritesRepository : Repository<Favorites> , IFavoritesRepository
    {
        public FavoritesRepository(XMLContext context) : base(context)
        {
        }
    }
}
