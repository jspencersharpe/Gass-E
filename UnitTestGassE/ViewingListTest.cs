using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gass_E.Model;

namespace UnitTestGassE
{
    [TestClass]
    public class ViewingListTest : TestHelper
    {

        [ClassInitialize]
        public static void SetUpTests(TestContext _context)
        {
            TestHelper.Setup(_context);
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            TestHelper.CleanThisUp();
        }

        [TestMethod]
        public void ScenarioViewingListWithEvents()
        {
            GivenTheseEvents(
                new Event("200,000", "$50.00", "4/1/15"),
                new Event("100,000", "$40.00", "2/15/15")
                );
            ThenIShouldSeeXEvents(2);
            AndIShouldSeeAListFor("200,000", "$50.00", "4/1/15");
            AndIShouldSeeAListFor("100,000", "$40.00", "2/15/15");
            AndIShouldNotSeeTheHelperText();
            AndTheButtonShouldBeEnabled("Submit");
        }


    }
}
