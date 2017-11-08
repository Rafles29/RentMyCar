using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Model
{
    public class User
    {
        public User()
        {
            Login = "test";
            Password = "test1";
            Mail = "mail";
            PhoneNumber = "123";
            Rents = new List<Rent>();
        }
        public long UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }

        public List<Rent> Rents { get; set; }

    }
}
