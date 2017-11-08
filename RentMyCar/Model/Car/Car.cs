using System;
using System.Collections.Generic;

namespace Model
{
    public class Car
    {

        public int CarId { get; set; }
        public string Manufactor { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public byte[] AvatarImage { get; set; }
        public Equipment Equipment { get; set; }
        public Price Price { get; set; }
        public BodyType BodyType { get; set; }
        public Colour Colour { get; set; }
        public Performance Performance { get; set; }
        public int Millage { get; set; }

        public long CarOwnerID { get; set; }
        public CarOwner CarOwner { get; set; }

        public List<Rent> Rents { get; set; }
    }
}
