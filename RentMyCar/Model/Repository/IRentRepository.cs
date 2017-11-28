using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Repository
{
    public interface IRentRepository
    {
        void AddRent(Rent newRent);
        IEnumerable<Rent> GetRents();
        Rent GetRent(long rentID);
        void UpdateRent(long rentID, Rent updatedRent);
        void DeleteRent(long rentID);

        Adress GetAdress(long rentID);
        void SetAdress(long rentID, Adress adress);
    }
}
