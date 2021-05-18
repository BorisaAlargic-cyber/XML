using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using XML.Model;
using XML.Repository;

namespace XML.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IConfiguration configuration;

        public TokenController(IConfiguration config)
        {
            configuration = config;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User data)
        {
            if (data == null || data.Username == null || data.Password == null)
            {
                return BadRequest();
            }

            User user = null;

            try
            {
                using (var unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    user = unitOfWork.Users.GetUserWithUsernameAndPassword(data.Username, data.Password);
                }

            }
            catch (Exception e)
            {

            }

            if (user == null)
            {
                return BadRequest("Invalid credentials");
            }

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("Id", user.Id.ToString()),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
                new Claim("Email", user.Email),
                new Claim("Username", user.Username)
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);
            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { tokenString });
        }

    }
}
