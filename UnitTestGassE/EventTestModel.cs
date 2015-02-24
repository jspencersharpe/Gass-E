using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GassE.Model;

namespace UnitTestGassE
{
    [TestClass]
    public class EventTestModel
    {
        //[TestMethod]
        //public void CreatingAnEventStoresItInEvents()
        //{
        //    Event newFillUp = new Event("200,000", "$50.00", "4/1/2015");
        //    CollectionAssert.Contains(Event.Events, newFillUp);
        //}

        [TestMethod]
        public void CreateEventAndStoreProperties()
        {
            Event newFillUp = new Event(200000, 10, 50, "10/1/2015");
            Assert.AreEqual(200000, newFillUp.Odometer);
            Assert.AreEqual(10, newFillUp.Gallons);
            Assert.AreEqual(50, newFillUp.CostofFillUp);
            Assert.AreEqual("10/1/2015", newFillUp.Date);
        }
    }
}
