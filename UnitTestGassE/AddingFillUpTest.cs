using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gass_E.Model;

namespace UnitTestGassE
{
    [TestClass]
    public class AddingFillUpTest : TestHelper
    {
        [ClassInitialize]
        public static void SetUpTests(TestContext _context) 
        {
            TestHelper.SetupClass(_context);
        }

        [TestInitialize]
        public void SetupTests() 
        {
            TestHelper.TestPrep();
        }

        [ClassCleanup]
        public void CleanUp() 
        {
            TestHelper.CleanThisUp();
        }


    }
}
