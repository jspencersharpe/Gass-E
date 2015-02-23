using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gass_E.Model;

namespace UnitTestGassE
{
    [TestClass]
    public class ViewingListTest : TestHelper
    {
        [ClassInitialize] 
        public static void Setup(TestContext _context)
        {
           TestHelper.SetupClass(_context);
        }

        [TestInitialize]
        public void SetupTests()
        {
            GivenTheseEvents(
                new Event(200000, 50, "4/1/15"),
                new Event(100000, 40, "2/15/15")
                );
            TestHelper.TestPrep();
        }

        [TestCleanup]
        public void CleanUp()
        {
            TestHelper.CleanThisUp();
        }

        [TestMethod]
        public void ScenarioViewingListWithEvents()
        {
            
            ThenIShouldSeeXEvents(2);
            AndIShouldSeeAListFor(200000, 50, "4/1/15");
            AndIShouldSeeAListFor(100000, 40, "2/15/15");
            AndIShouldNotSeeTheHelperText();
            AndTheButtonShouldBeEnabled("NewFillUp");
        }


    }
}
