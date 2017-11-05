using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;



namespace Model
{
    public class User
    {
        public long ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        private double _rating = 0;
        public double Rating { get;}
        private List<int> _ratings = new List<int>();
        public void AddRating(int newRating)
        {
            this._ratings.Add(newRating);
            this._rating = _ratings.Average();
        }
        public List<Rent> Rents { get; set; }

    }
}
