using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Repository
{
    interface IRentRepository
    {
        void AddRent(Rent newRent);
        IEnumerable<Rent> GetRents();
        Rent GetRent(long rentID);
        void UpdateRent(long rentID, Rent updatedRent);
        void UpdateRents(IEnumerable<Rent> updatedRents);
        void DeleteRent(long rentID);
    }
}
