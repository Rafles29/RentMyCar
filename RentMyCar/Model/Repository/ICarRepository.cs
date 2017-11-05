using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Repository
{
    interface ICarRepository
    {
        void AddCar(Car newCar);
        IEnumerable<Car> GetCars();
        Car GetCar(long carID);
        void UpdateCar(long carID, Car updatedCar);
        void UpdateCars(IEnumerable<Car> updatedCars);
        void DeleteCar(long carID);
    }
}
