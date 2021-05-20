using System;
using System.Collections.Generic;
using XML.Model;
using XML.Model.Requests;
using XML.Repository;

namespace XML.Service
{
    
    public class PostService
    {
        public PostService()
        {
        }

        public Post PublishPost(AddPostRequest post , User user)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    Post dbPost = new Post();

                    User userDb = unitOfWork.Users.Get(user.Id);
                    unitOfWork.Users.Detach(userDb);

                    dbPost.DateCreated = DateTime.Now;
                    dbPost.PostType = post.PostType;
                    
                    dbPost.Description = post.Description;
                    dbPost.Deleted = false;
                    dbPost.OnlyCloseFriend = post.OnlyCloseFirends;

                    unitOfWork.Posts.Add(dbPost);
                    unitOfWork.Complete();

                    unitOfWork.Posts.Update(dbPost);
                    dbPost.User = userDb;
                    unitOfWork.Complete();

                    Content content = new Content();
                    content.FileContent = post.FileContent;
                    content.ContentPost = dbPost;

                    unitOfWork.Contents.Add(content);
                    unitOfWork.Complete();

                    Location location = unitOfWork.Locations.GetLocationWithName(post.Location);

                    if (location == null)
                    {
                        location = new Location();
                        location.Name = post.Location;
                        location.Deleted = false;

                        unitOfWork.Locations.Add(location);
                        unitOfWork.Complete();
                    }

                    dbPost.Location = location;
                    unitOfWork.Complete();


                    string[] tags = post.Tags.Split(' ');

                    foreach (string tag in tags)
                    {
                        if (tag == string.Empty)
                        {
                            continue;
                        }

                        Hashtag hashtag = unitOfWork.Hashtags.GetTagWithName(tag);

                        if (hashtag == null)
                        {
                            hashtag = new Hashtag();
                            hashtag.Name = tag;

                            unitOfWork.Hashtags.Add(hashtag);
                            unitOfWork.Complete();
                        }

                        PostTag postTag = new PostTag();
                        postTag.Post = dbPost;
                        postTag.Hashtag = hashtag;

                        unitOfWork.PostTags.Add(postTag);
                        unitOfWork.Complete();
                    }

