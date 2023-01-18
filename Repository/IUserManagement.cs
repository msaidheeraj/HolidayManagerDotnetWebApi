using HolidayManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayManager.Repository
{
    public interface IUserManagement
    {
        User CreateUser(User user);
        User UpdateUser(int id, User user);
        void DeleteUser(int id);
        User GetUser(Login login);

        
    }
}
