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
            Login = "";
            Password = "";
            Mail = "";
            PhoneNumber = "";
            Rents = new List<Rent>();
            Cars = new List<Car>();
        }
        public User(string login, string password, string mail, string phoneNumber)
        {
            Login = login;
            Password = password;
            Mail = mail;
            PhoneNumber = phoneNumber;
            Rents = new List<Rent>();
            Cars = new List<Car>();

        }
        public User(long id, string login, string password, string mail, string phoneNumber)
        {
            UserId = id;
            Login = login;
            Password = password;
            Mail = mail;
            PhoneNumber = phoneNumber;
            Rents = new List<Rent>();
            Cars = new List<Car>();

        }
        public long UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }

        public List<Rent> Rents { get; set; }

        public List<Car> Cars { get; set; }

    }
}
