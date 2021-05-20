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
    public class ContentController : DefaultController
    {
        ContentService service = new ContentService();

        public ContentController(IConfiguration config) : base (config)
        {

        }

        [Authorize]
        [HttpGet]
        [Route("/api/contents/{postId}")]
        public async Task<IActionResult> GetContent(int postId)
        {
            Content content = service.GetContentForPost(postId);

            if (content == null)
            {
                return BadRequest();
            }

            return Ok(content);
        }
    }
}
