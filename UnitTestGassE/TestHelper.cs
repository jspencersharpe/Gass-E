using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White.UIItems.WindowItems;
using TestStack.White;
using System.IO;
using TestStack.White.Factory;
using TestStack.White.UIItems.ListBoxItems;
using Gass_E.Model;

namespace UnitTestGassE
{
    public class TestHelper
    {
        private static TestContext test_context;
        private static Window window;
        private static Application application;

        public static void Setup(TestContext _context)
        {
            test_context = _context;
            var applicationDir = _context.DeploymentDirectory;
            var applicationPath = Path.Combine(applicationDir, "..\\..\\..\\TestWaitForIt\\bin\\Debug\\GassE");
            application = Application.Launch(applicationPath);
            window = application.GetWindow("MainWindow", InitializeOption.NoCache);
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

        public void AndIShouldSeeXEvents(int p)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void AndTheButtonShouldBeEnabled(string p)
        {
            throw new NotImplementedException();
        }

        public void AndIShouldNotSeeTheHelperText()
        {
            throw new NotImplementedException();
        }

        public static void GivenTheseEvents(Event p1, Event p2)
        {
            throw new NotImplementedException();
        }

        public static void CleanThisUp()
        {
            window.Close();
            application.Close();
        }
    }

}
