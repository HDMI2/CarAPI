using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CarWebApi.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CarWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TokenController : Controller
    {
        private Microsoft.Extensions.Configuration.IConfiguration _config;

        public TokenController(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _config = configuration;

        }
        private int GetUserIdFromLogin(LoginDto loginDto)
        {
            var userId = -1;
            if (loginDto.Username.Equals("admin") && loginDto.Password.Equals("admin"))
            {
                userId = 1234;
            }
            return userId;
        }

        [HttpPost]
        public IActionResult RequestToken([FromBody] LoginDto user)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = GetUserIdFromLogin(user);
            if (userId == -1)
            {
                return Unauthorized();
            }

            // Claims erstellen (Key, Value Teile des Nutzers)
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            // Token erstellen auf Basis der Claims
            var token = new JwtSecurityToken
                (
                    issuer: _config["Issuer"],
                    audience: _config["Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(60),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(_config["SigningKey"])),
                            SecurityAlgorithms.HmacSha256)
                );


            //Token ausgeben

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}