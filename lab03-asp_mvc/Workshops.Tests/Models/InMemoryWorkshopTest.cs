using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Workshops.Models;

namespace Workshops.Tests.Controllers
{
    [TestClass]
    public class InMemoryWorkshopTest
    {
        [TestMethod]
        public void TestDefault()
        {
            IWorkshopRepository repo = new InMemoryWorkshopRepository();

            int n = repo.GetAllWorkshops().Count();
            Assert.AreEqual(3, n);

            Workshop w = repo.GetAllWorkshops().ElementAt(0);
            Assert.IsNotNull(w);
            Assert.AreEqual(1, w.Id);

            WorkshopWithDetails wd = repo.GetWorkshop(1);
            Assert.IsNotNull(wd);
            Assert.AreEqual(1, wd.Id);

            Assert.AreEqual(w.Title, wd.Title);

            Assert.IsNull(repo.GetWorkshop(-1));
        }

        [TestMethod]
        public void TestAddWorkshop()
        {
            IWorkshopRepository repo = new InMemoryWorkshopRepository();

            int n = repo.GetAllWorkshops().Count();
            
            WorkshopWithDetails wd = new WorkshopWithDetails { Title = "bla", Place = "blabla" };
            Assert.IsNull(wd.Id);

            repo.SaveWorkshop(wd);

            Assert.IsNotNull(wd.Id);
            Assert.AreEqual("bla", wd.Title);
            Assert.AreEqual("blabla", wd.Place);

            Assert.AreEqual(n + 1, repo.GetAllWorkshops().Count());

            WorkshopWithDetails wd2 = repo.GetWorkshop(wd.Id.Value);
            Assert.AreEqual(wd.Title, wd2.Title);
            Assert.AreEqual(wd.Place, wd2.Place);

        }
    }
}
