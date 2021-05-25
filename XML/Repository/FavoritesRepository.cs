using System;
using System.Linq;
using XML.Core;
using XML.Model;

namespace XML.Repository
{
    public class FavoritesRepository : Repository<Favorites> , IFavoritesRepository
    {
        public FavoritesRepository(XMLContext context) : base(context)
        {
        }

        public Favorites GetFavoritesWithUserAndPost(int userId, int postId)
        {
            return XMLContext.Favorites.Where(x => x.User.Id == userId && x.FavouritedPost.Id == postId).SingleOrDefault();
        }
    }
}
