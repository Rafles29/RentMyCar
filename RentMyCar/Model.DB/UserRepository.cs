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
        public void AddUser(User newUser)
        {
            _context.Add(newUser);
            _context.SaveChanges();
        }

        public void DeleteUser(long userID)
        {
            throw new NotImplementedException();
        }

        public User GetUser(long userID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.Include(u => u.Cars).ToList();
        }

        public void UpdateUser(long userID, User updatedUser)
        {
            throw new NotImplementedException();
        }
    }
}
