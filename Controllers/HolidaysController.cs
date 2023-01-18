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
    [ApiController]
    public class HolidaysController : ControllerBase
    {
        
        private readonly IHolidayManagement _repo;

        public HolidaysController(IHolidayManagement repo)
        {
            
            _repo = repo;
        }



        //Get all user holidays
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult GetHolidays()
        {

            return Ok(_repo.GetHolidays());
        }

        //Get approval pending 
        [Authorize(Roles = "admin")]
        [HttpGet("pending")]
        public IActionResult GetPendingApprovals()
        {

            return Ok(_repo.GetPendingApprovals());
        }


        //Approve or deny holiday
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> ApproveOrDeny(int id, Holiday holiday)
        {
            if (id != holiday.Id)
            {
                return BadRequest();
            }

            return Ok(_repo.Update(holiday));
            

        }

        //apply for holiday
        [Authorize(Roles = "user")]
        [HttpPost]
        public IActionResult PostHoliday(Holiday holiday)
        {
            return Ok(_repo.PostHoliday(holiday));


        }

        



    }
}
