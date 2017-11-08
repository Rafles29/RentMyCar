using System;
namespace Model
{
    public class Equipment
    {
        public long EquipmentId { get; set; }
        public Equipment(AC ac, bool lf, int seats, Gearbox gb)
        {
            if(seats < 0)
            {
                throw new ArgumentException("Nmb of Seats cannot be bellow zero");
            }
            else
            {
                this.AC = ac;
                this.Lift = lf;
                this.Seats = seats;
                this.Gearbox = gb;
            }

        }
        public AC AC { get; set; }
        public bool Lift { get; set; }
        public int Seats { get; set; }
        public Gearbox Gearbox { get; set; }
    }
}