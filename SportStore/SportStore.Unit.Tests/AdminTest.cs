using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportStore.Domain.Repository;
using SportStore.Domain.Entities;
using SportStore.WebUI.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SportStore.Unit.Tests
{
    [TestClass]
    public class AdminTest
    {
        [TestMethod]
        public void All_Contaion_by_product()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {ProductID = 1,Name="p1" },
                new Product {ProductID = 2,Name="p2" },
                new Product {ProductID = 3,Name="p3" }
            });


            AdminController admin = new AdminController(mock.Object);

            Product[] result = ((IEnumerable<Product>)admin.Index().ViewData.Model).ToArray();

            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual("p1", result[0].Name);
            Assert.AreEqual("p2", result[1].Name);
            Assert.AreEqual("p3", result[2].Name);

        }
    }
}
