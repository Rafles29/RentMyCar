using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public long UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Login { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Mail { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public List<Rent> Rents { get; set; }

        public List<Car> Cars { get; set; }

    }
}
