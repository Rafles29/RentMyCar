using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Model.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Model.DB
{
    class CarRepository : ICarRepository
    {
        public void AddCar(Car newCar)
        {
            throw new NotImplementedException();
        }

        public void DeleteCar(long carID)
        {
            throw new NotImplementedException();
        }

        public Car GetCar(long carID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> GetCars()
        {
            throw new NotImplementedException();
        }

        public void UpdateCar(long carID, Car updatedCar)
        {
            throw new NotImplementedException();
        }
    }
}
