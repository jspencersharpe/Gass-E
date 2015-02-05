using System;
using System.IO;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            TextBox text_box = window.Get<TextBox>("Odometer");

            Assert.IsTrue(NewFillUp.Enabled);
            Assert.IsFalse(Reset.Enabled);
            Assert.AreEqual(text_box.Text, "");
        }

        [ClassCleanup]
        public static void TearDown()
        {
            window.Close();
            application.Close();
        }
    }
}
