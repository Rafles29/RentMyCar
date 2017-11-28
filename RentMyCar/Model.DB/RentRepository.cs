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
        public void AddRent(Rent newRent)
        {
            _context.Rents.Add(newRent);
            _context.SaveChanges();
        }

        public void DeleteRent(long rentID)
        {
            var rent = _context.Rents.Find(rentID);
            _context.Remove(rent);
            _context.SaveChanges();
        }

        public Rent GetRent(long rentID)
        {
            return _context.Rents.Include(r => r.Car).Include(r => r.Adress).
                Include(r => r.User).FirstOrDefault(r => r.RentId == rentID);
        }

        public IEnumerable<Rent> GetRents()
        {
            return _context.Rents.Include(r => r.Car).Include(r => r.Adress).
                Include(r => r.User).ToList();
        }

        public void UpdateRent(long rentID, Rent updatedRent)
        {
            throw new NotImplementedException();
        }

        public Adress GetAdress(long rentID)
        {
            return _context.Rents.Find(rentID).Adress;
        }

        public void SetAdress(long rentID, Adress adress)
        {
            var rent = _context.Rents.Find(rentID);
            rent.Adress = adress;
            _context.SaveChanges();
        }
    }
}
