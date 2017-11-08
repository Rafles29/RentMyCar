using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Repository
{
    interface ICarOwnerRepository
    {
        void AddCarOwner(CarOwner newCarOwner);
        IEnumerable<CarOwner> GetCarOwners();
        CarOwner GetCarOwner(long carOwnerID);
        void UpdateCarOwner(long carOwnerID, CarOwner updatedCarOwner);
        void DeleteCarOwner(long carOwnerID);
    }
}
