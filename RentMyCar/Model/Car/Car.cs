using System;

namespace Model
{
    public class Car
    {

        public int CarID { get; set; }
        public string Manufactor { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public byte[] AvatarImage { get; set; }
        public Equipment Equipment { get; set; }
        public Price Price { get; set; }
        public BodyType BodyType { get; set; }
        public Colour MyProperty { get; set; }
        public Performance Performance { get; set; }

        public string CarOwner { get; set; }
        public User User { get; set; }

    }
}
