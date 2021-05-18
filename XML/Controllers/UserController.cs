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
    public class UserController : DefaultController
    {
        UserService service = new UserService();

        public UserController(IConfiguration config) : base(config)
        {
        }

        [Authorize]
        [HttpGet]
        [Route("/api/users/get-current")]
        public async Task<IActionResult> GetCurrent()
        {
            User user = GetCurrentUser();

            if (user == null)
            {
                return BadRequest();
            }

            return Ok(user);
        }

        [Authorize]
        [HttpGet]
        [Route("/api/users/search-public/{search}")]
        public async Task<IActionResult> SearchPublic(string search)
        {
            return Ok(service.GetPublicProfiles(search));
        }

        [HttpPost]
        [Route("/api/users")]
        public async Task<IActionResult> Register(User userData)
        {
            User user = service.Register(userData);

            if (user == null)
            {
                return BadRequest();
            }

            return Ok(user);
        }

        [Authorize]
        [HttpPost]
        [Route("/api/users/addClose/{closeFrinedId}")]
        public async Task<IActionResult> AddToCloseFriends(int closeFriendId)
        {
           User currentUser = GetCurrentUser();
            CloseFriends closeFriends = service.AddToCloseFriends(currentUser, closeFriendId);

            if(closeFriends == null)
            {
                return BadRequest();
            }

            return Ok(closeFriends);
        }

        [Authorize]
        [HttpPost]
        [Route("/api/users/removeClose/{closeFriendId}")]
        public async Task<IActionResult> RemoveFromCloseFriends( int closeFriendId)
        {
            
            CloseFriends closeFriends = service.RemoveFromCloseFriends(closeFriendId);

            if (closeFriends == null)
            {
                return BadRequest();
            }

            return Ok(closeFriends);
        }


        [Authorize]
        [HttpPost]
        [Route("/api/users/edit")]
        public async Task<IActionResult> EditUser(User userData)
        {
            User user = service.EditProfile(userData);

            if (user == null)
            {
                return BadRequest();
            }

            return Ok(user);
        }


    }
}
