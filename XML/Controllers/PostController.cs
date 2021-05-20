using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using XML.Model;
using XML.Model.Requests;
using XML.Service;

namespace XML.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : DefaultController
    {
        PostService service = new PostService();

        public PostController(IConfiguration config) : base(config)
        {
        }

        [Authorize]
        [HttpPost]
        [Route("/api/posts")]
        public async Task<IActionResult> PublishedPost(AddPostRequest postData)
        {   
            Post post = service.PublishPost(postData, GetCurrentUser());

            if (post == null)
            {
                return BadRequest();
            }

            return Ok(post);
        }

        [Authorize]
        [HttpPut]
        [Route("/api/posts")]
        public async Task<IActionResult> EditPost(Post postData)
        {
            Post post = service.EditPost(postData);

            if (post == null)
            {
                return BadRequest();
            }

            return Ok(post);
        }

        [Authorize]
        [HttpDelete]
        [Route("/api/posts/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            Post post = service.DeletePost(id);

            if (post == null)
            {
                return BadRequest();
            }

            return Ok(post);
        }

        [Authorize]
        [HttpPut]
        [Route("/api/posts/addTag")]
        public async Task<IActionResult> AddTagToPost(AddTagToPostRequest addTagToPost)
        {
            Post post = service.AddTagToPost(addTagToPost);

            if(post == null)
            {
                return BadRequest();
            }

            return Ok(post);
        }


        [Authorize]
        [HttpPut]
        [Route("/api/posts/addLocation")]
        public async Task<IActionResult> AddLocationToPost(AddLocationToPostRequest addLocationToPost)
        {
            Post post = service.AddLocationToPost(addLocationToPost);

            if (post == null)
            {
                return BadRequest();
            }

            return Ok(post);
        }

        [Authorize]
        [HttpPut]
        [Route("/api/posts/like/{postId}")]
        public async Task<IActionResult> LikePost(int postId)
        {
            Reaction reaction = service.Like(GetCurrentUser().Id, postId);

            if(reaction == null)
            {
                return BadRequest();
            }

            return Ok(reaction);
        }
        [Authorize]
        [HttpPut]
        [Route("/api/posts/dislike/{postId}")]
        public async Task<IActionResult> DislikePost(int postId)
        {
            Reaction reaction = service.Dislike(GetCurrentUser().Id, postId);

            if (reaction == null)
            {
                return BadRequest();
            }

            return Ok(reaction);
        }

        [Authorize]
        [HttpPut]
        [Route("/api/posts/comment")]
        public async Task<IActionResult> Comment(AddCommentToPostRequest addCommentToPostRequest)
        {
            User currentUser = GetCurrentUser();

            PostComment postComment = service.Comment(addCommentToPostRequest, currentUser);

            if(postComment == null)
            {
                return BadRequest();
            }

            return Ok(postComment);
        }

        [Authorize]
        [HttpGet]
        [Route("/api/posts/comment/{postId}")]
        public async Task<IActionResult> GetComment(int postId)
        {
            List<PostComment> result = service.GetComments(postId);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [Authorize]
        [HttpPut]
        [Route("/api/posts/favourit/{id}")]
        public async Task<IActionResult> AddToFavorites(int id)
        {
             User currentUser = GetCurrentUser();

            Favorites favorites = service.AddToFavorites(currentUser, id);

            if(favorites == null)
            {
                return BadRequest();
            }

            return Ok(favorites);
        }

        [Authorize]
        [HttpPut]
        [Route("/api/posts/unfavorit/{postId}/{favId}")]
        public async Task<IActionResult> RemoveFromFavorites(int postId,int favId)
        {
           User currentUser = GetCurrentUser();

            Favorites favorites = service.RemoveFromFavorites(currentUser, postId,favId);

            if (favorites == null)
            {
                return BadRequest();
            }

            return Ok(favorites);
        }

        [Authorize]
        [HttpPut]
        [Route("/api/posts/collection")]
        public async Task<IActionResult> CreateCollection(AddNameToPostCollectionRequest addNameToPostCollectionRequest)
        {
           User currentUser = GetCurrentUser();

            PostCollection postCollection = service.CreateCollection(addNameToPostCollectionRequest, currentUser);

            if(postCollection == null)
            {
                return BadRequest();
            }
            return Ok(postCollection);
        }

        [HttpGet]
        [Route("/api/posts/get-posts")]
        public async Task<IActionResult> GetAllPosts()
        {
            IEnumerable<Post> post = service.GetAllPost();

            if (post == null)
            {
                return BadRequest();
            }

            return Ok(post);
        }

        [HttpGet]
        [Route("/api/posts/get-stories")]
        public async Task<IActionResult> GetAllStories()
        {
            IEnumerable<Post> post = service.GetAllStories();

            if (post == null)
            {
                return BadRequest();
            }

            return Ok(post);
        }

        [HttpGet]
        [Route("/api/posts/get-user-posts")]
        public async Task<IActionResult> GetPostForUser()
        {
            User currentUser = GetCurrentUser();

            List<Post> posts = service.GetPostsForUser(currentUser);

            if(posts == null)
            {
                return BadRequest();
            }

            return Ok(posts);
            
        }

    }
}
