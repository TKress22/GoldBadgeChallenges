using System;
using System.Collections.Generic;
using Challenge_04;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_04_Test
{
    [TestClass]
    public class Challenge04Tests
    {
        [TestMethod]
        public void AddBadgeTest()
        {
            BadgeRepository bRepo = new BadgeRepository();
            Dictionary<int, Badge> badges = bRepo.GetBadges();

            Badge test = new Badge(123, new List<string> { "Ye", "Yoi", "Yo" });
            bRepo.AddBadge(test);

            Assert.IsTrue(badges.ContainsValue(test));
        }

        [TestMethod]
        public void EditBadgeAddTest()
        {
            BadgeRepository bRepo = new BadgeRepository();
            Dictionary<int, Badge> badges = bRepo.GetBadges();

            Badge test = new Badge(123, new List<string> { "Ye", "Yoi", "Yo" });
            bRepo.AddBadge(test);
            bRepo.EditBadge(test.BadgeID, false, "F5");

            Assert.IsTrue(badges[test.BadgeID].Doors.Contains("F5"));
        }

        [TestMethod]
        public void EditBadgeRemoveTest()
        {
            BadgeRepository bRepo = new BadgeRepository();
            Dictionary<int, Badge> badges = bRepo.GetBadges();

            Badge test = new Badge(123, new List<string> { "Ye", "Yoi", "Yo" });
            bRepo.AddBadge(test);
            bRepo.EditBadge(test.BadgeID, true, "Ye");

            Assert.IsFalse(badges[test.BadgeID].Doors.Contains("Ye"));
        }
    }
}