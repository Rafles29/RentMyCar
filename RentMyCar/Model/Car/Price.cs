

using System;

namespace Model
{
    public class Price
    {
        public long PriceId { get; set; }
        public Price(decimal st)
        {
            if (st < 0)
            {
                throw new ArgumentException("Price cannot be bellow zero");
            }
            else
            {
                this.ShortTerm = st;
                this.MidTerm = this.ShortTerm * 5;
                this.LongTerm = this.MidTerm * 3;
            }
            
        }
        public Price(decimal st, decimal mt, decimal lt)
        {
            if(st < 0 || mt <0 || lt < 0)
            {
                throw new ArgumentException("Price cannot be bellow zero");
            }
            else
            {
                this.ShortTerm = st;
                this.MidTerm = mt;
                this.LongTerm = lt;
            }

        }
        public decimal ShortTerm { get; set; }
        public decimal MidTerm { get; set; }
        public decimal LongTerm { get; set; }
       
    }
}