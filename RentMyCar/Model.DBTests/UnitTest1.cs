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
