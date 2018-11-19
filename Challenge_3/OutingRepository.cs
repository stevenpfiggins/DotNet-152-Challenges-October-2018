using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public class OutingRepository
    {
        List<Outing> _outings = new List<Outing>();

        public void AddOutingToList(Outing outing)
        {
            _outings.Add(outing);
        }

        public List<Outing> GetOutingList()
        {
            return _outings;
        }

        public decimal GetTotalCostForAllOutings()
        {
            decimal total = 0.0m;

            foreach (var outing in _outings)
            {
                total += outing.TotalCost;
            }
            return total;
        }

        public decimal GetTotalCostForGolfOutings()
        {
            decimal total = 0.0m;

            foreach (var outing in _outings)
            {
                if (outing.OutingType == "golf")
                {
                    total += outing.TotalCost;
                }
            }
            return total;
        }

        public decimal GetTotalCostForBowlingOutings()
        {
            decimal total = 0.0m;

            foreach (var outing in _outings)
            {
                if (outing.OutingType == "bowling")
                {
                    total += outing.TotalCost;
                }
            }
            return total;
        }

        public decimal GetTotalCostForAmusementParkOutings()
        {
            decimal total = 0.0m;

            foreach (var outing in _outings)
            {
                if (outing.OutingType == "amusement park")
                {
                    total += outing.TotalCost;
                }
            }
            return total;
        }

        public decimal GetTotalCostForConcertOutings()
        {
            decimal total = 0.0m;

            foreach (var outing in _outings)
            {
                if (outing.OutingType == "concert")
                {
                    total += outing.TotalCost;
                }
            }
            return total;
        }
    }
}
