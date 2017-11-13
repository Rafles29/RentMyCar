using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Model.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Model.DB
{
    public class CarRepository : ICarRepository
    {
        private static RentMyAppContext _context;
        public CarRepository()
        {
            _context = new RentMyAppContext();
        }
        public CarRepository(RentMyAppContext context)
        {
            _context = context;
        }
        public void AddCar(Car newCar)
        {
            _context.Cars.Add(newCar);
            _context.SaveChanges();
        }

        public void DeleteCar(long carID)
        {
            throw new NotImplementedException();
        }

        public Car GetCar(long carID)
        {
            return _context.Cars.Find(carID);
        }

        public IEnumerable<Car> GetCars()
        {
            return _context.Cars.AsEnumerable<Car>();
        }

        public void UpdateCar(long carID, Car updatedCar)
        {
            var originalCar = _context.Cars.Find(carID);
            _context.Entry(originalCar).CurrentValues.SetValues(updatedCar);
            _context.SaveChanges();
        }
    }
}
