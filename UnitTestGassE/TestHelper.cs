using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White.UIItems.WindowItems;
using TestStack.White;
using System.IO;
using System.Reflection;
using TestStack.White.Factory;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.Finders;
using Gass_E.Repository;
using Gass_E.Model;
using Gass_E;

namespace UnitTestGassE
{
    public class TestHelper
    {
        private static TestContext test_context;
        private static Window window;
        private static Application application;
        private static EventRepositoryTest repo = new EventRepository();
        private static EventContext context;

        public static void Setup(TestContext _context)
        {
            test_context = _context;
            var applicationDir = _context.DeploymentDirectory;
            var applicationPath = Path.Combine(applicationDir, "..\\..\\..\\TestWaitForIt\\bin\\Debug\\GassE");
            application = Application.Launch(applicationPath);
            window = application.GetWindow("MainWindow", InitializeOption.NoCache);
            context = repo.Context();
        }

        public void AndIShouldSeeAnErrorMessage()
        {
            throw new NotImplementedException();
        }

        public void AndIShouldSeeAnErrorMessage(string p)
        {
            throw new NotImplementedException();
        }

        public void AndIShouldSeeTheHelperText()
        {
            throw new NotImplementedException();
        }

        public void AndIShouldSeeXEvents(int expected)
        {
            Assert.IsNotNull(window);
            SearchCriteria searchCriteria = SearchCriteria.ByAutomationId("CostofFillUp").AndIndex(0);
            ListBox list_box = (ListBox)window.Get(searchCriteria);
            Assert.AreEqual(expected, list_box.Items.Count);
        }

        public void AndTheButtonShouldBeEnabled()
        {
            throw new NotImplementedException();
        }

        public void AndTheButtonShouldBeDisabled()
        {
            throw new NotImplementedException();
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

        public void AndTheButtonShouldBeEnabled(string p)
        {
            throw new NotImplementedException();
        }

        public void AndIShouldNotSeeTheHelperText()
        {
            throw new NotImplementedException();
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

            Assert.AreEqual(2*events.Length, repo.GetCount());
        }

        public static void CleanThisUp()
        {
            window.Close();
            repo.Clear();
            application.Close();
        }
    }

}
