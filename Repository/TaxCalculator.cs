using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesTaxCalculator.Models;

namespace SalesTaxCalculator.Repository
{
    public static class TaxCalculator
    {
        public static decimal CalculateBasicTax(Product product)
        {
            if (product.IsExempt)
            {
                return 0m;
            }
            return RoundUpToNearestFiveCents(product.Price * 0.10m);
        }

        public static decimal CalculateImportDuty(Product product)
        {
            if (!product.IsImported)
            {
                return 0m;
            }
            return RoundUpToNearestFiveCents(product.Price * 0.05m);
        }

        private static decimal RoundUpToNearestFiveCents(decimal amount)
        {
            return Math.Ceiling(amount * 20) / 20;
        }
    }
}
