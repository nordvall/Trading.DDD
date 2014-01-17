using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading.DDD.AuctionContext.Tests
{
    [TestFixture]
    public class BidTests
    {
        private Guid _dummyGuid = Guid.NewGuid();

        [Test]
        public void Ctor_WhenInvokedWithNoUserId_ArgumentExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => { new Bid(Guid.Empty, 1); });
        }

        [Test]
        public void Ctor_WhenInvokedWithNoAmount_ArgumentExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => { new Bid(_dummyGuid, 0); });
        }

        [Test]
        public void Ctor_WhenInvokedWithCorrectValues_PropertiesAreSet()
        {
            uint amount = 5;
            var expectedTime = DateTime.Now;

            var bid = new Bid(_dummyGuid, amount);

            Assert.AreEqual(_dummyGuid, bid.UserId);
            Assert.AreEqual(amount, bid.Amount);
            Assert.GreaterOrEqual(expectedTime, bid.Time);
        }
    }
}
