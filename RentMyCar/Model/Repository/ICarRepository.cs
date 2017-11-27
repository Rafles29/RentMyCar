using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Repository
{
    public interface ICarRepository
    {
        void AddCar(Car newCar);
        IEnumerable<Car> GetCars();
        Car GetCar(long carID);
        void UpdateCar(long carID, Car updatedCar);
        void DeleteCar(long carID);

        Price GetPrice(long carId);
        void ChangePrice(long carId, Price price);

        Equipment GetEquipment(long carId);
        void ChangeEquipment(long carId, Equipment eq);

        Performance GetPerformance(long carId);
        void ChangePerformance(long carId, Performance performance);
    }
}
