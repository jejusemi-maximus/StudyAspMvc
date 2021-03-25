using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ControllersAndActions.Controllers;
using System.Web.Mvc;

namespace ControllersAndActions.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ExampleController controller = new ExampleController();

            ViewResult result = controller.Index();

            Assert.AreEqual("", result.ViewName);
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(DateTime));

        }

        [TestMethod]
        public void TestMethod2()
        {
            ExampleController exam = new ExampleController();

            ViewResult result = exam.Index();

            Assert.AreEqual("Hello", result.ViewBag.Message);

            RedirectResult result2 = exam.Redirect();

            Assert.IsTrue(result2.Permanent);
            Assert.AreEqual("/Example/Index", result2.Url);

            RedirectToRouteResult result3 = exam.Redirect2();

            Assert.IsFalse(result3.Permanent);
            Assert.AreEqual("Example", result3.RouteValues["controller"]);
            Assert.AreEqual("Index", result3.RouteValues["action"]);
            Assert.AreEqual("MyID", result3.RouteValues["ID"]);

        }
    }
}
