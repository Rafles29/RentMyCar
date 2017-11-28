using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Rent
    {
        public long RentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Car Car { get; set; }
        public long CarId { get; set; }

        public User User { get; set; }
        public long UserId { get; set; }

        public Adress Adress { get; set; }
    }
}
