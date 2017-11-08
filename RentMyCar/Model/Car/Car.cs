using System;
using System.Collections.Generic;

namespace Model
{
    public class Car
    {
        private static readonly double HPTOKW = 0.745699872;

        public Car()
        {
            Rents = new List<Rent>();
        }

        public int CarId { get; private set; }
        public string Manufactor { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public byte[] AvatarImage { get; set; }
        public AC AC { get; set; }
        public bool Lift { get; set; }
        public int Seats { get; set; }
        public Gearbox Gearbox { get; set; }
        public decimal ShortTermPrice { get; set; }
        public decimal MidTermPrice { get; set; }
        public decimal LongTermPrice { get; set; }
        public BodyType BodyType { get; set; }
        public Colour Colour { get; set; }
        public double ZeroTo100 { get; set; }
        public int HorsePower { get; set; }
        public double MaxSpeed { get; set; }
        public int Millage { get; set; }
        public int KiloWats
        {
            get
            {
                return (int)((double)this.HorsePower * Car.HPTOKW);
            }
        }

        public long UserId { get; set; }
        public User User { get; set; }

        public List<Rent> Rents { get; set; }
    }
}
