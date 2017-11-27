using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Price
    {

        public Price()
        {
            this.ShortTermPrice = 0;
            this.MidTermPrice = 0;
            this.LongTermPrice = 0;
        }
        public Price(decimal st)
        {
            this.ShortTermPrice = st;
            this.MidTermPrice = st * 5;
            this.LongTermPrice = st * 15;
        }
        public Price(decimal st, decimal mt, decimal lt)
        {
            this.ShortTermPrice = st;
            this.MidTermPrice = mt;
            this.LongTermPrice = lt;
        }
        public Price(decimal st, decimal mt, decimal lt, Car car)
        {
            this.ShortTermPrice = st;
            this.MidTermPrice = mt;
            this.LongTermPrice = lt;

            this.Car = car;
            this.CarId = car.CarId;
        }
        public long PriceId { get; set; }
        public decimal ShortTermPrice { get; set; }
        public decimal MidTermPrice { get; set; }
        public decimal LongTermPrice { get; set; }

        public Car Car { get; set; }
        public long CarId { get; set; }
    }
}
