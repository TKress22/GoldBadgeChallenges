using System;
using System.Collections.Generic;
using Challenge_03;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_03_Test
{
    [TestClass]
    public class Challenge03Test
    {
        [TestMethod]
        public void AddOutingTest()
        {
            OutingRepository oRepo = new OutingRepository();
            List<Outing> outings = oRepo.GetOutings() ;

            Outing test = new Outing(OutingType.Bowling, 50, new DateTime(), 15, 1500);
            oRepo.AddOuting(test);

            Assert.IsTrue(outings.Contains(test));
        }
        [TestMethod]
        public void GrandTotalTest()
        {
            OutingRepository oRepo = new OutingRepository();
            List<Outing> outings = new List<Outing>();

            Outing test = new Outing(OutingType.Bowling, 50, new DateTime(), 15, 1500);
            Outing test2 = new Outing(OutingType.Bowling, 50, new DateTime(), 15, 1500);

            oRepo.AddOuting(test);
            oRepo.AddOuting(test2);

            double expected = 3000;
            double actual = oRepo.GetGrandTotal();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetTotalByTypeTest()
        {
            OutingRepository oRepo = new OutingRepository();
            List<Outing> outings = new List<Outing>();

            Outing test = new Outing(OutingType.Bowling, 50, new DateTime(), 15, 1500);
            Outing test2 = new Outing(OutingType.Golf, 50, new DateTime(), 15, 1500);

            oRepo.AddOuting(test);
            oRepo.AddOuting(test2);

            double expected = 1500;
            double actual = oRepo.GetTotalByType(OutingType.Golf);

            Assert.AreEqual(expected, actual);
        }
    }
}
