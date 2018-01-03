using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace RentMyCar.ViewModels
{
    public class CarView
    {
        public long CarId { get; set; }
        public string Manufactor { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public byte[] AvatarImage { get; set; }

        public PerformanceView Performance { get; set; }
        public EquipmentView Equipment { get; set; }
        public PriceView Price { get; set; }

        public UserView User { get; set; }

        public List<RentView> Rents { get; set; }
    }
}
