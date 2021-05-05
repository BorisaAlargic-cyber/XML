using System;
using Microsoft.EntityFrameworkCore;
using XML.Configuration;

namespace XML.Model
{
    public class XMLContext : DbContext
    {
        public static ProjectConfiguration Configuration;

        public XMLContext(DbContextOptions<XMLContext> context, ProjectConfiguration configuration) : base(context)
        {
            if (configuration != null)
            {
                XMLContext.Configuration = configuration;
            }
        }

        public XMLContext() : base() { }

        public DbSet<User> Users { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<CloseFriends> CloseFriends { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<Highlight> Highlights { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCollection> PostCollections { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Hashtag> Hashtags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseSqlServer(XMLContext.Configuration.DatabaseConfiguration.ConnectionString);
        }
    }
}
