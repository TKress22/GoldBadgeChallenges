using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_02
{
    public class ClaimRepository
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
        public string ReturnPrettyDate(DateTime dat)
        {
            string pretty = dat.Month + "/" + dat.Day + "/" + dat.Year;
            return pretty;
        }
    }
}