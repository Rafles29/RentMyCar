using Model;

namespace RentMyCar.ViewModels
{
    public class EquipmentView
    {
        public AC AC { get; set; }
        public bool Lift { get; set; }
        public int Seats { get; set; }
        public Gearbox Gearbox { get; set; }
        public BodyType BodyType { get; set; }
        public Colour Colour { get; set; }
    }
}
