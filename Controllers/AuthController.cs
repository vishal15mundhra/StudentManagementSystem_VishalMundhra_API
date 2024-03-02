using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentManagementSystem_VishalMundhra_API.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class AuthController : ControllerBase
        {
            private readonly IConfiguration _config;

            public AuthController(IConfiguration config)
            {
                _config = config;
            }

            [HttpPost("login")]
            public IActionResult Login([FromBody] LoginModel login)
            {
                // You can implement your own authentication logic here.
                // For demonstration purposes, we'll use hardcoded username and password.

                if (login.Username == "admin" && login.Password == "password")
                {
                    var tokenString = GenerateJwtToken(login.Username);
                    return Ok(new { Token = tokenString });
                }

                return Unauthorized();
            }

            private string GenerateJwtToken(string username)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_config["Jwt:Secret"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, username)
                    }),
                    Expires = DateTime.UtcNow.AddHours(1), // Token expiration time
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return tokenString;
            }
        }

        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
}
