using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Workshops.Models;

namespace Workshops.Tests
{
    [TestClass]
    public class WorkshopTest
    {
        [TestMethod]
        public void TestDefaultWorkshop()
        {
            Workshop w = new Workshop();

            Assert.IsFalse(w.Id.HasValue);
            Assert.IsNull(w.Title);
        }

        [TestMethod]
        public void TestWorkshop()
        {
            Workshop w = new Workshop { Id = 1, Title = "bla" };

            Assert.AreEqual(1, w.Id);
            Assert.AreEqual("bla", w.Title);
        }

        [TestMethod]
        public void TestWorkshopWithDetails()
        {
            WorkshopWithDetails w = new WorkshopWithDetails { Id = 1, Title = "bla", Place = "blabla" };

            Assert.AreEqual(1, w.Id);
            Assert.AreEqual("bla", w.Title);
            Assert.AreEqual("blabla", w.Place);
        }
    }
}
