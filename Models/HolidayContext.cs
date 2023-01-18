using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayManager.Models
{
    public class HolidayContext:DbContext
    {
        public HolidayContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
    }
}
