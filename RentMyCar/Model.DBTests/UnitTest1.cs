using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.DB;
using Model;
using System.Linq;

namespace Model.DBTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var db = new Db())
            {
                var user = new User();
                System.Diagnostics.Debug.WriteLine(user);
                db.Users.Add(user);
                db.SaveChanges();
            }
            using (var db = new Db())
            {
                var user = db.Users.First();
                System.Diagnostics.Debug.WriteLine(user);
                var test = new User();
                test.UserId = 1;
                System.Diagnostics.Debug.WriteLine(test);
                Assert.AreEqual(user.UserId, test.UserId);
            }


        }
        [TestMethod]
        public void MyTestMethod()
        {
            using (var db = new Db())
            {
                var car = new Car();
                System.Diagnostics.Debug.WriteLine(car);
                db.Cars.Add(car);
                db.SaveChanges();
                System.Diagnostics.Debug.WriteLine(db.Cars.ToString());
            }
        }
    }
}
