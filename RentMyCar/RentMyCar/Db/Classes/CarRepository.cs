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
        private static RentMyCarContext _context;

        public CarRepository(RentMyCarContext context)
        {
            _context = context;
        }
        public Car AddCar(Car newCar)
        {
            _context.Cars.Add(newCar);
            _context.SaveChanges();
            return newCar;
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

        public Price GetPrice(long carId)
        {
            var car = _context.Cars.Find(carId);
            return car.Price;
        }
        public void SetPrice(long carId, Price price)
        {
            var car = _context.Cars.Find(carId);
            car.Price = price;
            _context.SaveChanges();
        }

        public Equipment GetEquipment(long carId)
        {
            var car = _context.Cars.Find(carId);
            return car.Equipment;
        }
        public void SetEquipment(long carId, Equipment eq)
        {
            var car = _context.Cars.Find(carId);
            car.Equipment = eq;
            _context.SaveChanges();
        }

        public Performance GetPerformance(long carId)
        {
            var car = _context.Cars.Find(carId);
            return car.Performance;
        }
        public void SetPerformance(long carId, Performance performance)
        {
            var car = _context.Cars.Find(carId);
            car.Performance = performance;
            _context.SaveChanges();
        }
    }
}
