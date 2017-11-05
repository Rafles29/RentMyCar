using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Model
{
    public class CarOwner : Car
    {
        public List<Car> Cars { get; set; }
        public void AddCar(Car car)
        {
            Cars.Add(car);
        }
        public void RemoveCar(int index)
        {
            if (index >= 0 && index < Cars.Count)
            {
                Cars.RemoveAt(index);
            }
            else throw new IndexOutOfRangeException();
        }
        public void RemoveCarID(int carID)
        {
            var car = Cars.Where(c => c.CarID == carID).First();
            if (car == null)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public List<Rent> CarRents { get; set; }

    }
}
