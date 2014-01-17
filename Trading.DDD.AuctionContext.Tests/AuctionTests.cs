using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading.DDD.AuctionContext.Tests
{
    [TestFixture]
    public class AuctionTests
    {
        private Guid _dummyGuid = Guid.NewGuid();
        private Item _dummyItem = new Item("Title", "Description");

        [Test]
        public void Ctor_WhenInvokedWithNoItem_ArgumentExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => { new Auction(null, _dummyGuid, 1); });
        }

        [Test]
        public void Ctor_WhenInvokedWithNoUserGuid_ArgumentExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => { new Auction(_dummyItem, Guid.Empty, 1); });
        }

        [Test]
        public void Ctor_WhenInvokedWithCorrectValues_PropertiesAreSet()
        {
            var auction = new Auction(_dummyItem, _dummyGuid, 1);

            Assert.AreEqual(_dummyItem, auction.Item);
            Assert.AreEqual(_dummyGuid, auction.Seller);
            Assert.AreNotEqual(Guid.Empty, auction.Id);
        }

        [Test]
        public void Ctor_WhenInvoked_ListOfBidsIsNotNull()
        {
            var auction = new Auction(_dummyItem, _dummyGuid, 1);

            Assert.IsNotNull(auction.Bids);
        }

        [Test]
        public void GetCurrentPrice_WhenNoBidsExist_MinimumPriceIsReturned()
        {
            uint minimumPrice = 1;
            var auction = new Auction(_dummyItem, _dummyGuid, minimumPrice);

            uint currentPrice = auction.GetCurrentPrice();

            Assert.AreEqual(minimumPrice, currentPrice);
        }

        [Test]
        public void GetCurrentPrice_WhenTwoBidsExist_HighestAmountIsReturned()
        {
            var auction = new Auction(_dummyItem, _dummyGuid, 1);

            var bid1 = new Bid(Guid.NewGuid(), 2);
            auction.PlaceBid(bid1);

            var bid2 = new Bid(Guid.NewGuid(), 3);
            auction.PlaceBid(bid2);

            uint currentPrice = auction.GetCurrentPrice();

            Assert.AreEqual(bid2.Amount, currentPrice);
        }

        [Test]
        public void PlaceBid_WhenInvokedWithNull_ArgumentExceptionIsThrown()
        {
            var auction = new Auction(_dummyItem, _dummyGuid, 1);

            Assert.Throws<ArgumentNullException>(() => { auction.PlaceBid(null); });
        }

        [Test]
        public void PlaceBid_WhenInvokedAmountLowerThanMinimum_ArgumentExceptionIsThrown()
        {
            var auction = new Auction(_dummyItem, _dummyGuid, 20);

            var bid = new Bid(Guid.NewGuid(), 10);

            Assert.Throws<ArgumentException>(() => { auction.PlaceBid(bid); });
        }

        [Test]
        public void PlaceBid_WhenInvokedWithCorrectBid_BidIsSaved()
        {
            var auction = new Auction(_dummyItem, _dummyGuid, 1);

            var bid = new Bid(Guid.NewGuid(), 2);

            auction.PlaceBid(bid);

            // Assert
            var storedBid = auction.Bids.First();
            Assert.AreEqual(bid.UserId, storedBid.UserId);
            Assert.AreEqual(bid.Amount, storedBid.Amount);
            Assert.AreEqual(bid.Time, storedBid.Time);
        }

        [Test]
        public void PlaceBid_WhenInvokedWithSameAmount_ArgumentExceptionIsThrown()
        {
            var auction = new Auction(_dummyItem, _dummyGuid, 1);

            var bid1 = new Bid(Guid.NewGuid(), 2);

            // First bid
            auction.PlaceBid(bid1);

            var bid2 = new Bid(Guid.NewGuid(), 2);

            // Second bid
            Assert.Throws<ArgumentException>(() => { auction.PlaceBid(bid2); });
        }
    }
}
