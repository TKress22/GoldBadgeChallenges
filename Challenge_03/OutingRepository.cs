using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_03
{
    public class OutingRepository
    {
        List<Outing> outings = new List<Outing>();

        public void AddOuting(Outing add)
        {
            outings.Add(add);
        }
        public List<Outing> GetOutings()
        {
            return outings;
        }
        public double GetGrandTotal()
        {
            double total = 0;
            return total;
        }        
        public double GetTotalByType(OutingType type)
        {
            double total = 0;
            return total;
        }
    }
}