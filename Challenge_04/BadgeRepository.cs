using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_04
{
    public class BadgeRepository
    {
        Dictionary<int, Badge> badges = new Dictionary<int, Badge>();

        public void AddBadge(Badge bad)
        {
            badges.Add(bad.BadgeID, bad);
        }
        public void EditBadge(int id, bool removing, string door)
        {
                if (removing)
                {
                    if (badges[id].Doors.Contains(door))
                    {
                        badges[id].RemoveDoor(door);
                    }
                }
                else
                {
                    badges[id].AddDoor(door);
                }
        }
        public Dictionary<int, Badge> GetBadges()
        {
            return badges;
        }
    }
}