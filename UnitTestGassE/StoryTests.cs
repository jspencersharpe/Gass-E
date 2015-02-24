using System;
using System.IO;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.BDDfy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestGassE
{
    [TestClass]
    public class StoryTests
    {
        private static Window window;
        private static Application application;
        private static Button NewFillUp;
        private static Button Reset;
        private static Button Submit;
        private static TextBox Odo;
        private static TextBox Gall;
        private static TextBox Cost;
        private static TextBox Date;

        [ClassInitialize]
        public static void Setup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _context)
        {
            var applicationDir = _context.DeploymentDirectory;
            var applicationPath = Path.Combine(applicationDir, "..\\..\\..\\StoryTests\\bin\\Debug\\Gass-E");
            application = Application.Launch(applicationPath);


            window = application.GetWindow("MainWindow", InitializeOption.NoCache);
            NewFillUp = window.Get<Button>("NewFillUp");
            Reset = window.Get<Button>("Reset");
            Submit = window.Get<Button>("Submit");
            Odo = window.Get<TextBox>("Odometer");
            Gall = window.Get<TextBox>("Gallons");
            Cost = window.Get<TextBox>("CostofFillUp");
            Date = window.Get<TextBox>("Date");
        }

        [TestMethod]
        public void WhenButtonIsClicked()
        {
            System.Threading.Thread.Sleep(500);
            NewFillUp.Click();
            System.Threading.Thread.Sleep(500);
        }

        void GivenMainWindowIsOpen()
        {
            Assert.IsTrue(window.IsCurrentlyActive);
        }

        void TextBoxesShouldBeActive()
        {
            Assert.IsFalse(Odo.IsReadOnly);
            Assert.IsFalse(Gall.IsReadOnly);
            Assert.IsFalse(Cost.IsReadOnly);
            Assert.IsFalse(Date.IsReadOnly);
        }

        void ResetButtonEnaled()
        {
            Assert.IsTrue(Reset.Enabled);
            Assert.IsTrue(Submit.Enabled);
        }

        void ResetButtonClear()
        {
            //Assert.AreEqual(Reset.Click() == Odo.);
        }

        [TestMethod]
        public void ExecuteStoryTest()
        {
            this.BDDfy();
        }

        [ClassCleanup]
        public static void TearDown()
        {
            window.Close();
            application.Close();
        }
    }
}
