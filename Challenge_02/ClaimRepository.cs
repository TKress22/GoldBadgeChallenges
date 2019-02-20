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
        public string ReturnPrettyDate(DateTime dat)
        {
            string pretty = dat.Day + "/" + dat.Month + "/" + dat.Year;
            return pretty;
        }
    }
}