using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.DB;
using Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace Model.DBTests
{
    [TestClass]
    public class UserRepoTest
    {

        private DbContextOptions<RentMyCarContext> options;
        private User _user;

        [TestInitialize]
        public void Init()
        {
            options = new DbContextOptionsBuilder<RentMyCarContext>()
            .UseInMemoryDatabase(databaseName: "UserBase")
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
        public void GetUsers()
        {
            IEnumerable<User> users;
            using (var context = new RentMyCarContext(options))
            {
                var service = new UserRepository(context);
                users = service.GetUsers();
            }

            Assert.AreEqual(this._user.UserName, users.FirstOrDefault().UserName);
            Assert.AreEqual(1, users.Count());
        }

        [TestMethod]
        public void GetUser()
        {
            User user;
            using (var context = new RentMyCarContext(options))
            {
                var service = new UserRepository(context);
                user = service.GetUser(this._user.UserName);
            }

            Assert.AreEqual(this._user.UserName, user.UserName);
        }
    }
}
