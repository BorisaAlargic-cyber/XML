using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    }
}
