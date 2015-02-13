using System;
using System.IO;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.ListBoxItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White.UIItems.Finders;

namespace UnitTestGassE
{
    [TestClass]
    public class ZeroStateTest
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
        public void TestZeroStateButton()
        {
            Button NewFillUp = window.Get<Button>("NewFillUp");
            Button Reset = window.Get<Button>("Reset");
            Assert.IsTrue(NewFillUp.Enabled);
            Assert.IsTrue(Reset.Enabled);
        }

        [ClassCleanup]
        public static void TearDown() 
        {
            window.Close();
            application.Close();
        }

    }
}
