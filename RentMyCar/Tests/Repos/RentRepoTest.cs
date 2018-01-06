using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.DB;
using Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace Tests
{
    [TestClass]
    public class RentRepoTest
    {
        private DbContextOptions<RentMyCarContext> options;

        private User _userFr;
        private Car _ferrari;

        private User _userLb;
        private Car _lambo;

        [TestInitialize]
        public void Init()
        {
            options = new DbContextOptionsBuilder<RentMyCarContext>()
            .UseInMemoryDatabase(databaseName: "RentBase")
            .Options;

            this._userFr = new User()
            {
                Email = "fr@gmail.com",
                UserName = "fr",
                FirstName = "Ferrari",
                LastName = "Ferrari",
                Cars = new List<Car>(),
                Rents = new List<Rent>()
            };
            this._ferrari = new Car
            {
                Manufactor = "Ferrari",
                Model = "458",
                Price = new Price(4000),
                Performance = new Performance()
                {
                    ZeroTo100 = 3.4,
                    HorsePower = 560,
                    MaxSpeed = 315.2,
                    Millage = 15000
                },
                Equipment = new Equipment()
                {
                    AC = AC.auto,
                    Lift = true,
                    Seats = 2,
                    Gearbox = Gearbox.auto,
                    BodyType = BodyType.coupe,
                    Colour = Colour.yellow

                }
            };

            this._userLb = new User()
            {
                Email = "lb@gmail.com",
                UserName = "lb",
                FirstName = "Lamborghini",
                LastName = "Lamborghini",
                Cars = new List<Car>(),
                Rents = new List<Rent>()
            };
            this._lambo = new Car
            {
                Manufactor = "Lamborghini",
                Model = "Huracan",
                Price = new Price(5000),
                Performance = new Performance()
                {
                    ZeroTo100 = 2.9,
                    HorsePower = 610,
                    MaxSpeed = 315.2,
                    Millage = 12000
                },
                Equipment = new Equipment()
                {
                    AC = AC.auto,
                    Lift = true,
                    Seats = 2,
                    Gearbox = Gearbox.auto,
                    BodyType = BodyType.coupe,
                    Colour = Colour.yellow

                }
            };
        }
        [TestMethod]
        public void AddRent()
        {

            using (var context = new RentMyCarContext(options))
            {
                context.Users.Add(this._userFr);
                context.Users.Add(this._userLb);
                context.SaveChanges();

                var service = new CarRepository(context);
                service.AddCar(_userFr.UserName, _ferrari);
                service.AddCar(_userLb.UserName, _lambo);
            }

            Rent rent1 = new Rent()
            {
                EndDate = DateTime.Now.AddDays(5),
                Adress = new Adress()
                {
                    PostalCode = "02-785",
                    StreetName = "Zlota",
                    StreetNumber = 52,
                    City = "Warszawa"
                },
                CarId = _lambo.CarId
            };
            Rent rent2 = new Rent()
            {
                EndDate = DateTime.Now.AddDays(5),
                Adress = new Adress()
                {
                    PostalCode = "02-787",
                    StreetName = "Pulawska",
                    StreetNumber = 99,
                    City = "Warszawa"
                },
                CarId = _ferrari.CarId
            };

            using (var context = new RentMyCarContext(options))
            {
                var service = new RentRepository(context);
                service.AddRent(this._userFr.UserName, rent1);
                service.AddRent(this._userLb.UserName, rent2);
            }

            using (var context = new RentMyCarContext(options))
            {
                Assert.AreEqual(2, context.Rents.Count());
                Assert.AreEqual(_lambo.Model, context.Rents.Include(r => r.Car).FirstOrDefault().Car.Model);
                Assert.AreEqual(_userFr.UserName, context.Rents.Include(r => r.User).FirstOrDefault().User.UserName);
            }
        }
        [TestMethod]
        public void GetRents()
        {
            IEnumerable<Rent> rentsFr;
            using (var context = new RentMyCarContext(options))
            {
                var service = new RentRepository(context);
                rentsFr = service.GetRents(_userFr.UserName);
            }

            Assert.AreEqual(1, rentsFr.Count());
            Assert.AreEqual(_lambo.Model, rentsFr.FirstOrDefault().Car.Model);
        }
        public void GetRent()
        {
            Rent rent;
            using (var context = new RentMyCarContext(options))
            {
                var service = new RentRepository(context);
                rent = service.GetRent(_userLb.UserName, 2);
            }
            Assert.AreEqual(_ferrari.Model, rent.Car.Model);
            Assert.AreEqual("02-787", rent.Adress.PostalCode);
        }
        public void GetAdress()
        {
            Adress adress;
            using (var context = new RentMyCarContext(options))
            {
                var service = new RentRepository(context);
                adress = service.GetAdress(_userLb.UserName, 2);
            }
            Assert.AreEqual("Warszawa", adress.City);
            Assert.AreEqual("02-787", adress.PostalCode);
        }
        public void SetAdress()
        {
            Adress adress = new Adress()
            {
                PostalCode = "02-785",
                StreetName = "Zlota",
                StreetNumber = 52,
                City = "Warszawa"
            };
            using (var context = new RentMyCarContext(options))
            {
                var service = new RentRepository(context);
                adress = service.GetAdress(_userLb.UserName, 2);
            }
            Assert.AreEqual("Warszawa", adress.City);
            Assert.AreEqual("02-785", adress.PostalCode);
        }
    }
}
