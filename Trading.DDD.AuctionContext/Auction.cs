using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading.DDD.AuctionContext
{
    /// <summary>
    /// Represent the auctioning of one item
    /// </summary>
    public class Auction
    {
        private List<Bid> _bids;

        /// <summary>
        /// Constructor, must provide all data to create a valid auction
        /// </summary>
        /// <param name="item">The object to be sold</param>
        /// <param name="userId">The user selling the object</param>
        /// <param name="minimumPrice">The minimal accepted price</param>
        public Auction(Item item, Guid userId, uint minimumPrice)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException("userId");
            }

            Id = Guid.NewGuid();
            Item = item;
            MinimumPrice = minimumPrice;
            Created = DateTime.Now;
            Seller = userId;
            _bids = new List<Bid>();
        }

        /// <summary>
        /// Auction id, can only be set from constructor
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Auction creation time, can only be set from constructor
        /// </summary>
        public DateTime Created { get; private set; }

        /// <summary>
        /// Id of selling customer. Refer to the Id of a customer in the CustomerContext
        /// </summary>
        public Guid Seller { get; private set; }

        /// <summary>
        /// The item being sold. Can not be changed after bids are placed.
        /// </summary>
        public Item Item { get; private set; }

        /// <summary>
        /// The minimum accepted price
        /// </summary>
        public uint MinimumPrice { get; private set; }

        /// <summary>
        /// All bids in the auction. Can not be altered 
        /// </summary>
        public IEnumerable<Bid> Bids 
        {
            get { return _bids; }
        }

        /// <summary>
        /// The current price in the auction
        /// </summary>
        /// <returns></returns>
        public uint GetCurrentPrice()
        {
            if (_bids.Count == 0)
            {
                return MinimumPrice;
            }
            else
            {
                Bid lastBid = _bids.Last();
                return lastBid.Amount;
            }
        }

        /// <summary>
        /// Stores a new bid, after validating data
        /// </summary>
        /// <param name="bid">The bid</param>
        public void PlaceBid(Bid bid)
        {
            if (bid == null)
            {
                throw new ArgumentNullException("bid");
            }

            uint currentPrice = GetCurrentPrice();

            if (bid.Amount <= currentPrice)
            {
                throw new ArgumentException("Amount is too low");
            }

            _bids.Add(bid);
        }
    }
}
