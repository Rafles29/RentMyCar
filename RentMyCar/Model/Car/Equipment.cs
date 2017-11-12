using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Equipment
    {
        public long EquipmentId { get; set; }
        public AC AC { get; set; }
        public bool Lift { get; set; }
        public int Seats { get; set; }
        public Gearbox Gearbox { get; set; }
        public BodyType BodyType { get; set; }
        public Colour Colour { get; set; }

        public Car Car { get; set; }
        public long CarId { get; set; }
    }
}
