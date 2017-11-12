using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Performance
    {
        public long PerformanceId { get; set; }

        public double ZeroTo100 { get; set; }
        public int HorsePower { get; set; }
        public double MaxSpeed { get; set; }
        public int Millage { get; set; }
        public int KiloWats
        {
            get
            {
                return (int)((double)this.HorsePower * Performance.HPTOKW);
            }
        }
        private static readonly double HPTOKW = 0.745699872;

        public Car Car { get; set; }
        public long CarId { get; set; }
    }
}
