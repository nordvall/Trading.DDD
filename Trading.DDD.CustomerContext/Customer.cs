using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading.DDD.CustomerContext
{
    /// <summary>
    /// Represents a customer in the application
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Constructor, must provide data to create valid customer object
        /// </summary>
        /// <remarks>
        /// Object must be initialized with all required properties
        /// </remarks>
        /// <param name="name"></param>
        public Customer(string name)
        {
            Id = Guid.NewGuid();
            ChangeName(name);
        }

        /// <summary>
        /// Customer Id, can only be set from constructor.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Name, can only be changed by calling ChangeName, to ensure validation
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Changes the customer name if input is valid.
        /// </summary>
        /// <param name="name"></param>
        public void ChangeName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            Name = name;
        }
    }
}
