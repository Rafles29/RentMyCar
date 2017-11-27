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
            var car = _context.Cars.Find(carID);
            _context.Cars.Remove(car);
            _context.SaveChanges();
        }
        public Car GetCar(long carID)
        {
            return _context.Cars.Include(c => c.Price).Include(c => c.Performance)
                .Include(c => c.Equipment)
                .FirstOrDefault(c => c.CarId == carID);
        }
        public IEnumerable<Car> GetCars()
        {
            return _context.Cars.Include(c => c.Price).Include(c => c.Performance)
                .Include(c => c.Equipment).AsEnumerable<Car>();
        }
        public void UpdateCar(long carID, Car updatedCar)
        {
            var originalCar = _context.Cars.Find(carID);
            _context.Entry(originalCar).CurrentValues.SetValues(updatedCar);
            _context.SaveChanges();
        }

        public void ChangePrice(long carId, Price price)
        {
            var car = _context.Cars.Find(carId);
            car.Price = price;
            _context.SaveChanges();
        }
        public void ChangeEquipment(long carId, Equipment eq)
        {
            var car = _context.Cars.Find(carId);
            car.Equipment = eq;
            _context.SaveChanges();
        }
        public void ChangePerformance(long carId, Performance performance)
        {
            var car = _context.Cars.Find(carId);
            car.Performance = performance;
            _context.SaveChanges();
        }
    }
}
