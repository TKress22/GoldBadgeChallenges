using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_03
{
    public enum OutingType { Golf, Bowling, AmusementPark, Concert }

    public class Outing
    {
        public OutingType EventType { get; set; }
        public int AttendanceCount { get; set; }
        public DateTime Date { get; set; }
        public double CostPerPerson { get; set; }
        public double TotalCost { get; set; }

        public Outing(OutingType typ, int atnd, DateTime dat, double pCost, double tCost)
        {
            EventType = typ;
            AttendanceCount = atnd;
            Date = dat;
            CostPerPerson = pCost;
            TotalCost = tCost;
        }
    }
}
