using Huy_Phuong.Core;
using Huy_Phuong.Interfaces;
using Huy_Phuong.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestTheatre
{
    using System.Globalization;
    using System.Linq;

    //AddPerformance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price)
    //ListPerformances(string theatreName)

    [TestClass]
    public class TestPerformanceDatabase
    {
        private IPerformanceDatabase data;

        [TestInitialize]
        public void SetUp()
        {

            this.data = new PerformanceDatabase();
        }

        [TestMethod]
        public void TestPerformanceDB_ListTheatres_AllTheatres()
        {
            string theatreName = "test1";
            string theatreName2 = "test2";
            this.data.AddTheatre(theatreName);
            this.data.AddTheatre(theatreName2);

            var theatres = this.data.ListTheatres();

            Assert.AreEqual(2, theatres.Count(), "The list is not full");
        }

        [TestMethod]
        public void TestPerformanceDB_AddPerformance_Performance()
        {
            string theatreName = "test1";

            ITheatre theatre = new Theatre(theatreName);

            DateTime date = DateTime.ParseExact("18.01.2015 18:00", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.Parse("1:30");
            this.data.AddPerformance(theatre, "title", date, duration, 14.60m);

            int numberOfPerformances = this.data.ListPerformances(theatreName).Count();

            Assert.AreEqual(1, numberOfPerformances, "The number of performances are not the same");
        }
    }
}
