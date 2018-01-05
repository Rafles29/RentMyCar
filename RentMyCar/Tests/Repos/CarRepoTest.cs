using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.DB;
using Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Model.DBTests
{
    [TestClass]
    public class CarRepoTest
    {
        private DbContextOptions<RentMyCarContext> options;
        private User _user;

        [TestInitialize]
        public void Init()
        {
            options = new DbContextOptionsBuilder<RentMyCarContext>()
            .UseInMemoryDatabase(databaseName: "Database")
            .Options;

            this._user = new User()
            {
                Email = "jp@gmail.com",
                UserName = "jp",
                FirstName = "Janusz",
                LastName = "Pawlak",
                Cars = new List<Car>(),
                Rents = new List<Rent>()
            };

            using (var context = new RentMyCarContext(options))
            {
                context.Users.Add(this._user);
                context.SaveChanges();
            }
        }
        [TestMethod]
        public void AddCarToDb()
        {


            Car testCar = new Car();
            testCar.Manufactor = "Ferrari";
            testCar.Model = "458";
            testCar.Price = new Price(5000);


            using (var context = new RentMyCarContext(options))
            {
                var test = context.Users.Where(u => u.UserName == this._user.UserName).FirstOrDefault();
                var service = new CarRepository(context);
                service.AddCar(this._user.UserName, testCar);
            }

            using (var context = new RentMyCarContext(options))
            {
                Assert.AreEqual("jp", context.Cars.Include(c => c.User).Single().User.UserName);
                Assert.AreEqual(1, context.Cars.Count());
                Assert.AreEqual(testCar.Manufactor, context.Cars.Single().Manufactor);
                Assert.AreEqual(testCar.Model, context.Cars.Single().Model);
                Assert.AreEqual(1, context.Cars.Single().CarId);
                Assert.AreEqual(5000, context.Cars.Include(c => c.Price).Single().Price.ShortTermPrice);
                Assert.AreEqual(this._user.UserName, context.Cars.Include(c => c.User).FirstOrDefault(c => c.CarId == 1).User.UserName);
            }

        }
        [TestMethod]
        public void FindCar()
        {

            using (var context = new RentMyCarContext(options))
            {
                Car testCar2 = new Car();
                testCar2.Manufactor = "Ferrari";
                testCar2.Model = "430";

                context.Users.Where(u => u.UserName == this._user.UserName).FirstOrDefault().Cars.Add(testCar2);
                context.SaveChanges();
            }

            using (var context = new RentMyCarContext(options))
            {
                var service = new CarRepository(context);

                var result1 = service.GetCar(1);
                Assert.AreEqual(result1.CarId, 1);
                Assert.AreEqual(result1.Manufactor, "Ferrari");
                Assert.AreEqual(result1.Model, "458");
                Assert.AreEqual("jp", context.Cars.Include(c => c.User).FirstOrDefault().User.UserName);
            }
            using (var context = new RentMyCarContext(options))
            {
                var service = new CarRepository(context);
                var result2 = service.GetCar(2);
                Assert.AreEqual(result2.CarId, 2);
                Assert.AreEqual(result2.Manufactor, "Ferrari");
                Assert.AreEqual(result2.Model, "430");
            }
        }
        [TestMethod]
        public void UpdateCar()
        {
            long cid = 1;

            using (var context = new RentMyCarContext(options))
            {
                var before = context.Cars.Find(cid);
                Assert.AreEqual(before.CarId, cid);
                Assert.AreEqual(before.Manufactor, "Ferrari");
                Assert.AreEqual(before.Model, "458");
            }
            using (var context = new RentMyCarContext(options))
            {

                Car testCar2 = new Car();
                testCar2.Manufactor = "Lamborghini";
                testCar2.Model = "Huracane";
                testCar2.CarId = cid;
                testCar2.User = this._user;

                var service = new CarRepository(context);
                service.UpdateCar(this._user.UserName, cid, testCar2);

                var after = context.Cars.Find(cid);
                Assert.AreEqual(after.CarId, cid);
                Assert.AreEqual(after.Manufactor, "Lamborghini");
                Assert.AreEqual(after.Model, "Huracane");
            }
        }
        [TestMethod]
        public void GetCars()
        {
            using (var context = new RentMyCarContext(options))
            {
                var service = new CarRepository(context);

                var cars = service.GetCars();

                Assert.AreEqual(2, cars.Count());
                Assert.AreEqual("Ferrari", cars.FirstOrDefault(c => c.CarId == 2).Manufactor);
                Assert.AreEqual("430", cars.FirstOrDefault(c => c.CarId == 2).Model);
                Assert.AreEqual("Lamborghini", cars.FirstOrDefault(c => c.CarId == 1).Manufactor);
                Assert.AreEqual("Huracane", cars.FirstOrDefault(c => c.CarId == 1).Model);

            }
        }
        [TestMethod]
        public void DeleteCar()
        {
            using (var context = new RentMyCarContext(options))
            {
                var service = new CarRepository(context);
                service.DeleteCar(this._user.UserName, 1);
            }
            using (var context = new RentMyCarContext(options))
            {
                Assert.AreEqual(1, context.Cars.Count());
                Assert.AreEqual("Ferrari", context.Cars.Single().Manufactor);
                Assert.AreEqual("430", context.Cars.Single().Model);
                Assert.AreEqual(2, context.Cars.Single().CarId);
            }
        }
        [TestMethod]
        public void UpdatePrice()
        {
            using (var context = new RentMyCarContext(options))
            {
                var service = new CarRepository(context);
                service.SetPrice(this._user.UserName, 2, new Price(3500));
            }
            using (var context = new RentMyCarContext(options))
            {
                Assert.AreEqual(3500, context.Cars.Include(c => c.Price).Include(c => c.Performance)
                .Include(c => c.Equipment).Single().Price.ShortTermPrice);
            }
        }

        [TestMethod]
        public void GetPrice()
        {
            Price pr;
            using (var context = new RentMyCarContext(options))
            {
                var service = new CarRepository(context);
                pr = service.GetPrice(2);
            }
            Assert.AreEqual(3500, pr.ShortTermPrice);
        }
        [TestMethod]
        public void UpdatePerformance()
        {
            Performance pr = new Performance()
            {
                ZeroTo100 = 2.9,
                HorsePower = 610,
                MaxSpeed = 315.2,

            };
            using (var context = new RentMyCarContext(options))
            {
                var service = new CarRepository(context);
                service.SetPerformance(this._user.UserName, 2, pr);
            }
            using (var context = new RentMyCarContext(options))
            {
                Assert.AreEqual(2.9, context.Cars.Include(c => c.Performance)
                    .Single().Performance.ZeroTo100);
                Assert.AreEqual(610, context.Cars.Include(c => c.Performance)
                    .Single().Performance.HorsePower);
                Assert.AreEqual(315.2, context.Cars.Include(c => c.Performance)
                    .Single().Performance.MaxSpeed);
            }
        }
        [TestMethod]
        public void GetPerformance()
        {
            Performance pr;
            using (var context = new RentMyCarContext(options))
            {
                var service = new CarRepository(context);
                pr = service.GetPerformance(2);
            }
            Assert.AreEqual(2.9, pr.ZeroTo100);
            Assert.AreEqual(610, pr.HorsePower);
            Assert.AreEqual(315.2, pr.MaxSpeed);
        }

        [TestMethod]
        public void UpdateEquipment()
        {
            Equipment eq = new Equipment()
            {
                AC = AC.auto,
                Lift = true,
                Seats = 2,
                Gearbox = Gearbox.auto,
                BodyType = BodyType.coupe,
                Colour = Colour.yellow

            };
            using (var context = new RentMyCarContext(options))
            {
                var service = new CarRepository(context);
                service.SetEquipment(this._user.UserName, 2, eq);
            }
            using (var context = new RentMyCarContext(options))
            {
                Assert.AreEqual(AC.auto, context.Cars.Include(c => c.Equipment)
                    .Single().Equipment.AC);
                Assert.AreEqual(true, context.Cars.Include(c => c.Equipment)
                    .Single().Equipment.Lift);
                Assert.AreEqual(2, context.Cars.Include(c => c.Equipment)
                    .Single().Equipment.Seats);
                Assert.AreEqual(Gearbox.auto, context.Cars.Include(c => c.Equipment)
                    .Single().Equipment.Gearbox);
                Assert.AreEqual(BodyType.coupe, context.Cars.Include(c => c.Equipment)
                    .Single().Equipment.BodyType);
                Assert.AreEqual(Colour.yellow, context.Cars.Include(c => c.Equipment)
                    .Single().Equipment.Colour);
            }
        }
        [TestMethod]
        public void GetEquipment()
        {
            Equipment eq;
            using (var context = new RentMyCarContext(options))
            {
                var service = new CarRepository(context);
                eq = service.GetEquipment(2);
            }
            Assert.AreEqual(AC.auto,eq.AC);
            Assert.AreEqual(true, eq.Lift);
            Assert.AreEqual(2, eq.Seats);
            Assert.AreEqual(Gearbox.auto, eq.Gearbox);
            Assert.AreEqual(BodyType.coupe, eq.BodyType);
            Assert.AreEqual(Colour.yellow, eq.Colour);
        }
    }
}
