using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Repository
{
    public interface IUserRepository
    {
        void AddUser(User newUser);
        IEnumerable<User> GetUsers();
        User GetUser(long userID);
        void UpdateUser(long userID, User updatedUser);
        void DeleteUser(long userID);
    }
}
