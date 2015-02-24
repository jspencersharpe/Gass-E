﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gass_E;
using Gass_E.Model;
using Gass_E.Repository;

namespace UnitTestGassE
{
    [TestClass]
    public class EventRepositoryTest
    {
        private static EventRepository repo;

        [ClassInitialize]
        public static void SetUp(TestContext _context) 
        {
            repo = new EventRepository();
            repo.Clear();
        }

        [ClassCleanup]
        public static void CleanUp() 
        {
            repo.Clear();
            repo.Dispose();
        }

        [TestCleanup]
        public void ClearDatabase() 
        {
            repo.Clear();
        }

        [TestMethod]
        public void TestAddToDataBase() 
         {
            Assert.AreEqual(0, repo.GetCount());
            repo.Add(new Event(200000, 10, 50, "10/1/2015"));
            Assert.AreEqual(1, repo.GetCount());
        }

        [TestMethod]
        public void TestAllMethod()
        {
            repo.Add(new Event(200000, 10, 50, "10/1/2015"));
            repo.Add(new Event(100000, 10, 30, "4/1/2015"));
            Assert.AreEqual(2, repo.GetCount());
        }

        [TestMethod]
        public void TestGetCount()
        {
            Assert.AreEqual(0, repo.GetCount());
            repo.Add(new Event(100000, 10, 30, "4/1/2015"));
            Assert.AreEqual(1, repo.GetCount());
        }

        [TestMethod]
        public void TestClear()
        {
            repo.Add(new Event(100000, 10, 30, "4/1/2015"));
            repo.Clear();
            Assert.AreEqual(0, repo.GetCount());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EventsAreUnique() 
        {
            Event e = new Event(100000, 10, 30, "4/1/2015");
            repo.Clear();
            repo.Add(e);
            repo.Add(e);
            
        }
    }
}
