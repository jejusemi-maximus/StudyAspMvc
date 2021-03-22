using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EssentialTools.Models;

namespace EssentialTools.Test
{
    [TestClass]
    public class UnitTest1
    {
        private IDiscountHelper getTestOBJ()
        {
            return new MinimumDiscountHelper();
        }
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            IDiscountHelper taget = getTestOBJ();
            Decimal total = 200;
            //act
            var discountTotal = taget.ApplyDiscount(total);
            //assert
            Assert.AreEqual(total * 0.9M, discountTotal);
        }
        [TestMethod]
        public void Discount_Between_10_And_100()
        {
            IDiscountHelper target = getTestOBJ();
            decimal Tendollar = target.ApplyDiscount(10);
            decimal hundredollar = target.ApplyDiscount(100);
            decimal Fiftydollar = target.ApplyDiscount(50);

            Assert.AreEqual(5, Tendollar, "10달러 아님");
            Assert.AreEqual(95, hundredollar, "100달러 아님");
            Assert.AreEqual(45, Fiftydollar, "50달러 아님");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Discount_Negative_total()
        {
            IDiscountHelper target = getTestOBJ();
            target.ApplyDiscount(-1);
        }
    }
}
