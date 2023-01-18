using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HolidayManager.Models;
using Microsoft.AspNetCore.Authorization;
using HolidayManager.Repository;

namespace HolidayManager.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles ="admin")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        
        private readonly IUserManagement _repo;

        public UsersController(IUserManagement repo)
        {
            _repo = repo;
        }

        //Register new User
        [HttpPost]
        public IActionResult Register(User user)
        {
           return  Ok(_repo.CreateUser(user));
           
        }

        //Delete user
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _repo.DeleteUser(id);
            return Ok();
        }



       
    }
}
