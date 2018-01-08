using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Model.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Model.DB
{
    public class RentRepository : IRentRepository
    {
        private static RentMyCarContext _context;

        public RentRepository(RentMyCarContext context)
        {
            _context = context;
        }
        public Rent AddRent(string userName, Rent newRent)
        {
            var user = _context.Users.Include(u => u.Rents).Where(u => u.UserName == userName).FirstOrDefault();
            newRent.User = user;
            var car = _context.Cars.Where(c => c.CarId == newRent.CarId).FirstOrDefault();
            newRent.Car = car;
            if(car == null)
            {
                throw new ArgumentException();
            }
            _context.Rents.Add(newRent);
            _context.SaveChanges();
            return newRent;
        }

        public void DeleteRent(string userName, long rentID)
        {
            var rent = _context.Rents
                .Include(r => r.User)
                .Include(r => r.Car)
                .Include(r => r.Adress)
                .Where(r => r.User.UserName == userName && r.RentId == rentID)
                .FirstOrDefault();
            _context.Remove(rent);
            _context.SaveChanges();
        }

        public Rent GetRent(string userName, long rentID)
        {
            return _context.Rents.Where(r => r.User.UserName == userName && r.RentId == rentID)
                .Include(r => r.Car)
                .Include(r => r.Adress)
                .Include(r => r.User)
                .FirstOrDefault();
        }

        public IEnumerable<Rent> GetRents(string userName)
        {
            return _context.Rents.Where(r => r.User.UserName == userName)
                .Include(r => r.Car)
                .Include(r => r.Adress)
                .Include(r => r.User)
                .ToList();
        }
        public Adress GetAdress(string userName, long rentID)
        {
            return _context.Rents.Where(r => r.User.UserName == userName && r.RentId == rentID)
                .Include(r => r.Car)
                .Include(r => r.Adress)
                .Include(r => r.User)
                .FirstOrDefault().Adress;
        }

        public void SetAdress(string userName, long rentID, Adress adress)
        {
            var rent = _context.Rents.Include(r => r.User).Include(r => r.Adress).Where(r => r.User.UserName == userName && r.RentId == rentID)
                .FirstOrDefault();
            rent.Adress = adress;
            _context.SaveChanges();
        }
    }
}
