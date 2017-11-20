using System;
using System.Collections.Generic;

namespace Model
{
    public class Car
    {
        public Car()
        {
            Rents = new List<Rent>();
        }
        public Car(string manufactor, string model, int year, byte[] image,
            Performance performance, Equipment equipment, Price price,
            User user)
        {
            this.Manufactor = manufactor;
            this.Model = model;
            this.Year = year;
            this.AvatarImage = image;

            this.Performance = performance;
            this.Equipment = equipment;
            this.Price = price;

            this.User = User;
            this.UserId = User.UserId;
            this.Rents = new List<Rent>();
        }

        public long CarId { get; set; }
        public string Manufactor { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public byte[] AvatarImage { get; set; }

        public Performance Performance { get; set; }
        public Equipment Equipment { get; set; }
        public Price Price { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }

        public List<Rent> Rents { get; set; }
    }
}
