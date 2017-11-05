using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Repository
{
    interface IUserRepository
    {
        void AddUser(User newUser);
        IEnumerable<User> GetUsers();
        User GetUser(long userID);
        void UpdateUser(long userID, User updatedUser);
        void UpdateUsers(IEnumerable<User> updatedUsers);
        void DeleteUser(long userID);
    }
}
