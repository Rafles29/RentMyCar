using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Price
    {
        public long PriceId { get; set; }
        public decimal ShortTermPrice { get; set; }
        public decimal MidTermPrice { get; set; }
        public decimal LongTermPrice { get; set; }

        public Car Car { get; set; }
        public long CarId { get; set; }
    }
}
