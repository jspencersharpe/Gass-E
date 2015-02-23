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
    public class ZeroStateTest : TestHelper
    {

        [ClassInitialize]
        public static void SetupTests(TestContext _context)
        {
            TestHelper.SetupClass(_context);
        }

        [TestInitialize]
        public void SetUpTests() 
        {
            TestHelper.TestPrep();
        }

        [TestCleanup]
        public void CleanUp()
        {
            TestHelper.CleanThisUp();
        }

        [TestMethod]
        public void TestZeroStateButton()
        {
            Button NewFillUp = window.Get<Button>("NewFillUp");
            Button Reset = window.Get<Button>("Reset");
            Button Submit = window.Get<Button>("Submit");
            Assert.IsTrue(NewFillUp.Enabled);
            Assert.IsTrue(Reset.Enabled);
            Assert.IsTrue(Submit.Enabled);
        }

        [TestMethod]
        public void TestZeroStateHelpElements()
        {
            var text = window.Get(SearchCriteria.ByAutomationId("GettingStartedText"));
            Assert.IsTrue(text.Visible);
        }
        

    }
}
