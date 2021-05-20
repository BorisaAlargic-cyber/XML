using System;
using System.Collections.Generic;
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
    public class HashtagController : DefaultController
    {
        HashtagService service = new HashtagService();

        public HashtagController(IConfiguration config) : base(config)
        {
        }

        [Authorize]
        [HttpGet]
        [Route("/api/hashtags/{postId}")]
        public async Task<IActionResult> Get(int postId)
        {
            List<PostTag> tags = service.GetForPost(postId);

            if (tags == null)
            {
                return BadRequest();
            }

            return Ok(tags);
        }

        [Authorize]
        [HttpPost]
        [Route("/api/hashtags")]
        public async Task<IActionResult> CreateHashtag(string Name)
        {
            Hashtag tag = service.CreateHashtag(Name);

            if (tag == null)
            {
                return BadRequest();
            }

            return Ok(tag);
        }
    }
}
