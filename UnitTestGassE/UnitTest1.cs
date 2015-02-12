using System;
using System.IO;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gass_E.Model;

namespace UnitTestGassE
{
    [TestClass]
    public class UITests
    {
        private static TestContext test_context;
        private static Window window;
        private static Application application;

        [ClassInitialize]
        public static void Setup(TestContext _context)
        {
            test_context = _context;
            var applicationDir = _context.DeploymentDirectory;
            var applicationPath = Path.Combine(applicationDir, "..\\..\\..\\UnitTestGassE\\bin\\Debug\\Gass-E");
            application = Application.Launch(applicationPath);
            window = application.GetWindow("MainWindow", InitializeOption.NoCache);

        }

        [TestMethod]
        public void TestZeroState()
        {
            Button NewFillUp = window.Get<Button>("NewFillUp");
            Button Reset = window.Get<Button>("Reset");
            Assert.IsTrue(NewFillUp.Enabled);
        }

        [ClassCleanup]
        public static void TearDown() 
        {
            window.Close();
            application.Close();
        }

    }
}
