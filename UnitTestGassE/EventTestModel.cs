using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gass_E.Model;

namespace UnitTestGassE
{
    [TestClass]
    public class EventTestModel
    {
        [TestMethod]
        public void CreateEventAndStoreProperties()
        {
            Event newFillUp = new Event("200,000", "$50.00", "4/1/2015");
            Assert.AreEqual("200,000", newFillUp.Odometer);
            Assert.AreEqual("$50.00", newFillUp.CostofFillUp);
            Assert.AreEqual("4/1/2015", newFillUp.Date);
        }
    }
}
