using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using XML.Model;
using XML.Repository;

namespace XML.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private IConfiguration configuration;

        public DefaultController(IConfiguration config)
        {
            configuration = config;
        }

        protected User GetCurrentUser()
        {
            string username = HttpContext.User.Claims.FirstOrDefault(u => u.Type == "Username")?.Value;

            User user = null;

            try
            {
                using (var unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    user = unitOfWork.Users.GetUserWithUsername(username);
                }
            }
            catch (Exception e)
            {

            }

            return user;
        }
    }
}
