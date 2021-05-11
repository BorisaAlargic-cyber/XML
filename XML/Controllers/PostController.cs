using System;
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
        public async Task<IActionResult> PublishedPost(Post postData)
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
        [Route("/api/posts/like/{userId}/{postId}")]
        public async Task<IActionResult> LikePost(int postId,int userId)
        {
            Reaction reaction = service.Like(userId, postId);

            if(reaction == null)
            {
                return BadRequest();
            }

            return Ok(reaction);
        }
        [Authorize]
        [HttpPut]
        [Route("/api/posts/like/{userId}/{postId}")]
        public async Task<IActionResult> DislikePost(int postId, int userId)
        {
            Reaction reaction = service.Like(userId, postId);

            if (reaction == null)
            {
                return BadRequest();
            }

            return Ok(reaction);
        }

        [Authorize]
        [HttpPut]
        [Route("/api/posts/comment/id")]
        public async Task<IActionResult> Comment(AddCommentToPostRequest addCommentToPostRequest ,User currentUser)
        {
            currentUser = GetCurrentUser();

            PostComment postComment = service.Comment(addCommentToPostRequest, currentUser);

            if(postComment == null)
            {
                return BadRequest();
            }

            return Ok(postComment);
        }




    }
}
