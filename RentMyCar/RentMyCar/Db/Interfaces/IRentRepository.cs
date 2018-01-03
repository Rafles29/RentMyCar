using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Repository
{
    public interface IRentRepository
    {
        Rent AddRent(Rent newRent);
        IEnumerable<Rent> GetRents(string userName);
        Rent GetRent(string userName, long rentID);
        void DeleteRent(string userName, long rentID);

        Adress GetAdress(string userName, long rentID);
        void SetAdress(string userName, long rentID, Adress adress);
    }
}
