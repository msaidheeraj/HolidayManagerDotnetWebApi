using HolidayManager.Models;
using HolidayManager.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HolidayManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private const int TIMEOUT = 30;
        private IConfiguration _config;       
        private readonly IUserManagement _repo;
        public LoginController(IConfiguration config, IUserManagement repo)
        {
            _config = config;
            _repo = repo;
            
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] Login login)
        {
            var User = Authenticate(login);

            if (User != null)
            {
                var token = Generate(User);

                var package = new  { Token = token, Role = User.Role ,Expiry=TIMEOUT};

                return Ok(package);
            }

            return Ok(new  { Token = "", Role = "Invalid" });
        }

        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {

                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
              _config["Tokens:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(TIMEOUT),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        

        private User Authenticate(Login login)
        {
            var currentUser = _repo.GetUser(login);

            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }


       
    }
}
