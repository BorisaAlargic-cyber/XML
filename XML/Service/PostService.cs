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
    }
}
