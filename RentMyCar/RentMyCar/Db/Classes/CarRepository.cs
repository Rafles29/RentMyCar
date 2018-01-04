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
        public Car AddCar(string userName, Car newCar)
        {
            var user = _context.Users.Where(u => u.UserName == userName).FirstOrDefault();
            user.Cars.Add(newCar);
            _context.SaveChanges();
            return newCar;
        }
        public void DeleteCar(string userName, long carID)
        {
            var car = _context.Cars.Where(c => c.User.UserName == userName && c.CarId == carID).FirstOrDefault();
            if (car == null)
            {
                throw new UnauthorizedAccessException();
            }
            _context.Cars.Remove(car);
            _context.SaveChanges();
        }
        public Car GetCar(long carId)
        {
            return _context.Cars.Include(c => c.Price).Include(c => c.Performance)
                .Include(c => c.Equipment).Include(c => c.User)
                .FirstOrDefault(c => c.CarId == carId);
        }
        public IEnumerable<Car> GetCars()
        {
            return _context.Cars.Include(c => c.Price).Include(c => c.Performance)
                .Include(c => c.Equipment).Include(c => c.User).AsEnumerable<Car>();
        }
        public IEnumerable<Car> GetCars(string userName)
        {
            return _context.Cars.Where(c => c.User.UserName == userName)
                .Include(c => c.Price)
                .Include(c => c.Performance)
                .Include(c => c.Equipment)
                .Include(c => c.User)
                .AsEnumerable<Car>();
        }
        public void UpdateCar(string userName, long carId, Car updatedCar)
        {
            var originalCar = _context.Cars.Include(c => c.User).Where(c => c.User.UserName == userName && c.CarId == carId).FirstOrDefault();
            if (originalCar == null)
            {
                throw new UnauthorizedAccessException();
            }
            _context.Entry(originalCar).CurrentValues.SetValues(updatedCar);
            _context.SaveChanges();
        }

        public Price GetPrice(long carId)
        {
            var car = _context.Cars.Find(carId);
            return car.Price;
        }
        public void SetPrice(string userName, long carId, Price price)
        {
            var car = _context.Cars.Include(c => c.User).Where(c => c.User.UserName == userName && c.CarId == carId).FirstOrDefault();
            if (car == null)
            {
                throw new UnauthorizedAccessException();
            }
            car.Price = price;
            _context.SaveChanges();
        }

        public Equipment GetEquipment(long carId)
        {
            var car = _context.Cars.Find(carId);
            return car.Equipment;
        }
        public void SetEquipment(string userName, long carId, Equipment eq)
        {
            var car = _context.Cars.Include(c => c.User).Where(c => c.User.UserName == userName && c.CarId == carId).FirstOrDefault();
            if (car == null)
            {
                throw new UnauthorizedAccessException();
            }
            car.Equipment = eq;
            _context.SaveChanges();
        }

        public Performance GetPerformance(long carId)
        {
            var car = _context.Cars.Find(carId);
            return car.Performance;
        }
        public void SetPerformance(string userName, long carId, Performance performance)
        {
            var car = _context.Cars.Include(c => c.User).Where(c => c.User.UserName == userName && c.CarId == carId).FirstOrDefault();
            if (car == null)
            {
                throw new UnauthorizedAccessException();
            }
            car.Performance = performance;
            _context.SaveChanges();
        }

       
    }
}
