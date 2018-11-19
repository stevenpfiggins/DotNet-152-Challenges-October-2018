using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public class ClaimRepository
    {
        Queue<Claim> _claimQueue = new Queue<Claim>();

        public void AddClaimToQueue(Claim claim)
        {
            _claimQueue.Enqueue(claim);
        }

        public Queue<Claim> SeeClaimQueue()
        {
            return _claimQueue;
        }
    }
}
