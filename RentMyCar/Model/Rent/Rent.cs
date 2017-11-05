using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Rent
    {
        public long ID { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public long CarID { get; set; }
        public Car Car { get; set; }

        public long UserID { get; set; }
        public User User { get; set; }

        public long CarOwnerID { get; set; }
        public CarOwner CarOwner { get; set; }

    }
}
