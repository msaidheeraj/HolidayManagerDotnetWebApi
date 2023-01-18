using HolidayManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayManager.Repository
{
    public class UserManagement : IUserManagement
    {
        private readonly HolidayContext _context;

        public UserManagement(HolidayContext context)
        {
            _context = context;
        }

        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void DeleteUser(int id)
        {
            var user =  _context.Users.Find(id);
            _context.Users.Remove(user);
             _context.SaveChanges();

          
        }

        public User GetUser(Login login)
        {
           


            var user = _context.Users.ToList()
                .FirstOrDefault(o => o.Username.ToLower() == login.Username.ToLower() && o.Password == login.Password); ;


            return user;
        }

        public User UpdateUser(int id,User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return user;
        }
    }
}
