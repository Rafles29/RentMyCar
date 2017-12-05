using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Repository
{
    public interface ICarRepository
    {
        Car AddCar(Car newCar);
        IEnumerable<Car> GetCars();
        Car GetCar(long carID);
        void UpdateCar(long carID, Car updatedCar);
        void DeleteCar(long carID);

        Price GetPrice(long carId);
        void SetPrice(long carId, Price price);

        Equipment GetEquipment(long carId);
        void SetEquipment(long carId, Equipment eq);

        Performance GetPerformance(long carId);
        void SetPerformance(long carId, Performance performance);
    }
}
