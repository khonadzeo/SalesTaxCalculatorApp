using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxCalculator.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsImported { get; set; }
        public bool IsExempt { get; set; }

        public Product(string name, decimal price, bool isImported, bool isExempt)
        {
            Name = name;
            Price = price;
            IsImported = isImported;
            IsExempt = isExempt;
        }
    }
}
