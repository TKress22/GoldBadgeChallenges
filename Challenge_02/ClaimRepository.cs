using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_02
{
    class ClaimRepository
    {
        Queue<Claim> claims = new Queue<Claim>();
        public void AddClaim(Claim clm)
        {
            claims.Enqueue(clm);
        }
        public void HandleClaim()
        {
            claims.Dequeue();
        }
        public Queue<Claim> GetClaims()
        {
            return claims;
        }
        public DateTime ParseDate(string date)
        {
            int year = int.Parse(date.Substring(7, 2));
            int day = int.Parse(date.Substring(3, 2));
            int month = int.Parse(date.Substring(0, 2));
            DateTime prod = new DateTime(year, month, day);

            return prod;
        }
        public string ReturnPrettyDate(DateTime dat)
        {
            string pretty = dat.Day + "/" + dat.Month + "/" + dat.Year;
            return pretty;
        }
    }
}