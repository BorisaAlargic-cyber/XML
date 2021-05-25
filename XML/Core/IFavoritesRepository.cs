using System;
namespace XML.Core
{
    public interface IFavoritesRepository : IRepository<Model.Favorites>
    {
        public Model.Favorites GetFavoritesWithUserAndPost(int userId, int postId);
    }
}
