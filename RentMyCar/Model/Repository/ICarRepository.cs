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
    }
}
