using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace RentMyCar.ViewModels
{
    public class RentView
    {
        public long RentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public CarView Car { get; set; }

        public UserView User { get; set; }

        public AdressView Adress { get; set; }
    }
}
