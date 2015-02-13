using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White.UIItems.WindowItems;
using TestStack.White;
using System.IO;
using System.Reflection;
using TestStack.White.Factory;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems;
using Gass_E.Repository;
using Gass_E.Model;
using Gass_E;
using System.Windows.Automation;

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
            var applicationPath = Path.Combine(applicationDir, "..\\..\\..\\TestWaitForIt\\bin\\Debug\\GassE");

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

        public void AndIShouldSeeAListFor(string p1, string p2, string p3)
        {
            throw new NotImplementedException();
        }

        public void ThenIShouldSeeXEvents(int p)
        {
            throw new NotImplementedException();
        }

        public void AndIShouldSeeAListFor(string p1, string p2)
        {
            var e = repo.GetByDate(p2);
            Assert.IsNotNull(window);
            SearchCriteria searchCriteria = SearchCriteria.ByAutomationId("CostofFillUp").AndIndex(0);
            ListBox list_box = (ListBox)window.Get(searchCriteria);
            var item = list_box.Items.Find(i => i.Text == p1);
            Assert.AreEqual(p1, item.Text);
        }

        public void AndIShouldNotSeeTheHelperText()
        {
            var text = window.Get(SearchCriteria.ByAutomationId("GettingStartedText"));
            Assert.IsFalse(text.Visible);
        }

        public void GivenThereAreNoEvents() 
        {
            Assert.AreEqual(0, repo.GetCount());
        }

        public static void GivenTheseEvents(params Event[] events)
        {
            repo.Add(events[0]);
            repo.Add(events[1]);

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
