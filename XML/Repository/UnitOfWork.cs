using System;
using XML.Core;
using XML.Model;

namespace XML.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly XMLContext context;

        public UnitOfWork(XMLContext context)
        {
            this.context = context;
            Users = new UserRepository(this.context);
            Posts = new PostRepository(this.context);
            Albums = new AlbumRepository(this.context);
            CloseFriends = new CloseFriendsRepository(this.context);
            Contents = new ContentRepository(this.context);
            Favorites = new FavoritesRepository(this.context);
            Followers = new FollowersRepository(this.context);
            Highlights = new HighlightRepository(this.context);
            PostCollections = new PostCollectionRepository(this.context);
            PostComments = new PostCommentRepository(this.context);
            Reactions = new ReactionRepository(this.context);
            Hashtags = new HashtagRepository(this.context);
            Locations = new LocationRepository(this.context);
            PostTags = new PostTagRepository(this.context);
        }

        public IUserRepository Users { get; private set; }
        public IAlbumRepository Albums { get; private set; }
        public ICloseFriendsRepository CloseFriends { get; private set; }
        public IContentRepositroy Contents { get; private set; }
        public IFavoritesRepository Favorites { get; private set; }
        public IFollowerRepositroy Followers { get; private set; }
        public IHighlightRepository Highlights { get; private set; }
        public IPostCollectionRepository PostCollections { get; private set; }
        public IPostCommentRepository PostComments { get; private set; }
        public IPostRepository Posts { get; private set; }
        public IReactionRepository Reactions { get; private set; }
        public IHashtagRepository Hashtags { get; private set; }
        public ILocationRepository Locations { get; private set; }
        public IPostTagRepository PostTags { get; private set; }

        public XMLContext Context
        {
            get { return context; }
        }
        public int Complete()
        {
            return context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
