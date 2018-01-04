using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(string userName);
    }
}
