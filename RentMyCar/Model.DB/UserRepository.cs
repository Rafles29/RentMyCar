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
        private static RentMyAppContext _context;
        public UserRepository()
        {
            _context = new RentMyAppContext();
        }
        public UserRepository(RentMyAppContext context)
        {
            _context = context;
        }
        public void AddUser(User newUser)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void UpdateUser(long userID, User updatedUser)
        {
            throw new NotImplementedException();
        }
    }
}
