using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Model.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Model.DB
{
    public class UserRepository : IUserRepository
    {
        private static RentMyCarContext _context;

        public UserRepository(RentMyCarContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.Include(u => u.Cars).ThenInclude(c => c.Rents)
                .Include(u => u.Rents).ToList();
        }
        public User GetUser(string userName)
        {
            return _context.Users.Include(u => u.Cars).ThenInclude(c => c.Rents)
                .Include(u => u.Rents).Where(u => u.UserName == userName).FirstOrDefault();
        }
    }
}
