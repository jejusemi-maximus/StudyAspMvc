using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportStore.Domain.Entities;
using System.Linq;

namespace SportStore.Unit.Tests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            Product pro1 = new Product { ProductID = 1, Name = "p1" };
            Product pro2= new Product { ProductID = 2, Name = "p2" };

            Cart cart = new Cart();

            cart.AddItem(pro1, 2);
            cart.AddItem(pro2, 3);
            CartLine[] result = cart.cartLine.ToArray();

            Assert.AreEqual(result.Length, 2);
            Assert.AreEqual(result[0].Product, pro1);
            Assert.AreEqual(result[1].Product, pro2);
            Assert.AreEqual(result[1].Product.ProductID, 2);
            Assert.AreEqual(result[0].Product.ProductID, 1);

        }
    }
}
