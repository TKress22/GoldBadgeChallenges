using System;
using System.Collections.Generic;
using Challenge_02;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_02_Test
{
    [TestClass]
    public class Challenge02Tests
    {
        [TestMethod]
        public void AddClaimTest()
        {
            ClaimRepository cRepo = new ClaimRepository();
            Queue<Claim> claims = cRepo.GetClaims();

            Claim test = new Claim(1, TypeOfClaim.Car, "car ded", 4500, new DateTime(), new DateTime());
            cRepo.AddClaim(test);

            Assert.IsTrue(claims.Contains(test));
        }

        [TestMethod]
        public void RemoveClaimTest()
        {
            ClaimRepository cRepo = new ClaimRepository();
            Queue<Claim> claims = cRepo.GetClaims();

            Claim test = new Claim(1, TypeOfClaim.Car, "car ded", 4500, new DateTime(), new DateTime());

            cRepo.AddClaim(test);
            cRepo.HandleClaim();

            Assert.IsFalse(claims.Contains(test));
        }

        [TestMethod]
        public void ReturnPrettyDateTest()
        {
            ClaimRepository cRepo = new ClaimRepository();
            DateTime uglyDate = new DateTime(05, 05, 01);

            string actual = cRepo.ReturnPrettyDate(uglyDate);
            string expected = "5/1/5";

            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }
    }
}
