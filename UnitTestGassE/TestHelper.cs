using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White.UIItems.WindowItems;
using TestStack.White;
using System.IO;
using TestStack.White.Factory;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems;
using GassE.Repository;
using GassE.Model;
using GassE;

namespace UnitTestGassE
{
    public class TestHelper
    {
        private static TestContext test_context;
        protected static Window window;
        private static Application application;
        private static EventRepository repo = new EventRepository();
        private static EventContext context;
        private static String applicationPath;

        public static void SetupClass(TestContext _context)
        {
            var applicationDir = _context.DeploymentDirectory;
            applicationPath = Path.Combine(applicationDir, "..\\..\\..\\UnitTestGassE\\bin\\Debug\\GassE");
        }

        public static void TestPrep() 
        {
            application = Application.Launch(applicationPath);
            window = application.GetWindow("MainWindow", InitializeOption.NoCache);
            context = repo.Context();
        }

        public void AndIShouldSeeAnErrorMessage(string p)
        {
            throw new NotImplementedException();
        }

        public void AndIShouldSeeTheHelperText()
        {
            var text = window.Get(SearchCriteria.ByAutomationId("GettingStartedText"));
            Assert.IsTrue(text.Visible);
        }

        public void ThenIShouldSeeXEvents(int expected) 
        {
            Assert.IsNotNull(window);
            SearchCriteria searchCriteria = SearchCriteria.ByAutomationId("FillUpList").AndIndex(0);
            ListBox list_box = (ListBox)window.Get(searchCriteria);
            Assert.AreEqual(expected, list_box.Items.Count);
        }

        public void AndIShouldSeeXEvents(int x)
        {
            ThenIShouldSeeXEvents(x);
        }

        public void AndTheButtonShouldBeEnabled(string buttonContent)
        {
            Button button = window.Get<Button>(SearchCriteria.ByText(buttonContent));
            Assert.IsTrue(button.Enabled);
        }

        public void AndTheButtonShouldBeDisabled(string buttonContent)
        {
            Button button = window.Get<Button>(SearchCriteria.ByText(buttonContent));
            Assert.IsFalse(button.Enabled);
        }

        public void AndIShouldSeeAListFor(int p1, decimal p2, decimal  p3, string p4)
        {
            var e = repo.GetByDate(p4);
            Assert.IsNotNull(window);
            SearchCriteria searchCriteria = SearchCriteria.ByAutomationId("CostofFillUp").AndIndex(0);
            ListBox list_box = (ListBox)window.Get(searchCriteria);
            var item = list_box.Items.Find(i => Convert.ToInt32(i.Text) == p1);
            Assert.AreEqual(p1, item.Text);
        }

        public void ThenIShouldNotSeeTheEventForm() 
        {
            Button button = window.Get<Button>(SearchCriteria.ByAutomationId("New Fill Up"));
            Assert.IsFalse(button.Visible);
        }

        public void AndIClick(string buttonContent) 
        {
            WhenIClick(buttonContent);
        }

        public void WhenIFillInOdometerWith(int odo)
        {
            var textBox = window.Get<TextBox>("Odometer");
            textBox.SetValue(odo);
        }

        public void WhenIEnterGallons(int gall) 
        {
            var textBox = window.Get<TextBox>("Gallons");
            textBox.SetValue(gall);
        }

        public void WhenIEnterCostOfFillUp(int cost) 
        {
            var textBox = window.Get<TextBox>("CostOfFillUp");
            textBox.SetValue(cost);
        }

        public void AndIChooseTheEventDate(DateTime newDate) 
        {
            DateTimePicker picker = window.Get<DateTimePicker>(SearchCriteria.ByAutomationId("Date"));
            picker.SetValue(newDate);
        }

        public void AndTheEventDateShouldBeToday() 
        {
            DateTimePicker picker = window.Get<DateTimePicker>(SearchCriteria.ByAutomationId("Date"));
            DateTime? actual = picker.Date;
            DateTime expected = DateTime.Today;
            Assert.AreEqual(expected, actual);
        }

        public void AndIShouldNotSeeTheHelperText() 
        {
            var text = window.Get(SearchCriteria.ByAutomationId("GettingStartedText"));
            Assert.IsFalse(text.Visible);
        }

        public void ThenIShouldSeeTheEventForm() 
        {
            Button button = window.Get<Button>(SearchCriteria.ByAutomationId("Submit"));
            Assert.IsTrue(button.Visible);
        }

        public void WhenIClick(string buttonContent) 
        {
            Button button = window.Get<Button>(SearchCriteria.ByText(buttonContent));
            button.Click();
        }

        public void ThenIShouldSeeAFillUpFor(int p1, int p2, int p3, string p4) 
        {
            throw new NotImplementedException();
        }

        public void GivenThereAreNoEvents()
        {
            Assert.AreEqual(0, repo.GetCount());
        }

        public void GivenTheseEvents(params Event[] events) 
        {
            foreach (Event evnt in events) 
            {
                repo.Add(evnt);
            }

            Assert.AreEqual(events.Length, repo.GetCount());
        }

        public static void CleanThisUp()
        {
            window.Close();
            application.Close();
            repo.Clear();
        }
    }

}
