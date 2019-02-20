using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_02
{
    public enum TypeOfClaim { House, Car, Theft }
    public class Claim
    {
        public int ClaimID { get; set; }
        public TypeOfClaim ClaimType { get; set; }
        public string ClaimDescription { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime AccidentDate { get; set; }
        public DateTime ClaimDate { get; set; }

        public Claim(int id, TypeOfClaim typ, string desc, double amt, DateTime acc, DateTime dat)
        {
            ClaimID = id;
            ClaimType = typ;
            ClaimDescription = desc;
            ClaimAmount = amt;
            AccidentDate = acc;
            ClaimDate = dat;
        }
        public bool isValid()
        {
            TimeSpan duration = ClaimDate - AccidentDate;
            if (duration.TotalDays <= 30)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}