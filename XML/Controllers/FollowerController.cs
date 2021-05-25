using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using XML.Model;
using XML.Service;

namespace XML.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowerController : DefaultController
    {
        FollowerService service = new FollowerService();

        public FollowerController(IConfiguration config) : base(config)
        {
        }

        [Authorize]
        [HttpPut]
        [Route("/api/follower/{userId}")]
        public async Task<IActionResult> Following(int userId)
        {
            User currentUser = GetCurrentUser();
            Follower follower = service.Following(userId, currentUser);
            if(follower == null)
            {
                return BadRequest();
            }

            return Ok(follower);
        }

        [Authorize]
        [HttpPut]
        [Route("/api/follower/accept/{id}")]
        public async Task<IActionResult> Accept(int id)
        {
            Follower follower = service.Accept(id);

            if(follower == null)
            {
                return BadRequest();
            }

            return Ok(follower);

        }

        [Authorize]
        [HttpPut]
        [Route("/api/follower/declined/{id}")]
        public async Task<IActionResult> Decline(int id)
        {
            Follower follower = service.Decline(id);

            if(follower == null)
            {
                return BadRequest();
            }

            return Ok(follower);
        }

        [Authorize]
        [HttpPut]
        [Route("/api/follower/is-following/{id}")]
        public async Task<IActionResult> CheckFollowing(int id)
        {
            User currentUser = GetCurrentUser();
            Follower isFollowing = service.CheckFollowing(id, currentUser);

            return Ok(isFollowing);
        }

        [Authorize]
        [HttpPut]
        [Route("/api/follower/un-follow/{id}")]
        public async Task<IActionResult> UnFollow(int id)
        {
            User currentUser = GetCurrentUser();
            Follower follower = service.UnFollow(currentUser, id);
            return Ok(follower);
        }
    }
}
