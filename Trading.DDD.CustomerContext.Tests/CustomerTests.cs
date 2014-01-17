using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading.DDD.CustomerContext.Tests
{
    [TestFixture]
    public class CustomerTests
    {
        [Test]
        public void Ctor_WhenInvokedWithNull_ArgumentExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => new Customer(""));
        }

        [Test]
        public void Ctor_WhenInvokedWithCorrectName_NamePropertyIsSet()
        {
            string name = "Pelle";

            var customer = new Customer(name);

            Assert.AreEqual(name, customer.Name);
        }
    }
}
