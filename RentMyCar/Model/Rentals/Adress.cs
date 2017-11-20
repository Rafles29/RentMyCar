using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Adress
    {
        public long AdressId { get; set; }

        public string City { get; set; }
        public string PostalCode { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }

        public Rent Rent { get; set; }
        public long RentId { get; set; }

    }
}
