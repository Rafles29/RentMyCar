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
        public User AddUser(User newUser)
        {
            _context.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }

        public void DeleteUser(long userID)
        {
            var user = _context.Users.Find(userID);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public User GetUser(long userID)
        {
            return _context.Users.Include(u => u.Cars).ThenInclude(c => c.Rents)
                .Include(u => u.Rents).FirstOrDefault(u => u.UserId == userID);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.Include(u => u.Cars).ThenInclude(c => c.Rents)
                .Include(u => u.Rents).ToList();
        }

        public void UpdateUser(long userID, User updatedUser)
        {
            var originalUser = _context.Users.Find(userID);
            _context.Entry(originalUser).CurrentValues.SetValues(updatedUser);
            _context.SaveChanges();
        }
    }
}
