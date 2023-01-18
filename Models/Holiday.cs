using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayManager.Models
{
    public class Holiday
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }
        public string status { get; set; }
    }
}
