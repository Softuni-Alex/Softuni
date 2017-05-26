using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy.Interfaces
{
    internal interface ISales
    {
        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the date of sale.
        /// </summary>
        DateTime DateOfSale { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        decimal Price { get; set; }
    }
}
