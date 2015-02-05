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
        private static TextBox text_box;

        [ClassInitialize]
        public static void Setup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _context)
        {
            var applicationDir = _context.DeploymentDirectory;
            var applicationPath = Path.Combine(applicationDir, "..\\..\\..\\StoryTests\\bin\\Debug\\Gass-E");
            application = Application.Launch(applicationPath);


            window = application.GetWindow("MainWindow", InitializeOption.NoCache);
            NewFillUp = window.Get<Button>("NewFillUp");
            Reset = window.Get<Button>("Reset");
            text_box = window.Get<TextBox>("Odometer");
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
            Assert.IsTrue(window.IsFocussed);
        }

        void TextBoxShouldBeActive() 
        {
            Assert.IsFalse(text_box.IsReadOnly);
        }

        void ResetButtonEnaled() 
        {
            Assert.IsTrue(Reset.Enabled);
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
