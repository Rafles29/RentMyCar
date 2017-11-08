using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
namespace ModelTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PriceTestMethod1()
        {
            decimal temp = 300.50m;
            Price pr = new Price(temp);

            Assert.AreEqual(pr.ShortTerm, temp);
            Assert.AreEqual(pr.MidTerm, 5 * temp);
            Assert.AreEqual(pr.LongTerm, 15 * temp);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PriceTestMethod2()
        {
            decimal temp = -300.50m;
            Price pr = new Price(temp);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PriceTestMethod3()
        {
            decimal temp = 300.50m;
            decimal temp2 = -300.50m;
            decimal temp3 = 300.50m;
            Price pr = new Price(temp,temp2,temp3);
        }
    }
}
