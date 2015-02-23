using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gass_E.Model;

namespace UnitTestGassE
{
    [TestClass]
    public class AddingFillUpTest : TestHelper
    {
        [ClassInitialize]
        public static void SetUpTests(TestContext _context) 
        {
            TestHelper.SetupClass(_context);
        }

        [TestInitialize]
        public void SetupTests() 
        {
            TestHelper.TestPrep();
        }

        [ClassCleanup]
        public void CleanUp() 
        {
            TestHelper.CleanThisUp();
        }

        [TestMethod]
        public void ScenarioEventCreation()
        {
            GivenThereAreNoEvents();
            WhenIClick("NewFillUp");
            ThenIShouldSeeTheEventForm();
            AndIShouldNotSeeTheHelperText();
            AndTheEventDateShouldBeToday();
            AndTheButtonShouldBeDisabled("NewFillUp");
            WhenIFillInOdometerWith(200000);
            WhenIEnterCostOfFillUp(50);
            AndIChooseTheEventDate(new DateTime(2015, 10, 01));
            AndIClick("Submit");
            ThenIShouldNotSeeTheEventForm();
            AndIShouldSeeXEvents(1);
            AndIShouldSeeAListFor(200000, 50, "10/1/2015");
            AndIShouldNotSeeTheHelperText();
            AndTheButtonShouldBeEnabled("Submit");
        }

        [TestMethod]
        public void ScenarioDataValidationForEventCreation()
        {
            GivenThereAreNoEvents();
            WhenIClick("NewFillUp");
            AndIClick("Submit");
            ThenIShouldSeeTheEventForm();
            AndIShouldSeeAnErrorMessage("All parameters must be filled in");
            WhenIFillInOdometerWith(200000);
            WhenIEnterCostOfFillUp(50);
            AndIChooseTheEventDate(new DateTime(2015, 10, 01));
            AndIClick("Submit");
            ThenIShouldSeeTheEventForm();
            AndIShouldSeeXEvents(1);
            AndIShouldSeeAListFor(200000, 50, "10/01/2015");
        }

        [TestMethod]
        public void ScenarioResettingEventCreation()
        {
            GivenThereAreNoEvents();
            WhenIClick("NewFillUp");
            WhenIFillInOdometerWith(200000);
            AndIChooseTheEventDate(new DateTime(2015, 10, 01));
            AndIClick("Reset");
            AndIShouldSeeXEvents(0);
            AndIShouldSeeTheHelperText();
            AndTheButtonShouldBeDisabled("NewFillUp");

        }


    }
}
