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

        public Post PublishPost(Post post , User user)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    Post dbPost = new Post();

                    dbPost.DateCreated = DateTime.Now;
                    dbPost.PostType = post.PostType;
                    dbPost.User = user;
                    dbPost.Description = post.Description;
                    dbPost.Deleted = false;
                    dbPost.OnlyCloseFriend = post.OnlyCloseFriend;

                    unitOfWork.Posts.Add(post);
                    unitOfWork.Complete();

                    return dbPost;
                }
            }catch(Exception e)
            {
                return null;
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

                    reaction.User = unitOfWork.Users.Get(userId);
                    reaction.Post = unitOfWork.Posts.Get(postId);
                    reaction.ReactionType = ReactionType.Like;

                    unitOfWork.Reactions.Update(reaction);
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

                    reaction.User = unitOfWork.Users.Get(userId);
                    reaction.Post = unitOfWork.Posts.Get(postId);
                    reaction.ReactionType = ReactionType.Dislike;

                    unitOfWork.Reactions.Update(reaction);
                    unitOfWork.Complete();

                    return reaction;
                }
            }catch(Exception e)
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
                    

                    postComment.User = currentUser;
                    postComment.Post = post;
                    postComment.Comment = addCommentToPostRequest.Comment;

                    unitOfWork.PostComments.Update(postComment);
                    unitOfWork.Complete();

                    return postComment;
                }
            }catch(Exception e)
            {
                return null;
            }
        }
    }
}