                    return dbPost;
                }
            } catch(Exception e)
            {
                return null;
            }
        }

        public IEnumerable<Post> GetAllPost()
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    IEnumerable<Post> posts = unitOfWork.Posts.GetAllPosts();

                    if(posts == null)
                    {
                        return new List<Post>();
                    }

                    return posts;
                    
                }
            }
            catch (Exception e)
            {
                return new List<Post>();
            }

        }

        public IEnumerable<Post> GetAllStories()
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    IEnumerable<Post> posts = unitOfWork.Posts.GetAllStories();

                    if (posts == null)
                    {
                        return new List<Post>();
                    }

                    return posts;

                }
            }
            catch (Exception e)
            {
                return new List<Post>();
            }

        }
        public Post EditPost(Post post)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    Post dbPost = unitOfWork.Posts.Get(post.Id);

                    dbPost.PostType = post.PostType;
                    dbPost.Description = post.Description;
                    dbPost.OnlyCloseFriend = post.OnlyCloseFriend;

                    unitOfWork.Posts.Update(post);
                    unitOfWork.Complete();

                    return dbPost;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Post DeletePost(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    Post dbPost = unitOfWork.Posts.Get(id);

                    dbPost.Deleted = true;

                    unitOfWork.Posts.Update(dbPost);
                    unitOfWork.Complete();

                    return dbPost;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Post AddTagToPost(AddTagToPostRequest addTagToPost)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    Post dbPost = unitOfWork.Posts.Get(addTagToPost.Id);

                    if(dbPost == null)
                    {
                        return null;
                    }

                    HashtagService service = new HashtagService();

                    PostTag dbPostTag = new PostTag();

                    dbPostTag.Hashtag = service.CreateHashtag(addTagToPost.Name);
                    dbPostTag.Post = dbPost;

                    unitOfWork.PostTags.Update(dbPostTag);
                    unitOfWork.Complete();

                    return dbPost;
                }

            }catch(Exception ee)
            {
                return null;
            }
        }

        public Post AddLocationToPost(AddLocationToPostRequest addLocationToPostRequest)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    Post dbPost = unitOfWork.Posts.Get(addLocationToPostRequest.Id);

                    if(dbPost == null)
                    {
                        return null;
                    }

                    LocationService service = new LocationService();

                    dbPost.Location = service.CreateLocation(addLocationToPostRequest.Name);

                    unitOfWork.Posts.Update(dbPost);
                    unitOfWork.Complete();

                    return dbPost;

                }
            }catch(Exception ee)
            {
                return null;
            }
        }
        public List<PostTag> SearchPostByHashTag(string Name)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    Hashtag hashtag = unitOfWork.Hashtags.GetTagWithName(Name);

                    if(hashtag == null)
                    {
                        return new List<PostTag>();
                    }

                    List<PostTag> postTag = unitOfWork.PostTags.GetPostsWithTags(hashtag.Id);

                    return postTag;
                }
            }catch(Exception ee)
            {
                return new List<PostTag>();
            }
        }

        public List<Post> SearchPostByLocation(string Name)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    List<Post> posts = unitOfWork.Posts.GetPostWithLocation(Name);

                    if (posts == null)
                    {
                        return  new List<Post>();
                    }

                    return posts;

                }
            }catch(Exception ee)
            {
                return new List<Post>();
            }
        }

        public Reaction Like(int userId,int postId)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    Reaction reaction = new Reaction();
                    Post post = unitOfWork.Posts.Get(postId);
                    

                    reaction.User = unitOfWork.Users.Get(userId);
                    reaction.Post = unitOfWork.Posts.Get(postId);
                    reaction.ReactionType = ReactionType.Like;
                    post.likeCount++;
                    unitOfWork.Reactions.Add(reaction);
                    unitOfWork.Complete();

                   

                    return reaction;
                }
            }catch(Exception e)
            {
                return null;
            }
        }

        public Reaction Dislike(int userId,int postId)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    Reaction reaction = new Reaction();
                    Post post = unitOfWork.Posts.Get(postId);

                    reaction.User = unitOfWork.Users.Get(userId);
                    reaction.Post = unitOfWork.Posts.Get(postId);
                    reaction.ReactionType = ReactionType.Dislike;
                    post.dislikeCount++;
                    unitOfWork.Reactions.Add(reaction);

                    unitOfWork.Complete();

                    return reaction;
                }
            }catch(Exception e)
            {
                return null;
            }
        }

        public List<PostComment> GetComments(int postId)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    List<PostComment> comments = unitOfWork.PostComments.GetCommentsForPostId(postId);

                    return comments;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public PostComment Comment(AddCommentToPostRequest addCommentToPostRequest,User currentUser)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    Post post = unitOfWork.Posts.Get(addCommentToPostRequest.id);
                    

                    PostComment postComment = new PostComment();

                    postComment.Post = post;
                    postComment.Comment = addCommentToPostRequest.Comment;
                    post.commentCount++;

                    unitOfWork.PostComments.Add(postComment);

                    unitOfWork.Complete();

                    User user = unitOfWork.Users.Get(currentUser.Id);
                    unitOfWork.Users.Detach(user);
                    postComment.User = user;
                    unitOfWork.PostComments.Update(postComment);
                    unitOfWork.Complete();

                    return postComment;
                }
            }catch(Exception e)
            {
                return null;
            }
        }

        public Favorites AddToFavorites(User currentUser,int postId)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    Favorites favorites = new Favorites();
                    Post post = unitOfWork.Posts.Get(postId);

                    favorites.User = currentUser;
                    favorites.FavouritedPost = post;
                    favorites.Favourited = true;

                    unitOfWork.Favorites.Update(favorites);
                    unitOfWork.Complete();

                    return favorites;
                }
            }catch(Exception e)
            {
                return null;
            }
        }

        public Favorites RemoveFromFavorites(User currentUser,int postId,int favId)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    Post post = unitOfWork.Posts.Get(postId);
                    Favorites favorites = unitOfWork.Favorites.Get(favId);

                    favorites.User = currentUser;
                    favorites.FavouritedPost = post;
                    favorites.Favourited = false;

                    unitOfWork.Favorites.Update(favorites);
                    unitOfWork.Complete();

                    return favorites;
                }
            }catch(Exception e)
            {
                return null;
            }
        }

        public PostCollection CreateCollection(AddNameToPostCollectionRequest addNameToPostCollectionRequest ,User currentUser)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    Post post = unitOfWork.Posts.Get(addNameToPostCollectionRequest.Id);
                    PostCollection postCollection = new PostCollection();

                    postCollection.Post = post;
                    postCollection.User = currentUser;
                    postCollection.Name = addNameToPostCollectionRequest.Name;


                    unitOfWork.PostCollections.Update(postCollection);
                    unitOfWork.Complete();

                    return postCollection;

                }
            }catch(Exception e)
            {
                return null;
            }

            
        }

        public List<Post> GetPostsForUser(User currentUser)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    List<Post> posts = unitOfWork.Posts.GetAllPostsWithUserId(currentUser);

                    if (posts == null)
                    {
                        return new List<Post>();
                    }

                    return posts;

                }

            }
            catch (Exception e)
            {
                return new List<Post>();
            }

        }
    }
}
