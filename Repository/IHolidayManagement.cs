using HolidayManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayManager.Repository
{
    public interface IHolidayManagement
    {
        List<Holiday> GetHolidays();
        List<Holiday> GetPendingApprovals();
        Holiday PostHoliday(Holiday holiday);
        Holiday Update(Holiday holiday);


    }
}
