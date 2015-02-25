using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GassE.Model;

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

        [TestCleanup]
        public void CleanUp() 
        {
            TestHelper.CleanThisUp();
        }

        [TestMethod]
        public void ScenarioEventCreation()
        {
            GivenThereAreNoEvents();
            WhenIClick("New Fill Up");
            ThenIShouldSeeTheEventForm();
            AndIShouldNotSeeTheHelperText();
            AndTheEventDateShouldBeToday();
            AndTheButtonShouldBeDisabled("New Fill Up");
            WhenIFillInOdometerWith(200000);
            WhenIEnterGallons(10);
            WhenIEnterCostOfFillUp(50);
            AndIChooseTheEventDate(new DateTime(2015, 10, 01));
            AndIClick("Submit");
            ThenIShouldNotSeeTheEventForm();
            AndIShouldSeeXEvents(1);
            AndIShouldSeeAListFor(200000, 10, 50, "10/1/2015");
            AndIShouldNotSeeTheHelperText();
            AndTheButtonShouldBeEnabled("Submit");
        }

        [TestMethod]
        public void ScenarioDataValidationForEventCreation()
        {
            GivenThereAreNoEvents();
            WhenIClick("New Fill Up");
            AndIClick("Submit");
            ThenIShouldSeeTheEventForm();
            AndIShouldSeeAnErrorMessage("All parameters must be filled in");
            WhenIFillInOdometerWith(200000);
            WhenIEnterGallons(10);
            WhenIEnterCostOfFillUp(50);
            AndIChooseTheEventDate(new DateTime(2015, 10, 01));
            AndIClick("Submit");
            ThenIShouldSeeTheEventForm();
            AndIShouldSeeXEvents(1);
            AndIShouldSeeAListFor(200000, 10, 50, "10/01/2015");
        }

        [TestMethod]
        public void ScenarioResettingEventCreation()
        {
            GivenThereAreNoEvents();
            WhenIClick("New Fill Up");
            WhenIFillInOdometerWith(200000);
            WhenIEnterGallons(10);
            AndIChooseTheEventDate(new DateTime(2015, 10, 01));
            AndIClick("Reset");
            AndIShouldSeeXEvents(0);
            AndIShouldSeeTheHelperText();
            AndTheButtonShouldBeDisabled("New Fill Up");

        }


    }
}
