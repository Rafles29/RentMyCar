using System;
namespace Model
{
    public class Performance
    {
        public long PerformanceId { get; set; }
        private static readonly double HPTOKW = 0.745699872;
        public Performance(int hp, double zero, int max)
        {
            if(hp < 0 || zero < 0 || max < 0)
            {
                throw new ArgumentException("Perfomance cannot be bellow zero");
            }
            this.HorsePower = hp;
            this.ZeroTo100 = zero;
            this.MaxSpeed = max;
        }

        private int _horsePower;
        public int HorsePower
        {
            get
            {
                return _horsePower;
            }
            set
            {
                _horsePower = value;
            }
        }
        public int KiloWats
        {
            get
            {
                return (int)((double)this.HorsePower * Performance.HPTOKW);
            }
        }

        private double _zeroTo100;
        public double ZeroTo100
        {
            get
            {
                return _zeroTo100;
            }
            set
            {
                _zeroTo100 = value;
            }
        }

        private int _maxSpeed;
        public int MaxSpeed
        {
            get
            {
                return _maxSpeed;
            }
            set
            {
                _maxSpeed = value;
            }
        }
    }
}