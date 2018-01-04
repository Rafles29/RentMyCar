using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Model
{
    public class User : IdentityUser
    {

        public User()
        {
            Rents = new List<Rent>();
            Cars = new List<Car>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public List<Rent> Rents { get; set; }
        public List<Car> Cars { get; set; }

    }
}
