using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Repository
{
    public interface ICarRepository
    {
        Car AddCar(Car newCar);
        IEnumerable<Car> GetCars();
        IEnumerable<Car> GetCars(string userName);
        Car GetCar(long carID);
        void UpdateCar(string userName, long carID, Car updatedCar);
        void DeleteCar(string userName, long carID);

        Price GetPrice(long carId);
        void SetPrice(string userName, long carId, Price price);

        Equipment GetEquipment(long carId);
        void SetEquipment(string userName, long carId, Equipment eq);

        Performance GetPerformance(long carId);
        void SetPerformance(string userName, long carId, Performance performance);
    }
}
