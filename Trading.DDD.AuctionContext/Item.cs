using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading.DDD.AuctionContext
{
    /// <summary>
    /// The item being sold. Represented by DDD value object
    /// </summary>
    public class Item
    {
        public Item(string title, string description)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("title");
            }

            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException("description");
            }

            Title = title;
            Description = description;
        }

        /// <summary>
        /// The item title
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// The item description
        /// </summary>
        public string Description { get; private set; }
    }
}
