using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentMyCar.ViewModels
{
    public class UserView
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<CarView> Cars { get; set; }
        public IEnumerable<RentView> Rents { get; set; }
    }
}
