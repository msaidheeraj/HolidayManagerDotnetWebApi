using HolidayManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayManager.Repository
{
    public class HolidayManagement : IHolidayManagement
    {
        private readonly HolidayContext _context;
        public HolidayManagement(HolidayContext context)
        {
            _context = context;
        }
        public List<Holiday> GetHolidays()
        {
           return _context.Holidays.ToList();
        }

        public List<Holiday> GetPendingApprovals()
        {
            return _context.Holidays.Where(h=>h.status=="pending").ToList();
        }

        public Holiday PostHoliday(Holiday holiday)
        {
            holiday.status = "pending";
            _context.Holidays.Add(holiday);
            _context.SaveChanges();
            return holiday;
        }

        public Holiday Update(Holiday holiday)
        {
            _context.Entry(holiday).State = EntityState.Modified;
            _context.SaveChanges();
            return holiday;

        }
    }
}
