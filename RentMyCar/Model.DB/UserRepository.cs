using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Model.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Model.DB
{
    class UserRepository : IUserRepository
    {
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
