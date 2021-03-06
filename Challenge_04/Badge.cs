﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_04
{
    public class Badge
    {
        public int BadgeID { get; set;}
        public List<string> Doors { get; set; }

        public Badge(int id, List<string> doors)
        {
            BadgeID = id;
            Doors = doors;
        }
        public void RemoveDoor(string door)
        {
            Doors.Remove(door);
        }
        public void AddDoor(string door)
        {
            Doors.Add(door);
        }
    }
}