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
    public class LocationController : DefaultController
    {
        LocationService service = new LocationService();

        public LocationController(IConfiguration config) : base(config)
        {
        }


        [Authorize]
        [HttpPost]
        [Route("/api/locations")]
        public async Task<IActionResult> CreatedLocation(string Name)
        {
            Location location = service.CreateLocation(Name);

            if (location == null)
            {
                return BadRequest();
            }

            return Ok(location);
        }
    }
}
