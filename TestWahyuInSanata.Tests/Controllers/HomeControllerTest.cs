using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TestWahyuInSanata;
using TestWahyuInSanata.Controllers;
using TestWahyuInSanata.Models;

namespace TestWahyuInSanata.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void processData()
        {
            TestClass dataTest = new TestClass();
            dataTest.UmurA = 10;
            dataTest.TahunA = 12;
            dataTest.UmurB = 13;
            dataTest.TahunB = 17;
            // Arrange
            HomeController controller = new HomeController();

            // Act
            var result = controller.ProcessData(dataTest);
            Assert.IsNotNull(result, "No ActionResult returned from action method.");
        }

    }
}
