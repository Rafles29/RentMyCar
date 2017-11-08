using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Rent
    {
        public long RentId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public long CarId { get; set; }
        public Car Car { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }

        public long CarOwnerId { get; set; }
        public CarOwner CarOwner { get; set; }

    }
}
