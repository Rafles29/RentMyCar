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
            throw new NotImplementedException();
        }

        public void DeleteRent(long rentID)
        {
            throw new NotImplementedException();
        }

        public Rent GetRent(long rentID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rent> GetRents()
        {
            throw new NotImplementedException();
        }

        public void UpdateRent(long rentID, Rent updatedRent)
        {
            throw new NotImplementedException();
        }
    }
}
