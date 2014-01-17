using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading.DDD.AuctionContext
{
    /// <summary>
    /// A bid in an auction. Represented by a DDD "value object"
    /// </summary>
    public class Bid
    {
        /// <summary>
        /// Constructor, must provide all data necessary to create valid object
        /// </summary>
        /// <param name="userId">The user placing the bid</param>
        /// <param name="amount">The amount of the bid</param>
        public Bid(Guid userId, uint amount)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException("userId");
            }

            if (amount == 0)
            {
                throw new ArgumentNullException("description");
            }

            UserId = userId;
            Amount = amount;
            Time = DateTime.Now;
        }

        /// <summary>
        /// The user that placed the bid
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// The amount of money
        /// </summary>
        public uint Amount { get; private set; }

        /// <summary>
        /// The time of the bid.
        /// </summary>
        public DateTime Time { get; private set; }
    }
}
