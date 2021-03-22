using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EssentialTools.Models;
using System.Linq;
using Moq;

namespace EssentialTools.Test
{
    [TestClass]
    public class UnitTest2
    {
        private Product[] Products =
        {
            new Product{Name="me",Category="soccer",Price=256m },
            new Product{Name="me1",Category="soccer",Price=256m },
            new Product{Name="me2",Category="soccer",Price=256m },
            new Product{Name="me3",Category="water",Price=512m }
        };

        [TestMethod]
        public void Sum_Products()
        {
            //arange

            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(total => total);

            var target = new LinqCalculator(mock.Object);

            var result = target.ValueProducts(Products);


            Assert.AreEqual(Products.Sum(e => e.Price), result);
        }
    }
}
