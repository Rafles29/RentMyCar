using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.DB;
using Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Model.DBTests
{
    [TestClass]
    public class CarRepoTest
    {
        private DbContextOptions<RentMyAppContext> options;

        [TestInitialize]
        public void Init()
        {
            options = new DbContextOptionsBuilder<RentMyAppContext>()
            .UseInMemoryDatabase(databaseName: "Database")
            .Options;
        }

        [TestMethod]
        public void AddCarToDb()
        {

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
                Assert.AreEqual(testCar.Manufactor, context.Cars.Single().Manufactor);
                Assert.AreEqual(testCar.Model, context.Cars.Single().Model);
                Assert.AreEqual(1, context.Cars.Single().CarId);
            }
        }
        [TestMethod]
        public void FindCar()
        {

            using (var context = new RentMyAppContext(options))
            {
                Car testCar2 = new Car();
                testCar2.Manufactor = "Ferrari";
                testCar2.Model = "430";

                context.Cars.Add(testCar2);
                context.SaveChanges();
            }

            using (var context = new RentMyAppContext(options))
            {
                var service = new CarRepository(context);

                var result1 = service.GetCar(1);
                Assert.AreEqual(result1.CarId, 1);
                Assert.AreEqual(result1.Manufactor, "Ferrari");
                Assert.AreEqual(result1.Model, "458");

                var result2 = service.GetCar(2);
                Assert.AreEqual(result2.CarId, 2);
                Assert.AreEqual(result2.Manufactor, "Ferrari");
                Assert.AreEqual(result2.Model, "430");
            }
        }
        [TestMethod]
        public void UpdateCar()
        {

            using (var context = new RentMyAppContext(options))
            {
                var service = new CarRepository(context);

                long cid = 1;

                var before = context.Cars.Find(cid);
                Assert.AreEqual(before.CarId, cid);
                Assert.AreEqual(before.Manufactor, "Ferrari");
                Assert.AreEqual(before.Model, "458");

                Car testCar2 = new Car();
                testCar2.Manufactor = "Lamborghini";
                testCar2.Model = "Huracane";
                testCar2.CarId = cid;

                service.UpdateCar(cid, testCar2);

                var after = context.Cars.Find(cid);
                Assert.AreEqual(after.CarId, cid);
                Assert.AreEqual(after.Manufactor, "Lamborghini");
                Assert.AreEqual(after.Model, "Huracane");
            }
        }

    }
}
