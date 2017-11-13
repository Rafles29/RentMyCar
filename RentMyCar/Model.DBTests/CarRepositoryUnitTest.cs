using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.DB;
using Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Model.DBTests
{
    [TestClass]
    public class CarRepositoryUnitTest
    {
        [TestMethod]
        public void AddCarToDb()
        {
            var options = new DbContextOptionsBuilder<RentMyAppContext>()
            .UseInMemoryDatabase(databaseName: "Add_cars_to_database")
            .Options;

            Car testCar = new Car();
            testCar.Manufactor = "Ferrari";
            testCar.Model = "458";
            using (var context = new RentMyAppContext(options))
            {
                var service = new CarRepository(context);
                service.AddCar(testCar);
            }

            using (var context = new RentMyAppContext(options))
            {
                Assert.AreEqual(1, context.Cars.Count());
                Assert.AreEqual(testCar.Manufactor,context.Cars.Single().Manufactor);
                Assert.AreEqual(testCar.Model, context.Cars.Single().Model);
            }
        }

    }
}
